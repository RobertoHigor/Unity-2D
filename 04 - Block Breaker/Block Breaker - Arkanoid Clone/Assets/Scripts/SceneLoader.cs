﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para usar o namespace do SceneManagement

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        // Atribuir o buildIndex da cena atual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {      
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetSession();
    }

    public void QuitGame()
    {
        // Esse método só funciona em builds. No editor o jogo não é encerrado.
        Application.Quit();
    }
}
