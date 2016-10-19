using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject[] Players;
    int charNum;

    public void SelectCharacter(int character)
    {
        charNum = character;
        //Vector3 pos = new Vector3(-7, -2, 0);
        //Instantiate(Players[character], pos, Quaternion.identity);
    }

    public IEnumerator PlayerSelect(int i)
    {
        yield return new WaitForSeconds(1);
        Camera.main.GetComponent<MainCameraScript>().StartScroll();
        Vector3 pos = new Vector3(-7, -2, 0);
        Instantiate(Players[charNum], pos, Quaternion.identity);
    }
}
