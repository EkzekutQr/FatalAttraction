using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    abstract void Hit(float damage, float hitDelay, bool needPushOnKey);

    abstract void DoItBeforeHit();

    abstract void DoItAfterHit();
}
