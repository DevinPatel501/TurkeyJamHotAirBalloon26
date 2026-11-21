using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
   public float speed = 0.1f; 
   private Rigidbody2D rb;

   public float gravMag = 0.2f;

    private float xDirection;
    private float yDirection;
   
  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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



        Vector2 gravityForce = new Vector2(0, gravMag);

        Vector2 totalForce = moveDirection - gravityForce;

        rb.AddForce(totalForce);

    }
}
