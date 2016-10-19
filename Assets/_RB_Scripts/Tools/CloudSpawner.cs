using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

    public GameObject[] clouds;

    void Start()
    {
        InvokeRepeating("SpawnCloud", 2f, 2f);
    }

   void SpawnCloud()
    {
        Instantiate(clouds[Random.Range(0, clouds.Length)], new Vector3(transform.position.x + 15, Random.Range(0, 4.5f) ,0), Quaternion.identity);
    }
}
