using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{

    public float startingHealth;
    protected float health;
    protected bool dead;

    public event System.Action OnDeath;

    protected virtual void Start()
    {
        health = startingHealth;
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        //this method is left still because I plan to add particles at the point the bullet hits the enemy
        TakeDamage(damage);

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0 && !dead) {
            Die();
        }
    }

    protected void Die()
    {
        dead = true;
        if (OnDeath != null){
            OnDeath();
        }
        GameObject.Destroy(gameObject);
    }
}
