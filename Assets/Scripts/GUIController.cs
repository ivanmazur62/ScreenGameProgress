using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIController : MonoBehaviour
{
    public EventsManager EventsManager;

    public GUIAmountField goldField;
    public GUIAmountField tokenField;

    private void Start()
    {
        EventsManager = FindObjectOfType<EventsManager>();
        EventsManager.progressBlock += EventsManager_progressBlock;
    }

    private void EventsManager_progressBlock(ProgressBlock progressBlock)
    {
        if (progressBlock.goldPrize > 0)
            goldField.AddAmount(progressBlock.goldPrize);
        if (progressBlock.tokenPrize > 0)
            tokenField.AddAmount(progressBlock.tokenPrize);
    }
}