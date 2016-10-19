using UnityEngine;
using System.Collections;

public class Cull : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cull")
        {
            Destroy(gameObject);
        }
    }
}
