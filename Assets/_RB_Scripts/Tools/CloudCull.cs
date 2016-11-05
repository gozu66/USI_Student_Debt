using UnityEngine;
using System.Collections;

public class CloudCull : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InvokeRepeating("cull", 5, 5);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void cull()
    {
        if (transform.position.x < -50)
            Destroy(gameObject);
    }
}
