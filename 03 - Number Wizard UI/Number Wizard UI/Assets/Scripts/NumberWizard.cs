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
        NextGuess();
    }

    public void OnPressHigher()
    {
        min = guess+ 1; // Pois o mínimo não deve ser o mesmo que o guess, já que não é a resposta.
        NextGuess();
    }

    public void OnPressLower()
    {
        max = guess - 1;
        NextGuess();
    }

    void NextGuess()
    {
        guess = Random.Range(min, max+1);
        guessText.text = guess.ToString();
    }
}
