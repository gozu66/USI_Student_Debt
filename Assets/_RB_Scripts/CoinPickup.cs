using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour
{
    int value = 200;
    public GameObject gib;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            print("???");
            spawnEffects();
            Destroy(gameObject);
        }
    }

    void spawnEffects()
    {
        for(int i = 0; i < 5; i++)
        {
            Vector2 newPos = new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));
            Instantiate(gib, newPos, Quaternion.identity);
        }
        
    }
}