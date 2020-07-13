using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject collisionObject = collision.gameObject;
        
        // Se for um tumulo, pular
        if (collisionObject.GetComponent<Gravestone>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }      
        else if (collisionObject.GetComponent<Defender>())
        {  // Senão, se for defender: atacar
            GetComponent<Attacker>().Attack(collisionObject);
        }
        
    }
}
