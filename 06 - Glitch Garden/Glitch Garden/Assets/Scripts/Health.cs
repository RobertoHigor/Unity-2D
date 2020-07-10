using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 2;
    [SerializeField] GameObject deathVFX;

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            DeathVFX();
            Destroy(gameObject); 
        }
    }

    private void DeathVFX()
    {
        // Se o objeto não tiver uma deathVFX
        if(!deathVFX) { return; }
        GameObject deathVFXReference = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXReference, 1f);
    }
}
