using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 2f;
    Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        direction = new Vector2(speed, 0);
        rb.MovePosition(rb.position + direction * Time.fixedDeltaTime);
    }
}
