using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerMovement playerMove;
    private InputAction moveAction;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Collider2D collider;

    [SerializeField]
    private Vector2 moveDirection;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    public ContactFilter2D movementFilter;

    void OnEnable() {
        playerMove.Enable();
    }

    void OnDisable() {
        playerMove.Disable();

        moveAction.performed -= OnMove;
    }

    void Awake() {
        playerMove = new PlayerMovement();
        
        moveAction = playerMove.Player.Move;
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        playerData = GetComponent<PlayerData>();
    }

    void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (moveDirection != Vector2.zero) {
            bool success = checkCollision(moveDirection);

            if (!success) {
                success = checkCollision(new Vector2(moveDirection.x, 0));
            }

            if (!success) {
                success = checkCollision(new Vector2(0, moveDirection.y));
            }
        }
    }

    private bool checkCollision(Vector2 direction)
    {
        int collideCount = rb.Cast(
            direction,
            movementFilter,
            castCollisions,
            playerData.moveSpeed * Time.fixedDeltaTime + playerData.collisionOffset
        );

        if (collideCount == 0) {
            rb.MovePosition(rb.position + direction * playerData.moveSpeed * Time.fixedDeltaTime);
            return true;
        }
            
        return false;
    }

    #region Player Input Actions
    private void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed) {
            moveDirection = moveAction.ReadValue<Vector2>();
        }
        if (context.canceled) {
            moveDirection = Vector2.zero;
        }
    }
    #endregion
}
