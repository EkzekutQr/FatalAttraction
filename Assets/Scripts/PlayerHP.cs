using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : HP
{
    public delegate void Methods();

    public event Methods OnPlayerDeath;

    protected override void Start()
    {
        base.Start();


    }

    public override void Death()
    {
        base.Death();

        OnPlayerDeath();
    }
}
