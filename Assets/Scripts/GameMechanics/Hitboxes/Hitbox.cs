using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quick Note. Hitboxes are colliders that would supposedly do damage to an enemy. 
/// Hurtboxes receive damagae.
/// If you plan on having just one constant hitbox or it will be a disposable object such as a projectile
/// you can use this class alone.
/// If you plan on focusing more on melee combat with multiple hitboxes, I heavily encourage using the hitbox manager.
/// The hitbox manager makes sure that the same object isn't hit multiple times in only one animation. It also keeps track of
/// every hitbox your character has active in any given animation.
/// </summary>
public class Hitbox : MonoBehaviour {
    public float baseDamage = 1;
    public int hitBoxRank = 1; //If one hitbox is higher ranked than the other, it will cancel the effects of that hitbox and continue to do damage
                               //Alternatively if they are the same rank, they will canel eachother out and no damage should be taken

    public HitboxManager manager { private get; set; }

    Transform parentObject;

    void Start()
    {
        Transform current = this.transform;
        while (current.parent != null) current = current.parent;

        parentObject = current;
    }


    void onHitboxEntered(Hitbox hBox)
    {
        //MAKE SURE TO DO STUFF HERE
        if (hBox.hitBoxRank >= this.hitBoxRank)
        {

        }
    }

    void onHurtboxEntered(Hurtbox hBox)
    {
        //AND HERE
    }

    void onHitboxExit(Hitbox hBox)
    {

    }

    void onHurtboxExit(Hurtbox hBox)
    {

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
