using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerPrefsManager
{
    public static PlayerPrefsManager Instance { get; } = new PlayerPrefsManager();

    public PlayerPrefsManager()
    {
    }
    
    /// <summary>
    /// 调用PlayerPrefs保存各种类型的数据
    /// </summary>
    /// <param name="saveKey">键</param>
    /// <param name="value">保存的值</param>
    /// <param name="type">类型</param>
    private void SaveValue(string saveKey, object value, Type type)
    {
        if (type == typeof(int))
        {
            PlayerPrefs.SetInt(saveKey, (int)value);
        }
        if (type == typeof(float))
        {
            PlayerPrefs.SetFloat(saveKey, (float)value);
        }
        if (type == typeof(string))
        {
            PlayerPrefs.SetString(saveKey, value.ToString());
        }
        if (type == typeof(bool))
        {
            PlayerPrefs.SetInt(saveKey, (bool)value ? 1 : 0);
        }
    }
    
    public void Save(object data, string key)
    {
        Type dataType = data.GetType();
        FieldInfo[] infos = dataType.GetFields(); // data获取Type再获取所有字段信息
        string saveKey = "";

        for (int i = 0; i < infos.Length; i++)
        {
            // key_数据类型_字段类型_字段名
            saveKey = key + "_" + dataType.Name + "_" + infos[i].FieldType.Name + "_" + infos[i].Name;

            SaveValue(saveKey, infos[i].GetValue(data), dataType);
        }
    }

    public object Load(Type type, string key)
    {
        return null;
    }
}