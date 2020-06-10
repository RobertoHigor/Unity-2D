using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkVFX;
    // Cached Reference
    Level level;
    GameStatus gameStatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        // gameObject é uma referência a esse objeto
        //Destroy(gameObject, 1f);       
        level.DecreaseBreakableBlocks();
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
