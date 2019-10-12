using UnityEngine;
using System.Collections;

//player uses physics based movement to traverse. This will lead to hilarity and lots of bugs I will come to hate.

public class PlayerControl : MonoBehaviour
{
    [HideInInspector]
    public bool isRight = true; //which direction?
    [HideInInspector]
    public bool jump = false;   //can jump?

    public float moveForce = 365f;  //how much force is applied to player to cause movement
    public float maxSpeed = 5f; //x-axis maximum speed
    public float jumpForce = 1000f; //force applied to make player jump up
    public float attackStrength = 1f;   //amount of damage player can do with attacks

    private Transform groundCheck;  //is grounded? as a transform
    public bool grounded = false;  //is grounded? internal state
    private Animator anim;  //will be useful for animations
    Rigidbody2D rb;

    void Awake()
    {
        //Setup
        groundCheck = transform.Find("groundCheck");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground") && Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
    */
    void Update()
    {
        //Is grounded if a linecast hits anything on the ground layer.
        //grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("ground"));
        grounded = Physics2D.Linecast(transform.position, new Vector2(transform.position.x, transform.position.y - 5), 1 << LayerMask.NameToLayer("Ground"));


        //If jump button is pressed and the player is grounded then jump.
        
         if (Input.GetButtonDown("Jump") && grounded){
            jump = true;
        }
        
    }


    void FixedUpdate()
    {
        //horizontal input
        float h = Input.GetAxis("Horizontal");

        //get absolute value for animation speed
        anim.SetFloat("Speed", Mathf.Abs(h));

        // if velocity is less than max speed then accelerate
        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed){
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);
        }

        // If velocity is greater than max speed then set to max speed
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed){
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        // If the input is moving right, flip to right direction
        if (h > 0 && !isRight)
        {
            Flip();
        }
        // If the input is moving left, flip to left direction
        else if (h < 0 && isRight){
            Flip();
        }

        // jumping
        if (jump)
{
            //animation
            anim.SetTrigger("Jump");
            //
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }


    void Flip()
    {
        // It works trust me
        isRight = !isRight;

        // Do some scaling
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public float GetXPosition()
    {
        return transform.position.x;
    }
}



