using UnityEngine;

public class GameManager : MonoBehaviour
{


    private GameState currentState;

    public GameObject winPanel;
    public GameObject losePanel;
    void Start()
    {
        currentState = GameState.Playing;
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

            winPanel.SetActive(true);
            Debug.Log("You won the game!");

        }

    }
    public void LoseGame()
    {

        if (currentState == GameState.Playing)
        {
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
