using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    [SerializeField]
    List<Collider> colliders;

    [SerializeField]
    string attackTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == attackTag)
        {
            colliders.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == attackTag)
        {
            colliders.Remove(other);
        }
    }

    public List<Collider> Colliders
    {
        get
        {
            return colliders;
        }
        private set
        {

        }
    }
}
