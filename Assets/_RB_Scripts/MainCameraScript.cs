using UnityEngine;
using System.Collections;

public class MainCameraScript : MonoBehaviour
{
    Transform myT;
    public float scrollSpeed = 0.2f; 

    void Start()
    {
        myT = transform;
    }

    void FixedUpdate()
    {
        myT.Translate(Vector2.right * scrollSpeed);
    }
}