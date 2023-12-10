using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public int hp = 100;

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
