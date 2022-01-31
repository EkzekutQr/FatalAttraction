using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField]

    private float hP = 10;

    public float _HP
    {
        get
        {
            return hP;
        }
        private set { }
    }
    void Start()
    {

    }
    public void TakingDamage(float damage)
    {
        hP = hP - damage;
        Debug.Log("hitIsTaken");
        if (_HP <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Debug.Log(gameObject.name + "Dead");
        Destroy(gameObject);
    }
}
