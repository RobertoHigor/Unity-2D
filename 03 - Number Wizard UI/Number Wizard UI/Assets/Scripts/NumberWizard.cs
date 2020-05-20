using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour {

    [SerializeField] int max;
    [SerializeField] int min;
    // Variável do tipo TextMesh Pro para exibir o Guess
    // Nesse caso, é associado um objeto do tipo TextMesh
    [SerializeField] TextMeshProUGUI guessText; 
    int guess;

    // Use this for initialization
    void Start ()
    {
        StartGame();
	}
	
    void StartGame()
    {        
        guess = (max + min ) / 2;
        guessText.text = guess.ToString();
        max = max + 1; // Para arredondar, pois max - min / 2 daria 999 / 2
    }

    public void OnPressHigher()
    {
        min = guess;
        NextGuess();
    }

    public void OnPressLower()
    {
        max = guess;
        NextGuess();
    }

    void NextGuess()
    {
        guess = (max + min) / 2;
        guessText.text = guess.ToString();
    }
}
