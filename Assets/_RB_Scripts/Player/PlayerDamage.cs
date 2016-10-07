using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour
{
    Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Screen Edge")
        {
            StartCoroutine("ScreenEdgeDamage");
        }
    }

    public float force;
    IEnumerator ScreenEdgeDamage()
    {
        //Make palyer sprite flash opacity
        playerMove.canMove = false;
        rbody.velocity = Vector2.zero;
        rbody.AddForce((Vector2.right) * force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1);
        playerMove.canMove = true;
    }
}
