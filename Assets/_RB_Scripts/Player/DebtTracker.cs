using UnityEngine;
using System.Collections;

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


    private int debt;
    private string debtString;

    void Start()
    {
        debt = -20000;
        debtString = debt.ToString() + " €";

        print(debtString);
    }

    public void Cost(int amount)
    {
        debt += amount;
        debtString = debt.ToString() + " €";
        print(debtString);
    }

    int numTaxis;
    public void CountTaxi()
    {
        numTaxis++;
    }
}
