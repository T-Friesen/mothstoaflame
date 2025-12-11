using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Player player;
    private Vector2 movementInput;
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        player = new Player();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        player.Enable();
    }

    private void OnDisable()
    {
        player.Disable();
    }

    void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        movementInput = player.Movement.Move.ReadValue<Vector2>();

        // Clamp to a maximum magnitude of 1 so diagonal movement isn't faster
        if (movementInput.sqrMagnitude > 1f)
        {
            movementInput = movementInput.normalized;
        }
    }

    private void Move()
    {
        Vector2 movement = movementInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
