using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager
{
    private const string PrefabsFilePath = "Dialogs/";
    private static readonly Dictionary<Type, string> PrefabsDictionary = new()
    {
        {typeof(DialogYouWin),"DialogYouWin"}
    };


    public static T ShowDialog<T>() where T : Dialog
    {
        var go = GetPrefabByType<T>();
        if (go == null)
        {
            Debug.LogError("опять хуета!");
            return null;
        }
        return GameObject.Instantiate(go);// нужно добавить парента
    }

    private static T GetPrefabByType<T>() where T : Dialog
    {
        var prefabName = PrefabsDictionary[typeof(T)];
        if (string.IsNullOrEmpty(prefabName))
        {
            Debug.LogError("хуета!");
        }

        var path = PrefabsFilePath + PrefabsDictionary[typeof(T)];
        var dialog = Resources.Load<T>(path);
        if (dialog == null)
        {
            Debug.LogError("еще хуета!");
        }
        return dialog;
    }

}
