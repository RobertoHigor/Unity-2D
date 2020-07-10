using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] int projectileDamage = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I hit:" + collision.name);
        // var health
        Attacker attacker = collision.GetComponent<Attacker>();
        Health health = collision.GetComponent<Health>();    

        // checando se possuí o script attacker.
        // Porém, por estar utilizando layers, não é necessário

        if (attacker && health)
        {   
            health.DealDamage(projectileDamage);
            Destroy(gameObject);
        }
    }
}
