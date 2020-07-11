using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;

    private void Awake() {
        SetLaneSpawner();
    }
    
    private void Update() {
        if (IsAttackerInLane())
        {
            Debug.Log("Shoot lane");
        }  
        else
        {
            Debug.Log("Sit and wait");
        }  
    }

    // Atribui o Attacker da mesma linha
    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        // Checar qual spawner está na mesma lane através do valor do y
        foreach (AttackerSpawner spawner in spawners)
        {
            // spawner position - defender position. Se der 0, significa que estão na mesma posição.
            // Math.Abs retorna o valor absoluto, então se a lane for maior que o spawn, irá retornar um valor maior do que 1.
            // Pois antes retornava negativo, o que é menor que Epsilon
            //Debug.Log("Calculando se existe um attacker");
            bool isCloseEnough = 
                (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            Debug.Log(isCloseEnough);

            if (isCloseEnough)
            {
                Debug.Log("Attacker detectado");
                myLaneSpawner = spawner;
            }
        }
    }

    // Retorna se existe um attacker na linha
    private bool IsAttackerInLane()
    {
        if (myLaneSpawner == null)
            return false;

        // Checar se o spawner possuí algum child
        if (myLaneSpawner.transform.childCount <= 0)
        {
            //Debug.Log("Não tem child");
            return false;
        } else 
        {
            return true;
        }
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }

  
}
