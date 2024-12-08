using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager
{
    private const string PrefabsFilePath = "Dialogs/";

    private static readonly Dictionary<Type, string> PrefabsDictionary = new()
    {
        {typeof(WinPanel),"WinPanel"},
        {typeof (LosePanel),"LosePanel"},
        {typeof(MainPanel),"MainPanel"}
    };

    public static T ShowDialog<T>(IViewService view) where T : Dialog
    {
        var go = GetPrefabByType<T>();
        if (go == null)
        {
            Debug.LogError("Показать окно - объект не найден");
            return null;
        }
        return GameObject.Instantiate(go, view.GetCurrentCanvas().transform);
    }

    private static T GetPrefabByType<T>() where T : Dialog
    {
        var prefabName = PrefabsDictionary[typeof(T)];
        if (string.IsNullOrEmpty(prefabName))
        {
            Debug.LogError("не удается найти сборный тип " + typeof(T) + ", вы добавили его в PrefabsDictionary?");
        }

        var path = PrefabsFilePath + PrefabsDictionary[typeof(T)];
        var dialog = Resources.Load<T>(path);
        if (dialog == null)
        {
            Debug.LogError("Не удается найти класс " + typeof(T) + " по адресу path " + path);
        }
        return dialog;
    }

}
