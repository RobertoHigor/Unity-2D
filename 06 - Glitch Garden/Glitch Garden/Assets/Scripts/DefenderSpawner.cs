using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] GameObject defender;

    private void OnMouseDown() {        
        SpawnDefender(GetSquarePosition());
        Debug.Log("mouse was clicked");
    }

    private Vector2 GetSquarePosition()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        // Converter a coordenada do world screen para o world space para obter a coordenada do grid
        // Nesse caso, converter a posição do mouse para World Point
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);

        return worldPos;
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        GameObject newDefender = Instantiate(
            defender,
            worldPos,
            Quaternion.identity
        );
    }
}
