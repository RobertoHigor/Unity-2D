using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    // Exibe essa variável no Unity inspector.
    [SerializeField] Text textComponent;
    [SerializeField] State startingState; // Estado inicial

    State state; // Estado atual
    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        // Altera o componente Text do GameObject
        textComponent.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    public void ManageState()
    {
        // Var atribui o tipo assim que um valor é definido.
        var nextState = state.GetNextState();
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            state = nextState[0];
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) // Else pois não pode ser permitido apertar 2 botões ao mesmo tempo.
        {
            state = nextState[1];
        }

        textComponent.text = state.GetStateStory(); // Atualizar o texto
    }
}