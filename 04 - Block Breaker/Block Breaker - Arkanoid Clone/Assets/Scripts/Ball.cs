using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xForce = 2f;
    [SerializeField] float yForce = 15f;
    bool hasStarted = false;

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
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(
            paddle1.transform.position.x,
            paddle1.transform.position.y
        );
        // A posição da bola segue a posição do paddle
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnMouseClick()
    {        
        if (Input.GetMouseButtonUp(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xForce, yForce);
        }
    }
}