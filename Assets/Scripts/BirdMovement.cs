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

    }

    void FixedUpdate()
    {
        direction = new Vector2(isLeftToRight ? speed : -speed, 0f);
        rb.MovePosition(rb.position + direction * Time.fixedDeltaTime);

        if(transform.position.x < -9.5 || transform.position.x > 28)
        {
            Destroy(gameObject);
        }
    }
}
