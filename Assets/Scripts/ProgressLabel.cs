using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressLabel : MonoBehaviour
{    
    public Text progressPoint;
    public float StartPosition { get; set; }
    public float CurrentPosition { get; set; }
    public int CurrentPoints { get; set; }

    public void SetProgressPoint(int points)
    {
        CurrentPoints = points;
        progressPoint.text = points.ToString();
    }

    public void SetProgressPosition(float position)
    {
        CurrentPosition = position;
        Vector3 startPos = GetComponent<RectTransform>().localPosition;
        GetComponent<RectTransform>().localPosition = new Vector3(StartPosition + CurrentPosition, startPos.y, startPos.z);
    }
}
