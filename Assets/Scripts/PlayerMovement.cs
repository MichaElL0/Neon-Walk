using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    private float moveInput;
    public float jumpForce;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Animator animator;

    public int jumpDirectionValue = 1;

    public GameObject something;

    // Start is called before the first frame update
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
       
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveInput == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
		{
            animator.SetBool("isRunning", true);
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
		{
            rb.velocity = new Vector2(0, jumpDirectionValue) * jumpForce;
            FindObjectOfType<AudioManager>().Play("Jump");
        }

        if(isGrounded == true)
		{
            animator.SetBool("isJumping", false);
		}
        else
		{
            animator.SetBool("isJumping", true);
        }
    }

	private void FixedUpdate()
	{
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        //Get input values and move character
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        

        if (facingRight == false && moveInput > 0)
		{
            Flip();
		}
        else if (facingRight == true && moveInput < 0)
		{
            Flip();
        }

        //---------------------------------


    }

    void Flip()
	{
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler; 
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "something")
		{
            Destroy(something);
		}
	}
}
