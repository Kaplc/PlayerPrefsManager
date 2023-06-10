using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInfo
{
    public int age = 10;
    public string name = "abc";
    public float height = 170.5f;
    public bool sex = true;

    public List<int> list = new List<int>() { 1, 2, 3 };

    public PlayerInfo()
    {
    }
}

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo p1 = new PlayerInfo();
        PlayerPrefsManager.Instance.Save(p1, "player1");
    }

    // Update is called once per frame
    void Update()
    {
    }
}