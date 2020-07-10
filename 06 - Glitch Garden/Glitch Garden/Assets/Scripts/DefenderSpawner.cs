using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] GameObject defender;

    private void OnMouseDown() {        
        SpawnDefender();
        Debug.Log("mouse was clicked");
    }

    private void SpawnDefender()
    {
        GameObject newDefender = Instantiate(
            defender,
            transform.position,
            Quaternion.identity
        );
    }
}
