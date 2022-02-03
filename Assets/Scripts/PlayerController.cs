using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]

    private float speed = 100f;

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
        }

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
        #region old move
        //Перемещение по горизонтали

        //if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)) //Остановка движения если нажаты обе кнопки
        //{
        //    moveHorizontal = moveHorizontal * 0.9f;
        //}

        //else if (Input.GetKey(KeyCode.D))                       //Движение вправо
        //{
        //    if (moveHorizontal != 1 && moveHorizontal < 1)
        //        moveHorizontal = moveHorizontal + accelerate;   //Плавное ускорение движения

        //    gameObject.transform.LookAt(new Vector3(gameObject.transform.position.x + moveHorizontal, gameObject.transform.position.y, gameObject.transform.position.z + moveVertical));
        //}

        //else if (Input.GetKey(KeyCode.A))                       //Движение влево
        //{
        //    if (moveHorizontal != -1 && moveHorizontal > -1)
        //        moveHorizontal = moveHorizontal - accelerate;   //Плавное ускорение движения

        //    gameObject.transform.LookAt(new Vector3(gameObject.transform.position.x + moveHorizontal, gameObject.transform.position.y, gameObject.transform.position.z + moveVertical));
        //}

        //else
        //{
        //    if (_isGrounded)
        //        moveHorizontal = moveHorizontal * 0.9f;             //Остановка движения если ни одна кнопка не нажата
        //}

        ////Перемещение по вертикали

        //if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        //{
        //    moveVertical = moveVertical * 0.9f;
        //}

        //else if (Input.GetKey(KeyCode.W))
        //{
        //    if (moveVertical != 1 && moveVertical < 1)
        //        moveVertical = moveVertical + accelerate;

        //    gameObject.transform.LookAt(new Vector3(gameObject.transform.position.x + moveHorizontal, gameObject.transform.position.y, gameObject.transform.position.z + moveVertical));
        //}

        //else if (Input.GetKey(KeyCode.S))
        //{
        //    if (moveVertical != -1 && moveVertical > -1)
        //        moveVertical = moveVertical - accelerate;

        //    gameObject.transform.LookAt(new Vector3(gameObject.transform.position.x + moveHorizontal, gameObject.transform.position.y, gameObject.transform.position.z + moveVertical));
        //}

        //else
        //{
        //    if (_isGrounded)
        //        moveVertical = moveVertical * 0.9f;
        //}

        //Движение в направление вектора

        //rb.velocity = new Vector3(moveHorizontal * speed, rb.velocity.y, moveVertical * speed);



        //float magnitude = rb.velocity.magnitude;

        //float accelerateMagnitude;

        //if (magnitude < speed)
        //{
        //    accelerateMagnitude = speed - magnitude;
        //}
        //else
        //{
        //    accelerateMagnitude = 0;
        //}

        //rb.AddForce(new Vector3(moveHorizontal / accelerateMagnitude, 0, moveVertical / accelerateMagnitude).normalized);
        #endregion

        Vector3 moveDirection;

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            moveVertical = 0;
        }

        else if (Input.GetKey(KeyCode.W))
        {
            if (rb.velocity.z <= speed)
            {
                moveVertical = 1;
            }

            else
            {
                moveVertical = 0;
            }
        }

        else if (Input.GetKey(KeyCode.S))
        {
            if (rb.velocity.z >= speed * -1)
            {
                moveVertical = -1;
            }

            else
            {
                moveVertical = 0;
            }
        }

        else
        {
            moveVertical = 0;
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
        {
            moveHorizontal = 0;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x <= speed)
            {
                moveHorizontal = 1;
            }

            else
            {
                moveHorizontal = 0;
            }
        }

        else if (Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.x >= speed * -1)
            {
                moveHorizontal = -1;
            }

            else
            {
                moveHorizontal = 0;
            }
        }

        else
        {
            moveHorizontal = 0;
        }

        moveDirection = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);

        rb.velocity = rb.velocity - new Vector3(rb.velocity.x * 0.1f, 0, rb.velocity.z * 0.1f);

        transform.LookAt(transform.position + new Vector3(rb.velocity.x, 0, rb.velocity.z));


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

