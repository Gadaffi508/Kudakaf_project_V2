using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GunsManager : MonoBehaviour
{
    public List<Sprite> gunSprite = new List<Sprite>();
    public int randomGunNumber;

    private SpriteRenderer spt;
    private void Start()
    {
        spt = GetComponent<SpriteRenderer>();
        randomGunNumber = Random.Range(0, gunSprite.Count);
        spt.sprite = gunSprite[randomGunNumber];
        Debug.Log(randomGunNumber);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            player.CursorImage.sprite = gunSprite[randomGunNumber];
            player.charecterType = CharecterType.Gun;
            Destroy(gameObject);
        }
    }
}
