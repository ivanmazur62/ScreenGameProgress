using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{    
    public Image GreenLine;
    public Image GreenLiteLine;
    public ProgressLabel progressLabel;

    readonly float stepIndex = 441.47f;
    public float FadeSpeed = 1.5f;


    public void SetStartProgress(int countItem)
    {        
        //Calculate progress line size
        float progressSize = stepIndex * ((float)countItem - 1);   
        
        //Set Start Progress Label position
        progressLabel.StartPosition = (progressSize / 2f * (-1f));
        
        //Set Progress Line Position
        Vector3 startPos = GetComponent<RectTransform>().localPosition;
        GetComponent<RectTransform>().localPosition = new Vector3(progressSize / 2, startPos.y, startPos.z);
        
        //Set Progress Line Size
        GetComponent<RectTransform>().sizeDelta = new Vector2(progressSize, GetComponent<RectTransform>().sizeDelta.y);
        GreenLine.GetComponent<RectTransform>().sizeDelta = new Vector2(progressSize, GreenLine.GetComponent<RectTransform>().sizeDelta.y);
        GreenLiteLine.GetComponent<RectTransform>().sizeDelta = new Vector2(progressSize, GreenLiteLine.GetComponent<RectTransform>().sizeDelta.y);
    }

    public void SetProgress(float progressPercentage)
    {
        //GreenLine.fillAmount = progressPercentage;        
        //StartCoroutine(FadeProgressLite(progressPercentage));
        GreenLiteLine.fillAmount = progressPercentage;
        StartCoroutine(FadeProgressGreen(progressPercentage));
    }

    public void SetProgressLable(int point, float position)
    {
        //progressLabel.SetProgressPoint(point);
        //progressLabel.SetProgressPosition(position * stepIndex);
        StartCoroutine(FadeProgressLable(position * stepIndex));
        StartCoroutine(FadeProgressPoints(point));
    }

    IEnumerator FadeProgressGreen(float amount)
    {        
        for (float f = GreenLine.fillAmount; f <= amount; f += (0.005f * FadeSpeed))
        {            
            GreenLine.fillAmount = f;
            yield return new WaitForSeconds(0.01f);
        }
        GreenLine.fillAmount = amount;
    }

    IEnumerator FadeProgressLable(float amount)
    {        
        for (float f = progressLabel.CurrentPosition; f <= amount; f += (13.24f * FadeSpeed))
        {
            progressLabel.SetProgressPosition(f);
            yield return new WaitForSeconds(0.01f);
        }
        progressLabel.SetProgressPosition(amount);
    }

    IEnumerator FadeProgressPoints(int amount)
    {
        for (int f = progressLabel.CurrentPoints; f <= amount; f += (int)(4f * FadeSpeed))
        {
            progressLabel.SetProgressPoint(f);
            yield return new WaitForSeconds(0.01f);
        }
        progressLabel.SetProgressPoint(amount);
    }
}
