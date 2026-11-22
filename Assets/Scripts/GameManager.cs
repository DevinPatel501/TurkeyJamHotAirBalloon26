using UnityEngine;

public class GameManager : MonoBehaviour
{


    private GameState currentState;
    void Start()
    {
        currentState = GameState.Playing;
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void WinGame()
    {
        if(currentState == GameState.Playing)
        {
            currentState = GameState.Won;
            Debug.Log("You won the game!");
        }
    }
   public void LoseGame()
    {
        if(currentState == GameState.Playing)
        {
            currentState = GameState.Lost;
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
