using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseHit : MonoBehaviour, IAbility
{
    [SerializeField]
    protected float damage;

    [SerializeField]
    protected float hitDelay;

    [SerializeField]
    protected List<Collider> attackZoneColliders;

    [SerializeField]
    protected bool canHit = true;

    [SerializeField]
    protected GameObject player;

    [SerializeField]
    protected GameObject attackZone;

    [SerializeField]
    protected List<GameObject> childs = new List<GameObject>();

    [SerializeField]
    bool needPushOnKey = true;

    protected virtual void Start()
    {


        if (damage == 0)
            damage = 5;

        if (hitDelay == 0)
            hitDelay = 1;

        GetAllChilds();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (attackZone == null)
        {

            attackZone = GetChild("AttackZone");

        }
    }

    protected virtual void FixedUpdate()
    {
        Hit(damage, hitDelay, needPushOnKey);
    }

    public virtual void DoItBeforeHit()
    {

    }

    public virtual void DoItAfterHit()
    {

    }

    public void Hit(float damage, float hitDelay, bool needPushOnKey)
    {
        if (needPushOnKey)
        {
            if (Input.GetKey(KeyCode.F))
            {
                if (canHit)
                {

                    DoItBeforeHit();

                    attackZoneColliders = attackZone.GetComponent<AttackZone>().Colliders;

                    if (attackZoneColliders != null)
                        if (attackZoneColliders.Count != 0)
                        {
                            HitLogic(damage);
                            DoItAfterHit();
                            StartCoroutine(HitDelay(hitDelay));
                        }
                }
            }
        }
        else
        {
            if (canHit)
            {

                DoItBeforeHit();

                attackZoneColliders = attackZone.GetComponent<AttackZone>().Colliders;

                if (attackZoneColliders != null)
                    if (attackZoneColliders.Count != 0)
                    {
                        HitLogic(damage);
                        DoItAfterHit();
                        StartCoroutine(HitDelay(hitDelay));
                    }
            }

        }
    }

    virtual protected void HitLogic(float damage)
    {
        for (int i = attackZoneColliders.Count - 1; i == 0; i--)
        {
            if (attackZoneColliders[i] == null)
            {
                attackZoneColliders.Remove(attackZoneColliders[i]);
            }
            else
            {
                attackZoneColliders[i].gameObject.GetComponent<HP>().TakingDamage(damage);
                if (attackZoneColliders[i].gameObject.GetComponent<HP>()._HP <= 0)
                {
                    attackZoneColliders[i].gameObject.GetComponent<HP>().Death();
                    attackZoneColliders.Remove(attackZoneColliders[i]);
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

    protected void GetAllChilds()
    {
        childs.Clear();

        for (int i = gameObject.transform.childCount - 1; i >= 0; i--)
        {
            Debug.Log(gameObject.transform.childCount);

            childs.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }

    protected GameObject GetChild(string childName)
    {
        GameObject currentChild = null;

        if (childs != null)
        {
            if (childs.Count != 0)
            {
                foreach (GameObject gameObject in childs)
                {
                    if (gameObject.name == childName)
                    {
                        currentChild = gameObject;
                        break;
                    }
                    else
                    {
                        currentChild = null;
                    }
                }

                return currentChild;

            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }

    }

    //protected virtual void OnTriggerEnter(Collider other)
    //{
    //    colliders.Add(other);
    //}

    //protected virtual void OnTriggerExit(Collider other)
    //{
    //    colliders.Remove(other);
    //}

    public virtual List<Collider> AttackZoneColliders
    {
        get
        {
            return attackZoneColliders;
        }
        protected set
        {

        }
    }
}

