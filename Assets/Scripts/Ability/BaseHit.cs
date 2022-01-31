using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseHit : MonoBehaviour
{
    [SerializeField]
    protected float damage;

    [SerializeField]
    protected float hitDelay;

    [SerializeField]
    protected List<Collider> colliders;

    [SerializeField]
    protected bool canHit = true;

    [SerializeField]
    protected GameObject player;

    [SerializeField]
    protected GameObject attackZone;


    virtual protected void Start()
    {
        damage = 5;

        hitDelay = 1;

        if(player == null)
        {
            player = gameObject;
        }

        if(attackZone == null)
        {
            attackZone = player.transform.GetChild(0).gameObject;
        }
    }

    virtual protected void Update()
    {
        Hit(damage, hitDelay);
    }

    virtual protected void DoItBeforeHit()
    {

    }

    virtual protected void DoItAfterHit()
    {

    }

    virtual protected void Hit(float damage, float hitDelay)
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (canHit)
            {
                DoItBeforeHit();
                HitLogic(damage);
                DoItAfterHit();
                StartCoroutine(HitDelay(hitDelay));
            }
        }
    }

    virtual protected void HitLogic(float damage)
    {
        if (colliders.Count != 0)
        {
            for (int i = colliders.Count - 1; i == 0; i--)
            {
                if (colliders[i] == null)
                {
                    colliders.Remove(colliders[i]);
                }
                else
                {
                    colliders[i].gameObject.GetComponent<HP>().TakingDamage(damage);
                    if (colliders[i].gameObject.GetComponent<HP>()._HP <= 0)
                    {
                        colliders[i].gameObject.GetComponent<HP>().Death();
                        colliders.Remove(colliders[i]);
                    }
                }
            }
        }
    }

    virtual protected IEnumerator HitDelay(float hitDelay)
    {
        Debug.Log("HitDelay");
        canHit = false;
        yield return new WaitForSeconds(hitDelay);
        canHit = true;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        colliders.Add(other);
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        colliders.Remove(other);
    }
}

