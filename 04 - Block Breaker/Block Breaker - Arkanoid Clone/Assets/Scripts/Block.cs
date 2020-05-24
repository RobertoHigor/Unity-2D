using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision) {
       // gameObject é uma referência a esse objeto
       //Destroy(gameObject, 1f);
       Destroy(gameObject);
       Debug.Log(collision.gameObject.name);
   }
}
