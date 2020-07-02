using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeFIeld] float padding = 1f; // padding entre as bordas

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
      Move(); 
    }

    private void Move()
    {
        // Utilizando o Unity input manager
        // deltaTime serve para não prender o jogo ao framerate.
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);  
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax); 
        transform.position = new Vector2(newXPos, newYPos);   
    }

    private void SetUpMoveBoundaries() 
    {
        Camera gameCamera = Camera.main;
        // World space value do X
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding; 
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
