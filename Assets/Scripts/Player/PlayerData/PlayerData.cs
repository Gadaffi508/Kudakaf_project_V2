using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "ScriptableObjects/Create Player Dates")]
public class PlayerData : ScriptableObject
{
    public Animator anim;
    public Sprite playerSprite;
    public Sprite CursorImage;
    public bool isFly = false;
}
