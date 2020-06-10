using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkVFX;
    [SerializeField] Sprite[] hitSprites;
    
    // Cached Reference
    Level level;
    GameStatus gameStatus;

    // state variables
    [SerializeField] int timesHit; // Only serialized for debug purposes

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1; // A vida do bloco é de acordo com a quantidade de sprites
            if (timesHit >= maxHits)
             DestroyBlock();
            else
             ShowNextHitSprite();
        }
       
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        else
            Debug.LogError("Block Sprite is missing" + gameObject.name);
    }

    private void DestroyBlock()
    {
        // gameObject é uma referência a esse objeto
        //Destroy(gameObject, 1f);       
        level.DecreaseBlocks();
        gameStatus.AddToScore();
        TriggerSparkVFX();
        PlayBlockDestroySFX();
        Destroy(gameObject);
        //Debug.Log(collision.gameObject.name);
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(
           breakSound,
           Camera.main.transform.position,
           1f);
    }
    private void TriggerSparkVFX()
    {
        GameObject sparkles = Instantiate(blockSparkVFX,
        transform.position,
        transform.rotation);
        Destroy(sparkles, 2f); // Destruir depois de 2 segundos
    }
}
