using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //config params
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f; // padding entre as bordas
    [SerializeField] int health = 5;

    [Header("Projectile")]
    [SerializeField] GameObject playerLaser;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;

    [Header("Sounds")]
    [SerializeField] AudioClip explosionSound;
     [SerializeField] AudioClip laserSound;

    Coroutine firingCoroutine;

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
      Fire();
    }

    private void Move()
    {
        // Utilizando o Unity input manager
        // deltaTime serve para não prender o jogo ao framerate.
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(
            transform.position.x + deltaX, xMin, xMax);  
        var newYPos = Mathf.Clamp(
            transform.position.y + deltaY, yMin, yMax); 
        
        transform.position = new Vector2(newXPos, newYPos);   
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {            
            firingCoroutine = StartCoroutine(FireContinuously());       
        }
        if (Input.GetButtonUp("Fire1"))
        { // Parar a corrotina após soltar o botão
            StopCoroutine(firingCoroutine); // Parar todas as corrotinas do Player.cs
        }
    }

    IEnumerator FireContinuously()
    {
       while (true) 
       { // Atirar infinitamente após iniciar a corrotina
            // Instanciar um laser na posição do jogador
            // Quarternion.identity serve para utilizar a rotação atual.
            GameObject laser = Instantiate(
                playerLaser, 
                transform.position, 
                Quaternion.identity) as GameObject;            
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);  
            GetComponent<AudioSource>().PlayOneShot(laserSound);
            yield return new WaitForSeconds(projectileFiringPeriod);
       }
    }

    private void SetUpMoveBoundaries() 
    {
        Camera gameCamera = Camera.main;
        // World space value do X
        xMin = gameCamera.ViewportToWorldPoint(
            new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(
            new Vector3(1, 0, 0)).x - padding; 
        yMin = gameCamera.ViewportToWorldPoint(
            new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(
            new Vector3(0, 1, 0)).y - padding;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Acessando o componente damageDealer para pegar o dano
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>(); 
        if (!damageDealer)
        { // Protegendo contra null exception, no caso de não existir o componente.
            return;
        }      
        ProcessDamage(damageDealer);
    }

    private void ProcessDamage(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(
                explosionSound,
                Camera.main.transform.position, 
                10f);
            Destroy(gameObject);
        }
    }
}
