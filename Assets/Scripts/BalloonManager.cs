using UnityEngine;

public class BalloonManager : MonoBehaviour
{
    public float health = 10f;

    public GameObject basket;
    public float maxAngle = 30f;

    public LayerMask enemyLayer;
    void Start()
    {

    }

    void Update()
    {

        float currentAngle = Mathf.DeltaAngle(basket.transform.rotation.eulerAngles.z, 0f);
        if (health <= 0)
        {
            // Handle balloon destruction or game over logic here
            Debug.Log("Balloon destroyed!");
        }
        else if (Mathf.Abs(currentAngle) > maxAngle)
        {
            Debug.Log("Balloon is tipping over!" + currentAngle);
        }
        else
        {
            Debug.Log("Balloon is stable.");

        }
    }

   private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Bird"))
    {
        health -= 1f;
        Debug.Log("Balloon has taken damage. Health: " + health);
    }
}
}
