using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This interface should be applied to any class that needs to have a reaction to a hit taking place. For instance
/// Health would implment this interface, because ideally the charcter would take damage after getting hit.
/// This may also be necessary for certain effects to take place.
/// </summary>

public interface IHitReact {
    void OnHit(Hitbox hBox);
}
