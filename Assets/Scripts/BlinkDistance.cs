using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkDistance : MonoBehaviour
{

    [SerializeField]
    List<Collider> colliders;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            colliders.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            colliders.Remove(other);
        }
    }
    public void CollidersCheck()
    {
        foreach (Collider collider in colliders.ToArray())
        {
            Debug.Log(collider);

            if (collider == null)
            {
                colliders.Remove(collider);
            }
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
