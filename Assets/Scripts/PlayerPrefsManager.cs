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
        if (fieldType == typeof(float))
        {
            Debug.Log($"保存{saveKey}");
            PlayerPrefs.SetFloat(saveKey, (float)fieldValue);
        }
        if (fieldType == typeof(string))
        {
            Debug.Log($"保存{saveKey}");
            PlayerPrefs.SetString(saveKey, fieldValue.ToString());
        }
        if (fieldType == typeof(bool))
        {
            Debug.Log($"保存{saveKey}");
            PlayerPrefs.SetInt(saveKey, (bool)fieldValue ? 1 : 0);
        }
        // 判断该fieldType是否是IList子类
        if (typeof(IList).IsAssignableFrom(fieldType))
        {
            string listSaveKey = "";
            // Debug.Log($"保存{saveKey}");
            IList list = fieldValue as IList;
            for (int i = 0; i < list.Count; i++)
            {
                listSaveKey = saveKey + i;
                SaveValue(listSaveKey, list[i]);
            }
            
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