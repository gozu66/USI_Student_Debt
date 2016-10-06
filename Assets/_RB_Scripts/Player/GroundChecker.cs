using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour
{
    //public static GroundChecker instance;
    public static bool playerIsGrounded;

    void Start()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(!other.isTrigger)
        {
            playerIsGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            playerIsGrounded = false;
        }
    }
}