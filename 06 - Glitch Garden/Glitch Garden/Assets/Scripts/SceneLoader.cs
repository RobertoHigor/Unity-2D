using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex;

    private void Start() {
        // Pegar o build index da cena atual
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            Debug.Log("Dentro da Splash Screen. Carregando próxima cena...");
            StartCoroutine(DelayStartScren());
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadGameOver()
    {
     SceneManager.LoadScene("Game Over");   
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator DelayStartScren()
    {
        yield return new WaitForSeconds(3);
        LoadNextScene();
    }
}
