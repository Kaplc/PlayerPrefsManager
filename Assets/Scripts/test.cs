using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInfo
{
    public int age;
    public string name;
    public float height;
    public bool sex;

    public List<int> list;

    public Dictionary<int, string> dict;

    public Item item;

    public PlayerInfo()
    {
    }
}

public class Item
{
    public int id;
    public string name;
    
    public Item(){}
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
        p1.age = 10;
        p1.name = "abc";
        p1.height = 170.5f;
        p1.sex = true;
        p1.list = new List<int>() { 1, 2, 3 };
        p1.dict = new Dictionary<int, string>()
        {
            { 1, "123" },
            { 2, "456" }
        };
        p1.item = new Item(1, "装备");
        PlayerPrefsManager.Instance.Save(p1, "player1");

        PlayerInfo p2 = new PlayerInfo();
        p2 = PlayerPrefsManager.Instance.Load(typeof(PlayerInfo), "player1") as PlayerInfo;
    }

    // Update is called once per frame
    void Update()
    {
    }
}