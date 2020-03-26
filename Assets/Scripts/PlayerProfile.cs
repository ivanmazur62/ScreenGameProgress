using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile : MonoBehaviour
{
    public static PlayerProfile Instance = null;

    int point;
    public int Point { get { return point; } }

    int gold;
    public int Gold { get { return gold; } }

    int token;        
    public int Token { get { return token; } }

    void Start()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void AddPoints(int point)
    {
        this.point += point;
    }

    public void AddGold(int gold)
    {
        this.gold += gold;
    }
}
