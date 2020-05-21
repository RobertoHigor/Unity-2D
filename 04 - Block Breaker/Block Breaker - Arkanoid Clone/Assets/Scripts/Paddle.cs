using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float maxPosX = 15f;
    [SerializeField] float minPosX = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* x / Screen.width retorna um valor entre 0 a 1.
        * Serve para movimentar o mouse de acordo com a largura da tela.
        * 16 é o número de unidades no eixo Y. 
        * Isso se deve pois a câmera possui um size 6, que em um aspecto 4:3 dá 16 unidades de largura.
        */
        // Converter o resultado para World Units.
        float mousePosInUnits = (Input.mousePosition.x / Screen.width) * screenWidthUnits;
        //Debug.Log(mousePosInUnits);

        // Vector2 é um jeito de armazenar as coordenadas x e y.
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minPosX, maxPosX);
        transform.position = paddlePos;
    }
}
