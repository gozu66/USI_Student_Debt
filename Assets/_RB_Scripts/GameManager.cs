using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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

    public IEnumerator PlayerSelect()
    {
        yield return new WaitForSeconds(1);
        Camera.main.GetComponent<MainCameraScript>().StartScroll();
        Vector3 pos = new Vector3(-7, -2, 0);
        Instantiate(Players[charNum], pos, Quaternion.identity);
    }

    public void Reload()
    {
        //Possibly change action to scroll back ober the level (co-routine) and begin again
        //for now we will reload for sake of time
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(0);
    }
}
