using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "ScriptableObjects/Create Player Dates")]
public class PlayerData : ScriptableObject
{
    [Header("Player Property")]
    public AnimatorController anim;
    public Sprite CursorImage;
    public bool isFly = false;
    [Header("Editor")]
    public Sprite CurrentPlayer;
    public float Angle;
}
