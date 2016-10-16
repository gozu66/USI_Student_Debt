using UnityEngine;
using System.Collections;

public class ParrallaxScroll : MonoBehaviour {

    Transform myT;
    public float modifier;

    public int farLeft, farRight;

    void Start()
    {
        myT = transform;        
    }

	void FixedUpdate()
    {
        myT.Translate(-Vector2.right * modifier);    

        if(farLeft != 0 && farRight != 0)
        {
            if (transform.position.x < farLeft)
            {
                transform.position = new Vector2(farRight, transform.position.y);
            }
        }
    }
}
