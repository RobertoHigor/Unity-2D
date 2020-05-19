using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour {
    // Exibe essa variável no Unity inspector.
    [SerializeField] Text textComponent;
    [SerializeField] State startingState; // Estado inicial

    State state; // Estado atual
    // Start is called before the first frame update
    void Start () {
        state = startingState;
        // Altera o componente Text do GameObject
        textComponent.text = state.GetStateStory ();
    }

    // Update is called once per frame
    void Update () {
        ManageState ();
    }

    public void ManageState () {
        // Var atribui o tipo assim que um valor é definido.
        var nextState = state.GetNextState ();

        for (int i = 0; i < nextState.Length; i++) {
            if (Input.GetKeyDown (KeyCode.Alpha1 + i)) { // Como o índice começa em 0, a primeira tecla será 1
                state = nextState[0];
            } 
        }

        textComponent.text = state.GetStateStory (); // Atualizar o texto
    }
}