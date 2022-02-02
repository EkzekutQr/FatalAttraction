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

    BaseHit currentAbility;

    // Start is called before the first frame update
    void Start()
    {
        if(currentAbility == null)
        {
            currentAbility = new FatalAttraction();

            //if(new FatalAttraction() is BaseHit)
            //currentAbility = new FatalAttraction();
        }

        //Debug.Log(currentAbility.GetType().Name);

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

            gameObject.transform.LookAt(new Vector3(gameObject.transform.position.x + moveHorizontal, gameObject.transform.position.y, gameObject.transform.position.z + moveVertical));
        }

        else if (Input.GetKey(KeyCode.A))                       //�������� �����
        {
            if (moveHorizontal != -1 && moveHorizontal > -1)
                moveHorizontal = moveHorizontal - accelerate;   //������� ��������� ��������

            gameObject.transform.LookAt(new Vector3(gameObject.transform.position.x + moveHorizontal, gameObject.transform.position.y, gameObject.transform.position.z + moveVertical));
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

            gameObject.transform.LookAt(new Vector3(gameObject.transform.position.x + moveHorizontal, gameObject.transform.position.y, gameObject.transform.position.z + moveVertical));
        }

        else if (Input.GetKey(KeyCode.S))
        {
            if (moveVertical != -1 && moveVertical > -1)
                moveVertical = moveVertical - accelerate;

            gameObject.transform.LookAt(new Vector3(gameObject.transform.position.x + moveHorizontal, gameObject.transform.position.y, gameObject.transform.position.z + moveVertical));
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

                Destroy(gameObject.GetComponent(currentAbility.GetType()));

                currentAbility = new FatalAttraction();

                gameObject.AddComponent(currentAbility.GetType());

                break;

            case "Cyclone":

                Destroy(gameObject.GetComponent(currentAbility.GetType()));

                currentAbility = new Cyclone();

                gameObject.AddComponent(currentAbility.GetType());

                break;
        }
    }
}

