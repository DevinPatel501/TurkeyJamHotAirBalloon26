using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 2f;

    public bool isLeftToRight = true;
    Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
            if(!isLeftToRight)
        {
            speed = -speed;
        }
    }

    void FixedUpdate()
    {
    
        direction = new Vector2(speed, 0);
        rb.MovePosition(rb.position + direction * Time.fixedDeltaTime);
    }
}
