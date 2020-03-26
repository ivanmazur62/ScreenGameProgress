using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void ProgressBlockDelegate(ProgressBlock progressBlock);
public class ProgressBlock : MonoBehaviour
{
    public EventsManager EventsManager;

    public Text label;
    public Image checkIcon;
    public Image icon;
    public Image greenIcon;
    public int pointCount;
    public bool isComplete = false;    
    public int goldPrize;
    public int tokenPrize;

    private void Start()
    {
        EventsManager = FindObjectOfType<EventsManager>();
        SetComplete(isComplete);
        SetLevelPoint(pointCount);       
    }

    public void SetLevelPoint(int point)
    {
        label.text = point <= 0 ? "" : point.ToString();
    }

    public void SetComplete(bool complete)
    {
        checkIcon.gameObject.SetActive(complete);        
        greenIcon.transform.GetComponent<Image>().enabled = complete;

        if (complete)
            icon.transform.GetComponent<Image>().color = new Color(0.717f, 0.505f, 0.79f, 1f);
        else
            icon.transform.GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }

    public void BlockCompleted()
    {
        EventsManager.OnProgressBlockCompleted(this);        
        StartCoroutine(ScaleBlockAnimation(1.5f));        
        if (goldPrize > 0)
            VFXManager.Instance.GoldCoinsCollectVFX(goldPrize, GetComponent<RectTransform>().position + new Vector3(0, 2, 0));

        if (tokenPrize > 0)
            VFXManager.Instance.TokenCoinsCollectVFX(tokenPrize, GetComponent<RectTransform>().position + new Vector3(0, 2, 0));
    }

    //Scale effect
    IEnumerator ScaleBlockAnimation(float size)
    {
        for (float f = 1; f <= size; f += (0.05f))
        {
            greenIcon.GetComponent<RectTransform>().localScale = new Vector3(f, f, f);
            yield return new WaitForSeconds(0.01f);
        }
        greenIcon.GetComponent<RectTransform>().localScale = new Vector3(size, size, size);

        for (float f = size; f > 1f; f -= (0.05f))
        {
            greenIcon.GetComponent<RectTransform>().localScale = new Vector3(f, f, f);
            yield return new WaitForSeconds(0.01f);
        }
        greenIcon.GetComponent<RectTransform>().localScale = Vector3.one;

        icon.transform.GetComponent<Image>().color = new Color(0.717f, 0.505f, 0.79f, 1f);

        StartCoroutine(ScaleInCheck(size));
    }


    //Scale effect Check
    IEnumerator ScaleInCheck(float size)
    {
        checkIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        checkIcon.gameObject.SetActive(true);

        for (float f = 0; f <= size; f += (0.05f))
        {
            checkIcon.GetComponent<RectTransform>().localScale = new Vector3(f, f, f);
            yield return new WaitForSeconds(0.01f);
        }
        checkIcon.GetComponent<RectTransform>().localScale = new Vector3(size, size, size);

        for (float f = size; f > 1f; f -= (0.05f))
        {
            checkIcon.GetComponent<RectTransform>().localScale = new Vector3(f, f, f);
            yield return new WaitForSeconds(0.01f);
        }
        checkIcon.GetComponent<RectTransform>().localScale = Vector3.one;

        greenIcon.transform.GetComponent<Image>().enabled = true;
        isComplete = true;
    }
}
