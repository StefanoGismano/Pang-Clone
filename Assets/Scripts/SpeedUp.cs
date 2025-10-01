using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            CharacterMovement cf = collision.gameObject.GetComponent<CharacterMovement>();
            cf.SpeedUp();
            Destroy(gameObject);
        }
    }
}
