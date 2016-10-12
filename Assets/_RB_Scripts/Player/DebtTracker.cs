using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebtTracker : MonoBehaviour
{
    public static DebtTracker _instance;
    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Text debtUI, debtUpdateUI;

    private int debt;
    private string debtString;

    void Start()
    {
        debt = -20000;
        debtString = debt.ToString() + " €";
        debtUI.text = debtString;
        debtUpdateUI.text = "";
    }

    public void Cost(int amount)
    {
        debtUpdateUI.color = (amount > 0) ? Color.green : Color.red;
        debt += amount;
        debtString = debt.ToString() + " €";
        debtUI.text = debtString;
        StopAllCoroutines();
        StartCoroutine(FadeText());
        debtUpdateUI.text = (amount > 0) ? "+" + amount +" €" : amount.ToString() + " €";
    }

    int numTaxis;
    public void CountTaxi()
    {
        numTaxis++;
    }

    int i = 255;
    IEnumerator FadeText()
    {
        //Color c = debtUpdateUI.color;
        while(i > 0)
        {
            i -= 1;
            debtUpdateUI.color = new Color(debtUpdateUI.color.r, debtUpdateUI.color.g, debtUpdateUI.color.b, i);
            //print(debtUpdateUI.color.a);
            yield return null;
        }
        i = 255;
    }
}
