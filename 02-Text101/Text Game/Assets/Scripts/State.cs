using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adiciona o State no menu de criação de Assets
[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    // (minSize, linhas)
    [TextArea(14,10)] [SerializeField]
    string storyText;
    [SerializeField]
    State[] nextStates; 

    public string GetStateStory() 
    {
        return storyText;
    }

    public State[] GetNextState(){
        return nextStates;
    }
}
