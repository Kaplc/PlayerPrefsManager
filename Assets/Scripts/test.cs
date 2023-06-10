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

    public Dictionary<int, string> dict = new Dictionary<int, string>()
    {
        { 1, "123" },
        { 2, "456" }
    };

    public Item item = new Item(1, "装备");

    public PlayerInfo()
    {
    }
}

public class Item
{
    public int id;
    public string name;

    public Item(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo p1 = new PlayerInfo();
        PlayerPrefsManager.Instance.Save(p1, "player1");

        PlayerInfo p2 = new PlayerInfo();
        p2 = PlayerPrefsManager.Instance.Load(typeof(PlayerInfo), "player1") as PlayerInfo;
    }

    // Update is called once per frame
    void Update()
    {
    }
}