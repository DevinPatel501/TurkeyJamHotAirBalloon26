using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
   private Rigidbody2D rb;



   
   public GameObject balloon;
   public GameObject basket;

   public float balloonMass = 1f;
   public float basketMass = 6f;

   public float speed = 0.1f; 

   public float gravMag = 0.2f;

    private float xDirection;
    private float yDirection;

    private Vector2 centerOfMassOffset;
   
  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        centerOfMassOffset = 
        ((balloonMass * balloon.transform.localPosition) + (basketMass * basket.transform.localPosition) )/ 
        (balloonMass + basketMass);

        rb.centerOfMass = centerOfMassOffset;
    }


    // Update is called once per frame
    void Update()
    {
         xDirection = Input.GetAxisRaw("Horizontal");
         yDirection= Input.GetAxisRaw("Vertical");


    }

    void FixedUpdate()
    {
        
        Vector2 moveDirection = new Vector2(xDirection,yDirection).normalized * speed;



        Vector2 gravityForce = new Vector2(0, -gravMag);

        Vector2 totalForce = moveDirection - gravityForce;

        rb.AddForceAtPosition(moveDirection, balloon.transform.position);
        rb.AddForce(gravityForce);

    }
}
