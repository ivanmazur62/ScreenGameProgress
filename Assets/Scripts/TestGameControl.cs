using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameControl : MonoBehaviour
{
    public static TestGameControl Instance = null;
    public int PlayerPoints = 170;

    void Start()
    {        
        if (Instance == null)        
            Instance = this;        
        else if (Instance == this)       
            Destroy(gameObject);        

        DontDestroyOnLoad(gameObject);

        PlayerProfile.Instance.AddPoints(Instance.PlayerPoints);
    }

    public void Add100Point()
    {
        PlayerProfile.Instance.AddPoints(100);
    }
}
