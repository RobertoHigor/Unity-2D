using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    // Cached Reference
    Level level;

    private void Start() 
    {
        level = FindObjectOfType<Level>();
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
       AudioSource.PlayClipAtPoint(
           breakSound, 
           Camera.main.transform.position, 
           1f);

       level.DecreaseBreakableBlocks();
       Destroy(gameObject);
       //Debug.Log(collision.gameObject.name);
    }
}
