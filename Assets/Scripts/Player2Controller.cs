using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int hp = 100;

    private Vector2 movement;

    public Rigidbody2D rb;
    public Animator animator;
    public Transform firePoint1;
    public GameObject bulletPrefab;
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("leftright", (movement.x));
        animator.SetFloat("updown", (movement.y));

        //input
        movement.x = Input.GetAxisRaw("Horizontal1") * moveSpeed;
        movement.y = Input.GetAxisRaw("Vertical1") * moveSpeed;

        if (Input.GetButtonDown ("Fire2")) 
        {
            var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

            if(animatorStateInfo.IsName("idle up") || animatorStateInfo.IsName("up"))
            {
                firePoint1.Rotate(0,0,0);
                Attack();
            }
            else if(animatorStateInfo.IsName("idle right") || animatorStateInfo.IsName("right"))
            {
                firePoint1.Rotate(0,0,-90);
                Attack();
                firePoint1.Rotate(0,0,+90);
            }
            else if(animatorStateInfo.IsName("idle down") || animatorStateInfo.IsName("down"))
            {
                firePoint1.Rotate(0,0,180);
                Attack();
                firePoint1.Rotate(0,0,-180);
            }
            else if(animatorStateInfo.IsName("idle left") || animatorStateInfo.IsName("left"))
            {
                firePoint1.Rotate(0,0,90);
                Attack();
                firePoint1.Rotate(0,0,-90);
            }
        }
    }

    void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    void Attack () 
    {
        Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);    
    }

    public void TakeDamage (int damage) 
    {
        hp -= damage;

        if (hp <= 0) 
        {
            Die ();
        }
    }

    void Die () 
    {
        Destroy (gameObject); // ska stänga av kontrollerna och visa resultat och en restart knapp eller knapp till menyn
    }
}