using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public List<ProgressBlock> progressBlocks;
    public ProgressBar progressBar;    

    private void Start()
    {
        //Set Start Main progress Line        
        progressBar.SetStartProgress(progressBlocks.Count);
        SetProgress();
    }

    public void SetProgress()
    {
        //Set previous Rank        
        int previousRank = progressBlocks.FindIndex(x => x.pointCount <= PlayerProfile.Instance.Point);
        
        if (previousRank <= 0) previousRank = 1;        

        //Calculate progress position
        int nextRank = progressBlocks.FindIndex(x => x.pointCount > PlayerProfile.Instance.Point) + 1;        
        int currentRank = nextRank - 1;

        //Check Zero Rank
        if (currentRank <= 0) { currentRank = 1; nextRank = 2; }

        float currentDistance = progressBlocks[nextRank - 1].pointCount - progressBlocks[currentRank - 1].pointCount;
        float progressPosBetweenRank = 1f - ((progressBlocks[nextRank - 1].pointCount - PlayerProfile.Instance.Point) / currentDistance);
        float rankStep = 1f / ((float)progressBlocks.Count - 1f);

        //Calculate progress percentage from Progress Points
        float progressPercentage = rankStep * (float)(currentRank - 1) + (rankStep * progressPosBetweenRank);

        //Set Progress
        progressBar.SetProgress(progressPercentage);

        //Calculate progress point percentage from Progress Points
        float progressLabelPerc = (float)currentRank - 1f + progressPosBetweenRank;

        //Set Progress Label
        progressBar.SetProgressLable(PlayerProfile.Instance.Point, progressLabelPerc);        

        //Check receiving a new rank
        if (previousRank < currentRank)
            StartCoroutine(CheckNewRank(currentRank));
    }

    IEnumerator CheckNewRank(int currentRank)
    {
        float saveTime = 5f;

        if (progressBlocks[currentRank - 1].isComplete)
            saveTime = 0;

        while (saveTime > 0)
        {
            if (progressBar.progressLabel.CurrentPoints >= PlayerProfile.Instance.Point)
            {                
                progressBlocks[currentRank - 1].BlockCompleted();
                yield break;
            }
            
            saveTime -= 0.5f;
            yield return new WaitForSeconds(0.5f);
        }
    }

}
