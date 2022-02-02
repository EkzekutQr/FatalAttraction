using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    [SerializeField]
    float speed = 10f;

    [SerializeField]
    GameObject player;

    Rigidbody rb;

    List<Collider> attackZoneColliders;

    [SerializeField]
    bool playerInAttackZone;

    private void Start()
    {
        if(player == null)
        {

            player = GameObject.FindGameObjectWithTag("Player");

        }

        rb = gameObject.GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        attackZoneColliders = gameObject.GetComponent<Hit>().AttackZoneColliders;

        if (player != null)
        {
            foreach(Collider collider in attackZoneColliders)
            {
                if(collider == player.GetComponent<Collider>())
                {
                    playerInAttackZone = true;
                }
            }
            if (!playerInAttackZone)
            {
                MovementLogic();
            }
        }

        playerInAttackZone = false;
        
    }

    private void MovementLogic()
    {
        Vector3 moveDirection;

        gameObject.transform.LookAt(new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z));

        moveDirection = player.transform.position - gameObject.transform.position;

        moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);

        rb.velocity = moveDirection.normalized * speed;
    }


}
