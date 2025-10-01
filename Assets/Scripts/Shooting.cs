using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    Animator animator;

    private bool mobileShoot = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate the object at the spawn position with no rotation
            Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
            animator.SetTrigger("Shoot");
        }

        if (mobileShoot)
        {
            Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
            mobileShoot = false; // One shot per press
            animator.SetTrigger("Shoot");
        }
    }

    // UI Button method
    public void MobileShoot()
    {
        Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
    }

}
