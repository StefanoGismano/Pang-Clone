using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;
    Rigidbody2D rb;
    Animator animator;
    bool isOnLadder;
    float originalGravity = 15f;
    float SpeedUpDuration = 5.0f;

    // Mobile control variables
    private float mobileMoveX = 0f;
    private float mobileMoveY = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isOnLadder = false;
        originalGravity = rb.gravityScale;

    }

    // Update is called once per frame
    void Update()
    {
        float moveInputX = Input.GetAxisRaw("Horizontal");
        float moveInputY = Input.GetAxisRaw("Vertical");

        // Combine keyboard and mobile input
        float finalX = moveInputX + mobileMoveX;
        float finalY = moveInputY + mobileMoveY;

        if (finalX != 0 && isOnLadder == false)
        {
            rb.linearVelocity = new Vector2(finalX * moveSpeed, rb.linearVelocity.y);
            if (finalX < 0)
            {
                transform.localRotation = new Quaternion(0, 0, 0, 0);
            }
            else if (finalX > 0)
            {
                transform.localRotation = new Quaternion(0, 180, 0, 0);
            }
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsClimbing", false);

        }
        else if (( finalX != 0 || finalY != 0) && isOnLadder == true) 
        {
            rb.linearVelocity = new Vector2(finalX * moveSpeed, finalY * moveSpeed);
            if(finalY != 0)
                animator.SetBool("IsClimbing", true);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsClimbing", false);
        }
    }

    // Methods for UI buttons
    public void MoveLeft(bool isPressed) => mobileMoveX = isPressed ? -1f : 0f;
    public void MoveRight(bool isPressed) => mobileMoveX = isPressed ? 1f : 0f;
    public void MoveUp(bool isPressed) => mobileMoveY = isPressed ? 1f : 0f;
    public void MoveDown(bool isPressed) => mobileMoveY = isPressed ? -1f : 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            rb.gravityScale = 0;
            isOnLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            rb.gravityScale = originalGravity;
            isOnLadder = false;
        }
    }

    IEnumerator WaitDuration(float duration)
    {
        moveSpeed = 10;
        yield return new WaitForSeconds(duration);
        moveSpeed = 5;
    }

    public void SpeedUp()
    {
        StartCoroutine(WaitDuration(SpeedUpDuration));
    }
}
