using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    private void OnCollisionEnter2D(Collision2D collision) {
       // gameObject é uma referência a esse objeto
       //Destroy(gameObject, 1f);
       AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 1f);
       Destroy(gameObject);
       Debug.Log(collision.gameObject.name);
   }
}
