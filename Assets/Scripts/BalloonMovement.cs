
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;

    public float burnerForce = 5f;
    public float buoyancyForce = 2f;
    // public float propane = 100f;
    // public float fuelConsumptionRate = 5f;

    public float maxVerticalSpeed = 3f;
    public float upwardBraking = 2f;

    public float burnerAngle = 0f;
    public GameObject burner;

    private float xDirection;
    private float yDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xDirection = Input.GetAxisRaw("Horizontal");
        yDirection = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;

        bool burnerActive = yDirection > 0 ;
        // && propane > 0;

        // Rotate burner using A/D
        burnerAngle = Mathf.Lerp(
            burnerAngle,
            xDirection * 45f,
            dt * 5f
        );

        burner.transform.localRotation =
            Quaternion.Euler(0, 0, -burnerAngle);

        // Constant passive buoyancy
        rb.AddForce(Vector2.up * buoyancyForce);

        if (burnerActive)
        {
            // propane -= fuelConsumptionRate * dt;
            // propane = Mathf.Max(0f, propane);

            float radians = burnerAngle * Mathf.Deg2Rad;

            Vector2 direction = new Vector2(
                Mathf.Sin(radians),
                Mathf.Cos(radians)
            );

            rb.AddForce(direction * burnerForce);
        }
        else if (rb.linearVelocity.y > 0)
        {
            // Gradually slow upward movement
            rb.AddForce(Vector2.down * upwardBraking);
        }

        // Limit vertical velocity
        Vector2 velocity = rb.linearVelocity;

        velocity.y = Mathf.Clamp(
            velocity.y,
            -maxVerticalSpeed,
            maxVerticalSpeed
        );

        rb.linearVelocity = velocity;
    }
}
