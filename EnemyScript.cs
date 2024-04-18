using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class EnemyScript : MonoBehaviour
{
    private GameObject enemy;
    private SpriteRenderer spriteRenderer;
    private int frame;
    private GameObject player;   
    public Sprite[] sprites;
    private void Awake()
    {
       enemy = GameObject.FindGameObjectWithTag("Enemy"); ;
       spriteRenderer = GetComponent<SpriteRenderer>();
       player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        float distance = enemy.transform.position.x - player.transform.position.x;
        if (distance > -1.5f)
        {
            Debug.Log(distance);
            Animate();

        }
        else
        {
            CancelInvoke();
        }
    }


    private void Animate()
    {
        frame++;

        if (frame >= sprites.Length)
        {
            frame = 0;
        }
        if (frame >= 0 && frame < sprites.Length)
        {
            spriteRenderer.sprite = sprites[frame];
        }
        
    }
}
