using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour 
{
	float maxSpeed = 10, airControlSpeed = 6, jumpForce = 140;
    private float currentSpeed;

    bool isMoving, facingLeft, jumpPressed = false, onSlope;

    Rigidbody2D rBody;
    Collider2D col;

    public LayerMask layerMask;

    public static bool canMove = true;

    Animator animator;
    public AudioClip jumpAudio;
    AudioSource[] sources;
    AudioSource footstepSource, jumpSource;

    Transform cameraTransform;

    void Start ()
	{
        rBody = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
        sources = GetComponents<AudioSource>();
        footstepSource = sources[0];
        jumpSource = sources[1];
        jumpSource.clip = jumpAudio;
    }

    void Update()
    {
        animator.SetBool("Grounded", GroundChecker.playerIsGrounded);
        animator.SetBool("Moving", isMoving);
        if(canMove)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                jump();
            }
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            {
                jumpPressed = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        if (canMove)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                float move = Input.GetAxis("Horizontal");
                rBody.velocity = new Vector2(move * currentSpeed, rBody.velocity.y);            
                if (move > 0 && facingLeft)
                {
                    Flip();
                }
                else if (move < 0 && !facingLeft)
                {
                    Flip();
                }
            }
        }
        currentSpeed = (GroundChecker.playerIsGrounded) ? maxSpeed : airControlSpeed;
    }

	void Flip()
	{
		facingLeft = !facingLeft;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}

	void jump()
	{
		if(GroundChecker.playerIsGrounded)
		{
            animator.SetTrigger("Jump");
            //AudioSource.PlayClipAtPoint(jumpAudio, transform.position);
            jumpSource.Play();
            rBody.AddForce((Vector2.up * jumpForce), ForceMode2D.Impulse);
			jumpPressed = true;
		}
	}

    public AudioClip[] footSteps;
    void Footstep()
    {
        footstepSource.clip = footSteps[Random.Range(0, footSteps.Length)];
        footstepSource.Play();
    }
}