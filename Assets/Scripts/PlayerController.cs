using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]

    private float speed = 10f;

    [SerializeField]

    private float jumpForce = 50f;


    private bool _isGrounded;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
    }

    private float moveHorizontal = 0;

    private float moveVertical = 0;

    private Vector3 movement = new Vector3(0, 0, 0);

    private float accelerate = 0.1f;

    private void MovementLogic()
    {

        //����������� �� �����������

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)) //��������� �������� ���� ������ ��� ������
        {
            moveHorizontal = moveHorizontal * 0.9f;
        }

        else if (Input.GetKey(KeyCode.D))                       //�������� ������
        {
            if (moveHorizontal != 1 && moveHorizontal < 1)
                moveHorizontal = moveHorizontal + accelerate;   //������� ��������� ��������
        }

        else if (Input.GetKey(KeyCode.A))                       //�������� �����
        {
            if (moveHorizontal != -1 && moveHorizontal > -1)
                moveHorizontal = moveHorizontal - accelerate;   //������� ��������� ��������
        }

        else
        {
            if (_isGrounded)
                moveHorizontal = moveHorizontal * 0.9f;             //��������� �������� ���� �� ���� ������ �� ������
        }

        //����������� �� ���������

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            moveVertical = moveVertical * 0.9f;
        }

        else if (Input.GetKey(KeyCode.W))
        {
            if (moveVertical != 1 && moveVertical < 1)
                moveVertical = moveVertical + accelerate;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            if (moveVertical != -1 && moveVertical > -1)
                moveVertical = moveVertical - accelerate;
        }

        else
        {
            if (_isGrounded)
                moveVertical = moveVertical * 0.9f;
        }

        //�������� � ����������� �������

        rb.velocity = new Vector3(moveHorizontal * speed, rb.velocity.y, moveVertical * speed);
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }

    public void SelectAbility(string abilityName)
    {

        switch (abilityName)
        {
            case "FatalAttraction":

                gameObject.AddComponent<FatalAttraction>();

                Destroy(gameObject.GetComponent<Cyclone>());

                Debug.Log("FA");

                break;

            case "BaseHit":

                gameObject.AddComponent<Cyclone>();

                Destroy(gameObject.GetComponent<FatalAttraction>());

                Debug.Log("BH");

                break;
        }
    }
}

