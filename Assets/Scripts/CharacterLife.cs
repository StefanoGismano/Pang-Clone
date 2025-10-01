using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CharacterLife : MonoBehaviour
{
    [SerializeField] int maxLife = 3;
    public int currentLife;
    public TextMeshProUGUI hpText;
    public GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLife = maxLife;
        hpText.text = "HP: " + currentLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.layer == 9) 
        {
            currentLife--;
            hpText.text = "HP: " + currentLife;
            if (currentLife <= 0) {
                gameManager.Lose();
                Destroy(gameObject);
            }
        }
    }

    public void HealthUp()
    {
        currentLife++;
        hpText.text = "HP: " + currentLife;
    }
}
