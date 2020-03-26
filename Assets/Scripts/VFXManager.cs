using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static VFXManager Instance = null;

    public Transform goldGUI;
    public GameObject goldCoin;

    public Transform tokenGUI;
    public GameObject tokenCoin;

    public float rate = 0.1f;
    public float time = 1;
    
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);        
    }

    public void GoldCoinsCollectVFX(int coinAmount, Vector3 startPos)
    {
        StartCoroutine(CollectVFX(goldCoin, coinAmount, startPos, goldGUI.position));
    }

    public void TokenCoinsCollectVFX(int coinAmount, Vector3 startPos)
    {
        StartCoroutine(CollectVFX(tokenCoin, coinAmount, startPos, tokenGUI.position));
    }

    IEnumerator CollectVFX(GameObject coinItem, int coinAmount, Vector3 startPos, Vector3 endPos)
    {
        for (int i = 0; i < coinAmount; i++)
        {
            GameObject coin = Instantiate(coinItem, startPos, Quaternion.identity) as GameObject;
            coin.transform.SetParent(transform);
            iTween.MoveTo(coin, iTween.Hash("position", endPos, "easetype", iTween.EaseType.easeInBack, "ignoretimescale", true, "time", time));            
            Destroy(coin, time + 1);
            yield return new WaitForSeconds(rate);
        }
    }
}
