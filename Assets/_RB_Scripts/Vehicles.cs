﻿using UnityEngine;
using System.Collections;

public class Vehicles : MonoBehaviour
{
    Rigidbody2D rbody;
    float speed = 100;

    bool isAwake;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (isAwake)
        {
            rbody.AddForce(Vector2.left * speed, ForceMode2D.Force);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Wake Up")
        {
            isAwake = true;
        }
        else if(other.tag == "Cull")
        {
            Destroy(gameObject);
        }
    }
}