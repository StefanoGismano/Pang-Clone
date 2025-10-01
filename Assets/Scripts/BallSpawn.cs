using TMPro;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    [SerializeField] GameObject ballChild;
    public GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            if (ballChild != null)
            {
                GameObject leftBall = Instantiate(ballChild, new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y), Quaternion.identity);
                BallMovement leftBallMovement = leftBall.GetComponent<BallMovement>();
                leftBallMovement.initialDirection = -1.0f;
                BallSpawn leftBallSpawn = leftBall.GetComponent<BallSpawn>();
                leftBallSpawn.gameManager = gameManager;    
                GameObject rightBall = Instantiate(ballChild, new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y), Quaternion.identity);
                BallMovement rightBallMovement = rightBall.GetComponent<BallMovement>();
                rightBallMovement.initialDirection = 1.0f;
                BallSpawn rightBallSpawn = rightBall.GetComponent<BallSpawn>();
                rightBallSpawn.gameManager = gameManager;
            }
            gameManager.ballDestroyed();
            Destroy(gameObject);
        }
    }
}
