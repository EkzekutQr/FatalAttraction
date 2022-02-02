using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatalAttraction : BaseHit
{

    [SerializeField]
    Vector3 position;

    [SerializeField]
    float blinkDistance;

    [SerializeField]
    GameObject goBlinkDistance;

    [SerializeField]
    List<Collider> blinkDistanceColliders;

    [SerializeField]
    int colliderNumber;

    protected override void Start()
    {
        base.Start();

        Debug.Log(gameObject.transform.childCount);

        if (goBlinkDistance == null)
        {

            goBlinkDistance = GetChild("BlinkDistance");

        }
    }

    protected override void DoItBeforeHit()
    {
        base.DoItBeforeHit();

        Blink();
    }

    private void Blink()
    {
        goBlinkDistance.GetComponent<BlinkDistance>().CollidersCheck();

        blinkDistanceColliders = goBlinkDistance.GetComponent<BlinkDistance>().Colliders;

        Collider randomCollider;

        if (blinkDistanceColliders.Count != 0)
        {

            randomCollider = RandomCollider();

            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            gameObject.transform.position = randomCollider.transform.position + RandomPosition();

            gameObject.transform.LookAt(randomCollider.transform.position);

            gameObject.transform.position = gameObject.transform.position + randomCollider.transform.position - attackZone.transform.position;

            

            gameObject.transform.LookAt(randomCollider.transform.position);
        }
    }

    private Collider RandomCollider()
    {

        int randomCollider;

        randomCollider = Random.Range(0, blinkDistanceColliders.Count);

        colliderNumber = randomCollider;

        return blinkDistanceColliders[randomCollider];

    }

    private Vector3 RandomPosition()
    {

        Vector3 position;

        #region old
        //int[] num = new int[2];
        //num[0] = 2;
        //num[1] = -2;

        //int[] randomNum = new int[3];

        ////for (int i = 0; i <= 2; i++)
        ////{
        ////    randomNum[i] = Random.Range(0, 2);
        ////    Debug.Log(randomNum[i]);
        ////}

        //positon = new Vector3(num[randomNum[0]], 0, num[randomNum[2]]);

        //oldPosition = new Vector3(num[randomNum[0]], 0, num[randomNum[2]]);
        #endregion

        float[] randomNum = new float[3];

        for(int i = 0; i <= 2; i++)
        {
            randomNum[i] = Random.Range(-2f, 2f);
        }

        position = new Vector3(randomNum[0], 0, randomNum[2]);

        return position;

    }

}
