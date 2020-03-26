using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public event ProgressBlockDelegate progressBlock;

    public void OnProgressBlockCompleted(ProgressBlock block)
    {
        if (progressBlock != null)
            progressBlock(block);
    }
}
