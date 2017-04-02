using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quick Note. Hitboxes are colliders that would supposedly do damage to an enemy. 
/// Hurtboxes receive damagae.
/// </summary>
public class Hitbox : MonoBehaviour {
    public float baseDamage = 1;


    void onHitboxEntered(Hitbox hBox)
    {
        //MAKE SURE TO DO STUFF HERE
    }

    void onHurtboxEntered(Hurtbox hBox)
    {
        //AND HERE
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Hurtbox hurtBox = collider.GetComponent<Hurtbox>();
        Hitbox hitBox = collider.GetComponent<Hitbox>();
        if (hurtBox != null)
        {
            onHurtboxEntered(hurtBox);
        }
        if (hitBox != null)
        {
            onHitboxEntered(hitBox);
        }
    }

    void OnTriggerExit2D (Collider2D collider)
    {

    }
}
