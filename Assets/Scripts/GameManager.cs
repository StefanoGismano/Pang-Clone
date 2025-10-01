using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] int ballsToDestroy = 2;
    public TextMeshProUGUI WinScreen;
    public TextMeshProUGUI LoseScreen;
    public GameObject mobileCanvas;
    private int totalBalls;


    void Start()
    {

        totalBalls = 7 * ballsToDestroy;

        //On start check if we are on mobile to show the UI
#if UNITY_ANDROID || UNITY_IOS
            mobileCanvas.SetActive(true);
#else
        mobileCanvas.SetActive(false);
#endif
    }

    private void Update()
    {
        if(totalBalls <= 0)
        {
            StartCoroutine(Win(3));
        }
    }

    IEnumerator Win(float duration)
    {
        WinScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(0);
    }

    IEnumerator LoseWait()
    {
        LoseScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }

    public void ballDestroyed()
    {
        totalBalls--;
    }

    public void Lose()
    {
        StartCoroutine(LoseWait());
    }
}
