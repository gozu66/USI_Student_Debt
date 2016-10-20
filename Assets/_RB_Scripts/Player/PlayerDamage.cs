﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    Rigidbody2D rbody;
    Transform myt;
    Animator anim;
    Transform cameraTransform;

    public int coinValue;

    AudioSource source;
    public AudioClip pickup;

    public AudioClip damageAudio, rentAudio, taxiAudio;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        myt = transform;
        anim = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
        rbody.AddForce(new Vector2(35, 35), ForceMode2D.Impulse);
        source = GetComponent<AudioSource>();
        source.clip = damageAudio;
        source.Play();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Screen Edge")
        {
            StartCoroutine(TakeDamage(new Vector2(myt.position.x - other.transform.position.x, 0), true));
            source.clip = taxiAudio;
            source.Play();
        }
        else if (other.collider.tag == "Vehicle")
        {
            spawnEffects("Transport!\n-€50");
            source.clip = taxiAudio;
            source.Play();
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
            source.clip = rentAudio;
            source.Play();

        }
        if (other.tag == "Coin")
        {
            DebtTracker._instance.Cost(coinValue);
            DebtTracker._instance.AddTotalCoins();
            source.clip = pickup;
            source.Play();
            Destroy(other.gameObject);
        }
        else if (other.tag == "Bank")
        {
            StartCoroutine(TakeDamage(new Vector2(0, 0), false));
            other.GetComponent<Collider2D>().enabled = false;
            DebtTracker._instance.Cost(-200);
            DebtTracker._instance.StopAllCoroutines();
            DebtTracker._instance.StartCoroutine("FadeText");
            spawnEffects("Interest!\n-€200");
            source.clip = rentAudio;
            source.Play();
        }
        else if(other.tag == "Pub")
        {
            StartCoroutine(TakeDamage(new Vector2(0, 0), false));
            other.GetComponent<Collider2D>().enabled = false;
            DebtTracker._instance.Cost(-150);
            DebtTracker._instance.StopAllCoroutines();
            DebtTracker._instance.StartCoroutine("FadeText");
            spawnEffects("Drinks!\n-€150");
            source.clip = rentAudio;
            source.Play();
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
        GameObject blip = Instantiate(infoItem, transform.position, Quaternion.identity)as GameObject;        
        TextMesh tm = blip.GetComponent<TextMesh>();
        tm.text = damType;
    }

    void FlashSprite()
    {
        anim.SetTrigger("Hurt");
    }
}
