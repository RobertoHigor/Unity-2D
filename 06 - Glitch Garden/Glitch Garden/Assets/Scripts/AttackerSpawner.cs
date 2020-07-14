using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 5f;
    public Attacker[] attackersPrefab;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void Spawn(Attacker myAttacker )
    {
         // Instanciar como um Attacker
        Attacker newAttacker = Instantiate(
            myAttacker, 
            transform.position, 
            transform.rotation) as Attacker;
        
        // O pai de newAttacker será o Transform.
        // No Hierarchy, eles irão aparece como filhos do objeto que os instanciam.
        newAttacker.transform.parent = transform;
    }

    private void SpawnAttacker()
    {
        int attackerIndex = Random.Range(0, attackersPrefab.Length);
        Spawn(attackersPrefab[attackerIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
