using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] public float initialDirection = 1.0f;
    [SerializeField] float initialSpeed = 5.0f;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(initialSpeed*initialDirection, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
