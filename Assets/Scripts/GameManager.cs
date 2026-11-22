using UnityEngine;

public class GameManager : MonoBehaviour
{


    private GameState currentState;

    public GameObject winPanel;
    public GameObject losePanel;

    public AudioClip lose;
    public AudioClip win;
     AudioSource endNoise;
    void Start()
    {
        currentState = GameState.Playing;
        endNoise = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        bool isRestarting = Input.GetKeyDown(KeyCode.R);
        if (isRestarting && currentState != GameState.Playing)
        {
            restartGame();
        }
    }

    void restartGame()
    {
        Time.timeScale = 1f;

        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
    public void WinGame()
    {
        if (currentState == GameState.Playing)
        {
            currentState = GameState.Won;
            Time.timeScale = 0f;
            endNoise.PlayOneShot(win);

            winPanel.SetActive(true);
            Debug.Log("You won the game!");

        }

    }
    public void LoseGame()
    {

        if (currentState == GameState.Playing)
        {
            endNoise.PlayOneShot(lose);
            currentState = GameState.Lost;
            Time.timeScale = 0f;

            losePanel.SetActive(true);
            Debug.Log("You lost the game!");

        }


    }
    public enum GameState
    {
        Playing,
        Won,
        Lost
    }
}
