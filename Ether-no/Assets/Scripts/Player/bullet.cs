using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
     [Range(1, 10)]
    public float speed = 10f;

    [Range(1, 10)]
    public float lifeTime = 3f;

    private Rigidbody2D rb;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = transform.up * speed;
    }
}
