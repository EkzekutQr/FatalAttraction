using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIcon : MonoBehaviour
{
    [SerializeField]
    string abilityName;

    [SerializeField]
    GameObject player;

    string text;
    int _text;

    private void Start()
    {
        text = gameObject.GetComponentInChildren<Text>().text;
        _text = int.Parse(text);
    }

    private void Update()
    {
        AcivateAbility();
    }

    private void AcivateAbility()
    {
        if (Input.GetKeyDown((KeyCode)_text))
        player.GetComponent<PlayerController>().SelectAbility(abilityName);
    }

}
