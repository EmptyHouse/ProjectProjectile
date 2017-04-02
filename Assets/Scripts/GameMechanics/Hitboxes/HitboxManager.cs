using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ideally Hitboxes will all be stored into one parent object, especially for melee based combat.
/// </summary>

public class HitboxManager : MonoBehaviour {
    Hitbox[] allHitboxes;

    void Start()
    {
        allHitboxes = GetComponentsInChildren<Hitbox>();
        foreach (Hitbox h in allHitboxes)
        {
            h.manager = this;
        }
    }
}
