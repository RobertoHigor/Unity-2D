using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;

    // state
    Vector2 paddleToBallVector;
    // Start is called before the first frame update
    void Start()
    {
        // Ball - Paddle 1 = Distância entre a bola e o paddle
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(
            paddle1.transform.position.x, 
            paddle1.transform.position.y
        );

        transform.position = paddlePos + paddleToBallVector;
    }
}
