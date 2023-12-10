using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float time = 2f;
    private int damage = 20;
    private int monsterdamage = 0;
    

    private GameObject bulletPrefab;

    // Start is called before the first frame update
    private void Start()
    {
        rb.velocity = transform.right * speed;

    }
    private void BulletDie()
    {
        Destroy(gameObject,time = 0f);
    }

    void Update ()
    {
        Destroy(gameObject,time);
        
    }
    
    private void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        PlayerController player1 = hitInfo.GetComponent<PlayerController>();
        if(player1 != null)
        {
            Physics.IgnoreLayerCollision(10, 11);
            player1.TakeDamage(monsterdamage);
        }
        // Instantiate(impactEffect, transform.position, transform.rotation); // gör en effect om man har en

        Player2Controller player2 = hitInfo.GetComponent<Player2Controller>();
        if(player2 != null)
        {
            Physics.IgnoreLayerCollision(11, 12);
            player2.TakeDamage(monsterdamage); 
        }
        
        monster_controller monster = hitInfo.GetComponent<monster_controller>();
        if(monster != null)
        {
            Physics.IgnoreLayerCollision(13,11);
            monster.TakeDamage(damage);
        }
    }
}