using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpingPower = 5f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;

    public float horizontal;

    private void FixedUpdate()
    {
        rb.linearVelocityX = horizontal * speed;
    }   

    public void Move(InputAction.CallbackContext context) {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context) {
        if (context.performed && IsGrounded()) {
            rb.linearVelocityY = jumpingPower;
        }
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.75f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
}
