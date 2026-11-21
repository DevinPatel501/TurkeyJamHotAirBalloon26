using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 2f;
    public float buoyancyForce = 0f;

    private float xDirection;
    private float yDirection;

    public float propane = 100f;
    public float temperature = 50.2f;
    public float heatingRate = 8f;
    public float coolingRate = 3f;
    public float fuelConsumptionRate = 5f;

    public float minTemperature = 20f;
    public float maxTemperature = 100f;

    public float liftMultiplier = 0.13f;
    public float maxVerticalSpeed = 3f;

    public float burnerAngle = 0f;

    private bool burnerActive;

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
        // Heat balloon while holding W
        burnerActive = yDirection > 0 && propane > 0 && temperature < maxTemperature;

        if (burnerActive)
        {
            temperature += heatingRate * Time.fixedDeltaTime;
            propane -= fuelConsumptionRate * Time.fixedDeltaTime;
        }
        else
        {
            // Cool balloon when burner is off
            temperature -= coolingRate * Time.fixedDeltaTime;
        }

        // Update burner angle based on input
        burnerAngle = Mathf.Lerp(burnerAngle, xDirection * 45f, Time.fixedDeltaTime * 5f);

        // Prevent temperature and propane from exceeding limits
        temperature = Mathf.Clamp(temperature, minTemperature, maxTemperature);
        propane = Mathf.Max(0f, propane);
        burnerAngle = Mathf.Clamp(burnerAngle, -45f, 45f);

        // Horizontal movement
        float burnerAngleRadians = burnerAngle * Mathf.Deg2Rad;
        Vector2 burnerForce = new Vector2(
            Mathf.Sin(burnerAngleRadians),
            Mathf.Cos(burnerAngleRadians)
        ) * speed;

        // Buoyancy based on temperature
        buoyancyForce = (temperature - minTemperature) * liftMultiplier;

        Vector2 liftForce = new Vector2(0, buoyancyForce);

        // Apply forces
        if (burnerActive)
        {
            rb.AddForce(burnerForce);
        }
        rb.AddForce(liftForce);

        Vector2 velocity = rb.linearVelocity;

        velocity.y = Mathf.Clamp(
            velocity.y,
            -maxVerticalSpeed,
            maxVerticalSpeed
        );

        rb.linearVelocity = velocity;
    }
}