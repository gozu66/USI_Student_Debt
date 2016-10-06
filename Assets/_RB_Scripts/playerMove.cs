using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour 
{
	public float maxSpeed, jumpForce;

	bool isMoving, facingLeft, jumpPressed = false, onSlope;

	//public LayerMask ground;
	//public Transform groundcheck;

    Rigidbody2D rBody;
    Collider2D col;

	public float range;

	void Start ()
	{
        rBody = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        InvokeRepeating("checkGround", 0.0025f, 0.0025f);
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0) { isMoving = true; } else { isMoving = false; }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            jump();
        }
        else
        {
            jumpPressed = false;
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            float move = Input.GetAxis("Horizontal");

            rBody.velocity = new Vector2(move * maxSpeed, rBody.velocity.y);   

            if (move > 0 && facingLeft)
                Flip();
            else if (move < 0 && !facingLeft)
                Flip();
        }			
	}

	void Update()
	{
        //Ray groundCheckRay;
        //RaycastHit2D hit;

        //if(Physics2D.Raycast(transform.position, -Vector2.up, hit))
        //RaycastHit2D hit = Physics2D.Linecast()
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
		if(isGrounded)
		{
            rBody.AddForce((Vector2.up * jumpForce), ForceMode2D.Force);
			jumpPressed = true;
		}
	}

    bool isGrounded;
    void checkGround()
    {
        Collider2D[] _ground = new Collider2D[1];
        Physics2D.OverlapAreaNonAlloc(col.bounds.max, col.bounds.min, _ground);

        foreach (Collider2D _col in _ground)
        {
            if (_col != null && !_col.isTrigger)
            {
                isGrounded = true;
            } else {
                isGrounded = false;
            }
        }
    }

}