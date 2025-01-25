using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public float speed = 5f;

    // GUN VARIABLES
    public GameObject bulletPrefab;
    public Transform firingPoint;
    //[Range(0.1f, 1f)]
    //private float fireRate = 0.5f

    private Rigidbody2D rb;
    private float mx;
    private float my;
    private Vector2 mousePos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        my = Input.GetAxisRaw("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - 
        transform.position.x) * Mathf.Rad2Deg - 90f;

        transform.localRotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(mx, my).normalized * speed;
    }

    private void Shoot() 
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
}
