using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

    public short speed;
    public short jumpForce;

    private Rigidbody2D rbody;

	void Start () {
        rbody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

        Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal"), 0);

        if(inputDirection.sqrMagnitude != 0)
        {
            Vector2 newVelocity = new Vector2(inputDirection.x * speed, rbody.velocity.y);
            rbody.velocity = newVelocity;
        }

        if (Input.GetButtonDown("Jump"))
        {
            rbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
        }
	}
}
