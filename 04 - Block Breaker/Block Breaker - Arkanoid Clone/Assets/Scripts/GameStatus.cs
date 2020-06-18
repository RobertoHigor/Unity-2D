using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    // Config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int scorePerBlockDestroyed = 83;
    [SerializeField] Text scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    // state variables
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        // Irá armazenar quantos objetos GameStatus existem
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        // Se tiver mais de um
        if (gameStatusCount > 1) 
        {
            // Desativando o objeto antes de destruir
            // Isso se deve pois o método Destroy somente é executado no final
            // da execução do Unity.
            gameObject.SetActive(false);
            Destroy(gameObject); // Destruir o próprio objeto
        } else 
        {
            // Não destruir quando o level carregar
            DontDestroyOnLoad(gameObject); 
        }
    }
    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        scoreText.text = currentScore.ToString();
    }

    public void AddToScore()
    {
        currentScore += scorePerBlockDestroyed;
    }

    public void ResetSession() {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}