using UnityEngine;
using System.Collections;

public class Vehicles : MonoBehaviour
{
    Rigidbody2D rbody;
    public float speed = 100;
    bool isAwake;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (isAwake)
        {
            rbody.AddForce(-transform.right * speed, ForceMode2D.Force);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Wake Up" )
        {
            isAwake = true;
            this.GetComponent<AudioSource>().enabled = true;
        }
        else if(other.tag == "Cull")
        {
            Destroy(gameObject);
        }
    }
}