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
    }

    private void Move()
    {
        Vector2 movement = movementInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
