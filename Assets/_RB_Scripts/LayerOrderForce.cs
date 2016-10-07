using UnityEngine;
using System.Collections;

public class LayerOrderForce : MonoBehaviour
{
    Transform myT;

    void Start()
    {
        GetComponent<Renderer>().sortingLayerName = "UI";
        myT = GetComponent<Transform>();

        StartCoroutine("Lifetime");
    }

    IEnumerator Lifetime()
    {
        float timer = 0.0f;
        while(timer < 4.0f)
        {
            timer += Time.deltaTime;
            float newY = 0.05f;
            myT.position = new Vector2(myT.position.x, myT.position.y + newY);
            yield return null;
        }
        Destroy(gameObject);
    }
}