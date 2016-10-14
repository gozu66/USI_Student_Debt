using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour
{
    public int value;
    public AudioClip pickup;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Coin")
        {
            DebtTracker._instance.Cost(value);
            DebtTracker._instance.AddTotalCoins();
            AudioSource.PlayClipAtPoint(pickup, this.transform.position);
            Destroy(other.gameObject);
        }
    }

    void spawnEffects()
    {
        //Spawn Particle fx
    }
}