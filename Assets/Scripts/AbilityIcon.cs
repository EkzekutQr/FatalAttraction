using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIcon : MonoBehaviour
{
    [SerializeField]
    string keyCodeIndex;

    [SerializeField]
    string abilityName;

    [SerializeField]
    GameObject player;

    private void Start()
    {

    }

    private void Update()
    {
        AcivateAbility();
    }

    private void AcivateAbility()
    {
        if (Input.GetKeyDown((KeyCode)int.Parse(keyCodeIndex)))
        player.GetComponent<PlayerController>().SelectAbility(abilityName);
    }

}
