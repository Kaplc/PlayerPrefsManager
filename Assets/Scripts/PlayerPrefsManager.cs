using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager
{
    public static PlayerPrefsManager Instance { get; } = new PlayerPrefsManager();

    public PlayerPrefsManager()
    {
        
    }

    public void Save(object data, string key)
    {
        
    }

    public object Load(Type type, string key)
    {
        return null;
    }
}
