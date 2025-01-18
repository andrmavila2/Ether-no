using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int speed;


    private float x;
    private float y;
    private Vector2 _direccion;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        _direccion = new Vector2(x, y);
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _direccion * (speed * Time.fixedDeltaTime));
    }
}
