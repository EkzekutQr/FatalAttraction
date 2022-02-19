using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HP : MonoBehaviour
{
    [SerializeField]
    protected float hP = 10;

    public virtual float _HP
    {
        get
        {
            return hP;
        }
        private set { }
    }
    protected virtual void Start()
    {

    }
    public virtual void TakingDamage(float damage)
    {
        hP = hP - damage;
        Debug.Log("hitIsTaken");
        //if (_HP <= 0)
        //{
        //    Death();
        //}
    }
    public virtual void Death()
    {
        Debug.Log(gameObject.name + "Dead");
        Destroy(gameObject);
    }
}
