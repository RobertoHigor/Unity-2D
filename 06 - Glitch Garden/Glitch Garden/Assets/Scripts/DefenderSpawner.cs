using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    private void OnMouseDown()
    {
        if (defender)
        {
            AttemptToPlaceDefenderAt(GetSquarePosition());
        }
        //Debug.Log("mouse was clicked");
    }

    // Definir como selecionado o último defender clicado
    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarsDIsplay>();
        int defenderCost = defender.GetStarCost();

        // Se tiver estrelas o suficiente
        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSquarePosition()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        // Converter a coordenada do world screen para o world space para obter a coordenada do grid
        // Nesse caso, converter a posição do mouse para World Point
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    //Método para arredondar a posição para int.
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(
            defender,
            roundedPos,
            Quaternion.identity
        ) as Defender;
        //Debug.Log(roundedPos);

    }
}
