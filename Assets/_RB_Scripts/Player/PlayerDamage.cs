using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    Rigidbody2D rbody;
    Transform myt;
    Animator anim;

    //AudioSource aSource;
    public AudioClip damageAudio, rentAudio, taxiAudio;

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
            StartCoroutine(TakeDamage(new Vector2(myt.position.x - other.transform.position.x, 0), true));
            AudioSource.PlayClipAtPoint(damageAudio, transform.position);
        }
        else if(other.collider.tag == "Vehicle")
        {
            spawnEffects("Transport!\n-€50");
            AudioSource.PlayClipAtPoint(taxiAudio, transform.position);
            StartCoroutine(TakeDamage(new Vector2(myt.position.x - other.transform.position.x, 1), true));
            DebtTracker._instance.CountTaxi();
            DebtTracker._instance.Cost(-50);
            other.collider.isTrigger = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Respawn")
        {
            Vector2 newPosition = Camera.main.transform.position;
            newPosition.y = 0;
            newPosition.x -= 5f;
            myt.position = newPosition;
            FlashSprite();
        }
        else if (other.tag == "Home")
        {
            StartCoroutine(TakeDamage(new Vector2(0, 0), false));
            other.GetComponent<Collider2D>().enabled = false;
            DebtTracker._instance.Cost(-950);
            DebtTracker._instance.StopAllCoroutines();
            DebtTracker._instance.StartCoroutine("FadeText");
            spawnEffects("Rent!\n-€950");
            AudioSource.PlayClipAtPoint(rentAudio, transform.position);
        }
    }

    public float force;
    IEnumerator TakeDamage(Vector2 hitDir, bool haltPlayer)
    {
        FlashSprite();

        if(haltPlayer)playerMove.canMove = false;

        rbody.velocity = Vector2.zero;
        rbody.AddForce(hitDir * force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);

        playerMove.canMove = true;
    }

    public GameObject infoItem;
    void spawnEffects(string damType)
    {
        /*
        for (int i = 0; i < 5; i++)
        {
            Vector2 newPos = new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));
            Instantiate(gib, newPos, Quaternion.identity);
        }
        */

        GameObject blip = Instantiate(infoItem, transform.position, Quaternion.identity)as GameObject;        
        TextMesh tm = blip.GetComponent<TextMesh>();
        tm.text = damType;

    }

    void FlashSprite()
    {
        anim.SetTrigger("Hurt");
        //anim.ResetTrigger("Hurt");
    }

}
