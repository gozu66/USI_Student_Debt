using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour
{
    Rigidbody2D rbody;
    Transform myt;
    Animator anim;

    public GameObject gib;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        myt = transform;
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Screen Edge")
        {
            StartCoroutine("TakeDamage", new Vector2(myt.position.x - other.transform.position.x, 0));            
        }
        else if(other.collider.tag == "Vehicle")
        {
            spawnEffects();
            StartCoroutine("TakeDamage", new Vector2(myt.position.x - other.transform.position.x, 1));
            DebtTracker._instance.CountTaxi();
            DebtTracker._instance.Cost(-25);
            other.collider.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Respawn")
        {
            Vector2 newPosition = Camera.main.transform.position;
            //newPosition
            newPosition.y = 0;
            newPosition.x -= 5f;
            myt.position = newPosition;
            FlashSprite();
        }
    }

    public float force;
    IEnumerator TakeDamage(Vector2 hitDir)
    {
        //Play Player sprite Flashing animation
        FlashSprite();

        playerMove.canMove = false;
        rbody.velocity = Vector2.zero;
        rbody.AddForce(hitDir * force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        playerMove.canMove = true;
    }

    void spawnEffects()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector2 newPos = new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));
            Instantiate(gib, newPos, Quaternion.identity);
        }

    }

    void FlashSprite()
    {
        anim.SetTrigger("Hurt");
        //anim.ResetTrigger("Hurt");
    }
}
