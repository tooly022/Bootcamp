using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private float facing;
    private Rigidbody rb;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private bool canJump;

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

        //rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        rb.velocity = movement * speed;
        Vector3 direction = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        rb.MoveRotation(Quaternion.LookRotation(direction));

        /*if (movement.x != 0 || movement.z != 0)
        {
            facing = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            rb.rotation = Quaternion.Euler(0, facing, 0);

        }
        */

        bool grounded = Physics.Linecast(transform.position, groundCheck.position, groundLayer);

        Debug.DrawLine(transform.position, groundCheck.position, Color.red);

        if (grounded == true)
            canJump = true;
        else
            canJump = false;

        Jump();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            canJump = false;
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
