using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour {
    public float maxHealth = 100;
    public float currentHealth { get; private set; }
    Animator anim;

    void Awake()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            anim.SetTrigger("Kill");
        }
    }

    public virtual void killSelf()
    {
        Destroy(this.gameObject);
    }
}
