using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 2f;

    public bool isLeftToRight = true;

    public float minX = -3f;
    public float maxX = 3f;

    public AudioClip enemySound;

    private SpriteRenderer spriteRenderer;

    Vector2 direction;

    AudioSource audioSource;

    private bool hasPlayedSound = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        audioSource = GetComponent<AudioSource>();

    }

    void FixedUpdate()
    {

        if (spriteRenderer.isVisible&&!hasPlayedSound)
        {
            audioSource.PlayOneShot(enemySound);
            hasPlayedSound = true;
        }
        direction = new Vector2(isLeftToRight ? speed : -speed, 0f);
        rb.MovePosition(rb.position + direction * Time.fixedDeltaTime);



        if (transform.position.x < minX || transform.position.x > maxX)
        {
            Destroy(gameObject);
        }
    }
}
