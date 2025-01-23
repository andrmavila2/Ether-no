using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento del Jugador")]
    [SerializeField] private Rigidbody2D rb;  // Referencia al Rigidbody2D
    [SerializeField] private int speed = 5;   // Velocidad base del jugador
    [SerializeField] private float smoothTime = 0.1f;  // Tiempo de suavizado

    private Vector2 _direccion;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    [Header("Dash")]
    public float dashSpeed = 10f;       // Velocidad adicional durante el dash
    public float dashLength = 0.5f;    // Duración del dash
    public float dashCooldown = 1f;   // Tiempo de espera entre dashes

    private float activeMoveSpeed;      // Velocidad activa actual
    private float dashCounter;          // Contador del tiempo restante del dash
    private float dashCoolCounter;      // Contador del cooldown del dash

    private void Awake()
    {
        // Inicializar referencias y variables
        rb = GetComponent<Rigidbody2D>();
        activeMoveSpeed = speed; // Velocidad activa inicial es la velocidad base
    }

    private void Update()
    {
        // Obtener las entradas del jugador (ejes de movimiento)
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        _direccion = new Vector2(x, y).normalized; // Normalizar la dirección

        // Manejar la entrada para el dash
        if (Input.GetKeyDown(KeyCode.Space) && dashCoolCounter <= 0 && dashCounter <= 0)
        {
            activeMoveSpeed += dashSpeed; // Incrementar velocidad para el dash
            dashCounter = dashLength;    // Iniciar el contador del dash
        }

        // Reducir los contadores del dash
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = speed;       // Restaurar velocidad base
                dashCoolCounter = dashCooldown; // Iniciar cooldown
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime; // Reducir cooldown
        }
    }

    private void FixedUpdate()
    {
        // Suavizar el movimiento
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _direccion,
            ref _movementInputSmoothVelocity,
            smoothTime
        );

        // Mover al jugador usando Rigidbody2D
        rb.MovePosition(rb.position + _smoothedMovementInput * (activeMoveSpeed * Time.fixedDeltaTime));
    }
}
