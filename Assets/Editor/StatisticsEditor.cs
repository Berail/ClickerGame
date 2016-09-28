using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Statistics))]
public class StatisticsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Statistics myScript = (Statistics)target;
        GUI.color = Color.green;
        if (GUILayout.Button("Remove PlayerPrefs"))
        {
            myScript.RemovePlayerPrefs();
        }
    }
}