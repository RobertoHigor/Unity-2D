using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
  // Quando um evento acontece com o collider
  private void OnTriggerEnter2D(Collider2D colission)
    {     
        /*
         * Não é recomendado referênciar a cena pelo nome pois será necessário
         * alterar o código caso a cena seja renomeada.
         */
        SceneManager.LoadScene("Game Over");
    }
}
