using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private float facing;
    private Rigidbody rb;

    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private bool canJump;
    private bool doubleJump;
    private int countJump;

    public SoundManager sound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * 
         //Store user input as a movement vector
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        rb.MovePosition(transform.position + m_Input * Time.deltaTime * speed);
        
         */

        float moveH = Input.GetAxis("Horizontal") * speed;
        float moveV = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(moveH, 0, moveV);

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        //rb.velocity = movement * speed;
        //Vector3 direction = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        //rb.MoveRotation(Quaternion.LookRotation(direction));

        if (movement.x != 0 || movement.z != 0)
        {
            facing = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            rb.rotation = Quaternion.Euler(0, facing, 0);

        }
        // sound walk
        if (Input.GetButton("Horizontal")|| Input.GetButton("Vertical"))
        {
            sound.walk.enabled = true;
        }
        else
        {
            sound.walk.enabled = false;

        }
        //another way but work only with (wasd)
        //Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)

        bool grounded = Physics.Linecast(transform.position, groundCheck.position, groundLayer);

        Debug.DrawLine(transform.position, groundCheck.position, Color.red);

        //sound jump (after jump)
        if (grounded ==true && countJump >= 1)
        {
            sound.PlayJump();

        }
        if (grounded == true)
        {
            countJump = 0;
            doubleJump = false;
            canJump = true;
        }
        else
        {
            doubleJump = true;
            //canJump = false;
        }

        ////Keys
        //bool jump = Input.GetKeyDown(KeyCode.Space);

        ////Statics
        //bool isGrounded = Physics.CheckSphere(groundDetector.position, 0.1f, ground);
        //bool isJumping = jump && isGrounded;
        //bool isSneaking = sneak;
        //bool isSliding = !isSneaking && slide && !slideing && !slideStop && isGrounded;

        //if (isGrounded)
        //{
        //    print("vallah");
        //    jumpCount = 0;
        //}
        //if (isJumping && (jumpCount <= 2) && !isSliding && !isSneaking)// HERE <--
        //{
        //    // Increase Jump Count
        //    jumpCount++;

        //    // First check the jump number
        //    if (jumpCount == 1)
        //    {
        //        rig.AddForce(Vector3.up * jumpForce);
        //    }
        //    else if (jumpCount == 2)
        //    {
        //        rig.AddForce(Vector3.up * secondJunp);
        //    }
        //}

        Jump();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && canJump == true && countJump <= 2)
        {
            countJump++;

            if (countJump == 1)
            {
                rb.AddForce(Vector3.up * jumpForce);

            }
            else if (countJump == 2 && doubleJump == true)
            {
                doubleJump = false;
                rb.AddForce(Vector3.up * jumpForce);
            }
            canJump = false;

        }

    }
}
