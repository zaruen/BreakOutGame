using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Lives = 3;
    public int Bricks = 20;
    public float ResetDelay = 1f;
    public Text LivesText;
    public GameObject GameOver;
    public GameObject WinText;
    public GameObject BricksPrefab;
    public GameObject Paddle;
    public GameObject DeathParticles;
    public static GameManager Instance = null;

    private GameObject clonePaddle;

	// Use this for initialization
	void Start () {
	    if (Instance == null)
	    {
	        Instance = this;
	    }
	    else
	    {
	        Destroy(gameObject);
	    }
        Setup();
	}

    public void Setup()
    {
        //var bricksPosition = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        var paddlePosition = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        //Quaternion.identity : so no rotation
        clonePaddle = Instantiate(Paddle, paddlePosition, Quaternion.identity) as GameObject;
        //Instantiate(BricksPrefab, bricksPosition, Quaternion.identity);
    }

    void CheckGameOver()
    {
        if (Bricks < 1)
        {
            WinText.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", ResetDelay); // Invoke function with delay
        }

        if (Lives < 1)
        {
            GameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", ResetDelay); // Invoke function with delay
        }
    }

    void Reset()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoseLife()
    {
        Lives --;
        LivesText.text = "Lives: " + Lives;
        Instantiate(DeathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", ResetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(Paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        Bricks --;
        CheckGameOver();
    }
}
