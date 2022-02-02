using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject _camera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        _camera.transform.position = player.transform.position + new Vector3(0, 9, -9);
    }
}
