using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GUIAmountField : MonoBehaviour
{
    public Image icon;
    public Text amountField;

    public void AddAmount(int amount)
    {
        StartCoroutine(FadeProgressPoints(amount));
    }

    void SetAmountField(int amount)
    {
        var nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
        nfi.NumberGroupSeparator = " ";
        string formatted = amount.ToString("#,0", nfi);
        amountField.text = formatted;
    }
    int GetAmountField()
    {
        string amountS = amountField.text;        
        return Int32.Parse(amountS.Replace(" ", ""));
    }

    IEnumerator FadeProgressPoints(int amount)
    {
        int cuurentAmount = GetAmountField();
        
        yield return new WaitForSeconds(1f);

        for (int i = 0; i <= amount; i++)
        {
            SetAmountField(cuurentAmount + i);

            yield return new WaitForSeconds(0.05f);
        }
        SetAmountField(cuurentAmount + amount);
    }
}
