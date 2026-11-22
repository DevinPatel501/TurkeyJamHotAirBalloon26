using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonManager : MonoBehaviour
{
    public float health = 10f;

    public GameObject basket;
    public float maxAngle = 30f;

    public LayerMask enemyLayer;

    public GameManager gameManager;


    void Start()
    {

    }

    void Update()
    {

        float currentAngle = Mathf.DeltaAngle(basket.transform.rotation.eulerAngles.z, 0f);
        if (health <= 0)
        {
            gameManager.LoseGame();
            // Debug.Log("Balloon destroyed!");
        }
        else if (Mathf.Abs(currentAngle) > maxAngle)
        {
            Debug.Log("Balloon is tipping over!" + currentAngle);
        }
        else
        {
            // Debug.Log("Balloon is stable.");

        }
    }

   private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Bird"))
    {
        health -= 1f;
        Debug.Log("Balloon has taken damage. Health: " + health);
    }
    else if(other.CompareTag("Ship")){
        gameManager.WinGame();
    }
    else if(other.CompareTag("Bounds")){
        gameManager.LoseGame();
    }
}
}
