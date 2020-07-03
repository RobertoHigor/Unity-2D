using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 100;

    public int GetDamage()
    {
        return damage;
    }

    // Falta acionar o Hit para destruir o projétil
    public void Hit()
    {
        Destroy(gameObject);
    }
}
