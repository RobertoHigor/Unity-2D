using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 5f;
    public Attacker attackerPrefab;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        // Instanciar como um Attacker
        Attacker newAttacker = Instantiate(
            attackerPrefab, 
            transform.position, 
            transform.rotation) as Attacker;
        
        // O pai de newAttacker será o Transform.
        // No Hierarchy, eles irão aparece como filhos do objeto que os instanciam.
        newAttacker.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
