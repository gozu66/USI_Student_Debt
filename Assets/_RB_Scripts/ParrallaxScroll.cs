using UnityEngine;
using System.Collections;

public class ParrallaxScroll : MonoBehaviour {

    Transform myT;
    public float modifier;

    void Start()
    {
        myT = transform;        
    }

	void FixedUpdate()
    {
        myT.Translate(-Vector2.right * modifier);    
    }
}
