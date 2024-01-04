using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(PlayerData))]
public class PlayerDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PlayerData playerData = (PlayerData)target;

        DrawDefaultInspector();

        EditorGUILayout.Space();

        playerData.CurrentPlayer = (Sprite)EditorGUILayout.ObjectField("Player Image", playerData.CurrentPlayer, typeof(Sprite), false);

        float angle = EditorGUILayout.FloatField(playerData.Angle);

        EditorGUILayout.Space();

        if (GUILayout.Button("Angle Plus"))
        {
            playerData.Angle += 10;
        }

        if (GUILayout.Button("Reset"))
        {
            playerData.Angle = 0;
        }
    }
}
