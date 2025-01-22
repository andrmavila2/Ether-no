using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;  // Referencia al Rigidbody2D
    [SerializeField] private int speed;      // Velocidad del jugador
    [SerializeField] private float smoothTime = 0.1f;  // Tiempo de suavizado

    private float x;
    private float y;
    private Vector2 _direccion;

    // Variables para el suavizado
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  // Obtiene el Rigidbody2D del objeto
    }

    // Update es llamado una vez por frame
    void Update()
    {
        // Obtiene las entradas de movimiento del jugador
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        // Almacena la dirección del movimiento
        _direccion = new Vector2(x, y);
    }

    private void FixedUpdate()
    {
        // Aquí se suaviza el movimiento de la dirección
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _direccion,
            ref _movementInputSmoothVelocity,
            smoothTime);

        // Aplica el movimiento suavizado al Rigidbody2D
        rb.MovePosition(rb.position + _smoothedMovementInput * (speed * Time.fixedDeltaTime));
    }
}
