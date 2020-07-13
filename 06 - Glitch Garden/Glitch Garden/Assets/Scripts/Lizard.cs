using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    // Atacar o objeto colidido caso seja um Defender
    private void OnTriggerEnter2D(Collider2D otherCollision)
    {
        GameObject otherObject = otherCollision.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            Debug.Log("Target: "+ otherObject);
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
