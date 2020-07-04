using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 2;
    [SerializeField] GameObject explosionParticle;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] float projectileSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
       shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots); 
    }

    // Update is called once per frame
    void Update()
    {
      CountDownAndShoot();  
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime; // - o tempo que o frame demora.
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject projectile = Instantiate(
            enemyProjectile,
            transform.position, 
            Quaternion.identity) as GameObject;

        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
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
            Explode();
        }
    }

    private void Explode()
    {
        //GameObject explosion;
        Instantiate(explosionParticle, transform.position, transform.rotation);
        Destroy(gameObject);
        //Destroy(explosion, durationOfExplosion);
    }
}
