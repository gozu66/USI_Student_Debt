using UnityEngine;
using System.Collections;

public class MainCameraScript : MonoBehaviour
{
    Transform myT;
    public float scrollSpeed = 0.2f;
    bool scroll;

    void Start()
    {
        myT = transform;
    }

    void FixedUpdate()
    {
        if(scroll)
            myT.Translate(Vector2.right * scrollSpeed);
    }

    public void StarrtScroll()
    {
        scroll = true;  
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Finish")
        {
            scroll = false;
        }
    }
}