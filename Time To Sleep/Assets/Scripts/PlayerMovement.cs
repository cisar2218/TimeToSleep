using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpingPower = 5f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    
    [SerializeField] Animator animator;

    public float horizontal;

    private void FixedUpdate()
    {
        bool movingLeft = horizontal < -0.01f;
        bool movingRight = horizontal > 0.01f;
        bool isMoving = movingLeft || movingRight;
        if (movingRight)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movingLeft)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        if (isMoving && IsGrounded()) {
            animator.SetBool("walking", true);
        } else
        {
            animator.SetBool("walking", false);
        }

        rb.linearVelocityX = horizontal * speed;
    }   

    public void Move(InputAction.CallbackContext context) {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context) {
        if (context.performed && IsGrounded()) {
            rb.linearVelocityY = jumpingPower;
            animator.SetTrigger("Jump");
        }
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.5f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
}
