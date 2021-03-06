﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//player uses physics based movement to traverse. This will lead to hilarity and lots of bugs I will come to hate.

public class PlayerControl : MonoBehaviour
{
    [HideInInspector]
    public bool isRight = true; //which direction?
    [HideInInspector]
    public bool jump = false;   //can jump?

    public float moveForce = 365f;  //how much force is applied to player to cause movement
    public float maxSpeed = 5f; //x-axis maximum speed
    public float jumpForce = 10f; //force applied to make player jump up
    public float attackStrength = 1f;   //amount of damage player can do with attacks

    private Transform groundCheck;  //is grounded? as a transform
    public bool grounded = false;  //is grounded? internal state
    private Animator anim;  //will be useful for animations
    Rigidbody2D rb;

	private float attackTimer = 0;
	private float attackTime = 0.5f;
	private float attackDamage = 100.0f;
	private float attackDistance = 1.0f;

	[SerializeField] private AudioClip clip;

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
        
         if (Input.GetButtonDown("Jump")){
            jump = true;

        }
        
    }


    void FixedUpdate()
    {
		attackTimer += Time.deltaTime;

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

		// check if the player is close enough and if there is an attack button pressed
		if (Input.GetMouseButtonDown(0) && attackTimer >= attackTime)
		{
			attackTimer = 0;

			// then we use the EnemyManager class to check if there are any enemies near the player
			List<GameObject> list = new List<GameObject>();
			list = EnemyManager.GetInstance().GetObjectsCloseTo(transform.position, 15);

			// play our attack sound
			GetComponent<AudioSource>().Play();

			foreach (GameObject @object in list)
			{
				// since we know all of these objects are enemies, we cast the type
				Enemy enemy = @object.GetComponent<Enemy>();

				// if this object is in fact an enemy
				if (enemy != null)
				{
					// then we use the enemy OnDamage method
					enemy.OnDamage(attackDamage);

					Debug.Log("Enemy attacked");
				}
			}
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



