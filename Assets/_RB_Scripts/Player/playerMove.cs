using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour 
{
	public float maxSpeed, airControlSpeed, jumpForce;
    private float currentSpeed;

    bool isMoving, facingLeft, jumpPressed = false, onSlope;

    Rigidbody2D rBody;
    Collider2D col;

    public LayerMask layerMask;

    public static bool canMove = true;

    void Start ()
	{
        rBody = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
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
            rBody.AddForce((Vector2.up * jumpForce), ForceMode2D.Impulse);
			jumpPressed = true;
		}
	}    
}