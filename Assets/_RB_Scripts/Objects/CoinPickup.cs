using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour
{
    public int value;
    public AudioClip pickup;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            spawnEffects();
            DebtTracker._instance.Cost(value);
            DebtTracker._instance.AddTotalCoins();
            //AudioSource audioS = this.GetComponent<AudioSource>();
            //audioS.PlayOneShot(pickup);
            AudioSource.PlayClipAtPoint(pickup, this.transform.position);
            //this.GetComponent<AudioSource>().enabled = true;
            Destroy(gameObject);
        }
    }

    void spawnEffects()
    {
        /*
        for(int i = 0; i < 5; i++)
        {
            Vector2 newPos = new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));
            Instantiate(gib, newPos, Quaternion.identity);
        }
        */

        //Spawn Particle fx
    }
}