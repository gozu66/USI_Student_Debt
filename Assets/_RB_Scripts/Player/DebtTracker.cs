﻿using UnityEngine;
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

    void Start()
    {
        _image = GameObject.Find("Image").GetComponent<Image>();
        debtUI = GameObject.Find("Debt UI").GetComponent<Text>();
        debtUpdateUI = GameObject.Find("Debt UPDATE UI").GetComponent<Text>();
        _text = GameObject.Find("MyText").GetComponent<Text>();

        debt = -20000;
        debtString = debt.ToString() + " €";
        debtUI.text = debtString;
        debtUpdateUI.text = "";
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Finish")
        {
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
    Image _image;
    void GenerateAndDisplay()
    {
        _text.text = "You have earned €" + (totalCoins * 250) + " since you graduated!\nYou have paid out €" + (Mathf.Abs(totalExpenses)) + " in expenses!\nYou are still €" + (20000 - (totalCoins * 250)) + " in debt!";

        _text.enabled = true;
        _image.enabled = true;
    }
}
