using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebtTracker : MonoBehaviour
{
    public static DebtTracker _instance;
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    Text debtUI, debtUpdateUI;

    private int debt;
    private string debtString;

    AudioSource music;

    void Start()
    {
        _image = GameObject.Find("WinBG").GetComponent<Image>();
        _image2 = GameObject.Find("winImg").GetComponent<Image>();
        debtUI = GameObject.Find("Debt UI").GetComponent<Text>();
        debtUpdateUI = GameObject.Find("Debt UPDATE UI").GetComponent<Text>();
        _text = GameObject.Find("WinText").GetComponent<Text>();
        music = GameObject.Find("Music").GetComponent<AudioSource>();
        social = GameObject.Find("Social");


        debt = -20000;
        debtString = debt.ToString() + " €";
        debtUI.text = debtString;
        debtUpdateUI.text = "";
    }

    GameObject social;
    bool isFinished;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Finish" && !isFinished)
        {
            isFinished = true;
            //social.transform.GetChild(0).gameObject.SetActive(true);
            //social.transform.GetChild(1).gameObject.SetActive(true);
            //Transform[] myTs = social.transform.GetChild
            for(int i = 0; i < social.transform.childCount; i++)
            {
                social.transform.GetChild(i).gameObject.SetActive(true);
            }
            GenerateAndDisplay();
        }
    }

    public void Cost(int amount)
    {
        debtUpdateUI.color = (amount > 0) ? Color.green : Color.red;
        debt += amount;
        if (amount < 0) { AddTotalExpenses(amount); }
        debtString = debt.ToString() + " €";
        debtUI.text = debtString;
        StopAllCoroutines();
        StartCoroutine(FadeText());
        debtUpdateUI.text = (amount > 0) ? "+" + amount + " €" : amount.ToString() + " €";
    }

    int numTaxis;
    public void CountTaxi()
    {
        numTaxis++;
    }

    int i = 255;
    IEnumerator FadeText()
    {
        while (i > 0)
        {
            i -= 1;
            debtUpdateUI.color = new Color(debtUpdateUI.color.r, debtUpdateUI.color.g, debtUpdateUI.color.b, i);
            yield return null;
        }
        i = 255;
    }

    int totalCoins;
    public void AddTotalCoins()
    {
        totalCoins++;
    }
    int totalExpenses;
    public void AddTotalExpenses(int amount)
    {
        totalExpenses += amount;
    }

    Text _text;
    Image _image, _image2;
    void GenerateAndDisplay()
    {
        _text.text = "YOU HAVE EARNED €" + (totalCoins * 450) + " SINCE GRADUATION!\n\nYOU HAVE PAID €" + (Mathf.Abs(totalExpenses)) + " IN EXPENSES!\n\nYOU ARE STILL €" + Mathf.Abs(debt) + " IN DEBT!";

        _text.enabled = true;
        _image.enabled = true;
        _image2.enabled = true;

        StartCoroutine("SwapMusic");
    }

    public AudioClip winFx, winMusic;
    IEnumerator SwapMusic()
    {
        music.Stop();
        music.clip = winFx;
        music.Play();
        yield return new WaitForSeconds(winFx.length - 0.5f);
        music.volume = 0.6f;
        music.clip = winMusic;
        music.Play();

    }
}
