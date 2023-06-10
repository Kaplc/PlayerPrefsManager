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
    private void SaveValue(string saveKey, object fieldValue)
    {
        Type fieldType = fieldValue.GetType();

        if (fieldType == typeof(int))
        {
            Debug.Log($"保存{saveKey}");
            PlayerPrefs.SetInt(saveKey, (int)fieldValue);
        }

        else if (fieldType == typeof(float))
        {
            Debug.Log($"保存{saveKey}");
            PlayerPrefs.SetFloat(saveKey, (float)fieldValue);
        }

        else if (fieldType == typeof(string))
        {
            Debug.Log($"保存{saveKey}");
            PlayerPrefs.SetString(saveKey, fieldValue.ToString());
        }

        else if (fieldType == typeof(bool))
        {
            Debug.Log($"保存{saveKey}");
            PlayerPrefs.SetInt(saveKey, (bool)fieldValue ? 1 : 0);
        }

        // 判断该fieldType是否是IList子类
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            IList list = fieldValue as IList;
            // 储存数量
            Debug.Log($"{saveKey}_Count");
            PlayerPrefs.SetInt(saveKey + "_Count", list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                SaveValue(saveKey + i, list[i]);
            }
        }

        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            IDictionary dict = fieldValue as IDictionary;

            Debug.Log($"{saveKey}_Count");
            PlayerPrefs.SetInt(saveKey + "_Count", dict.Count);

            int index = 0;
            foreach (object key in dict.Keys)
            {
                // 保存key
                SaveValue(saveKey + "_key" + index, key);
                // 保存value
                SaveValue(saveKey + "_value" + index, dict[key]);
                index++;
            }
        }
        // 自定义数据类型继续调用保存方法
        else
        {
            Save(fieldValue, saveKey);
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
            // infos[i].GetValue(data)字段的值
            SaveValue(saveKey, infos[i].GetValue(data));
        }
    }

    public object Load(Type type, string key)
    {
        return null;
    }
}