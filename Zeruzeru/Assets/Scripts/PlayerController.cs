using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3;
    public float runSpeed = 4;
    public float turnSpeed = 10f;
    public float jumpForce;
    private bool IsWalking;

    public Rigidbody m_Rb;
    public Animator PoliceAni;

    float move_H;
    float move_V;

    float PlayerRotate = 0;

    public StaminaController _staminaController;

    void Start()
    {
        //_staminaController = GetComponent<StaminaController>();
        m_Rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        move_H = Input.GetAxis("Horizontal");

        if (VerticalMove.VerticalMoving == true)
        {
            move_V = Input.GetAxis("Vertical");
        }else
        {
            move_V = 0f;
        }

        Vector3 targetRotation = transform.rotation.eulerAngles;

        if (
            Input.GetKey(KeyCode.LeftShift) &&
            _staminaController.playerStamina > 0
        )
        {
            IsWalking = false;
        }
        else
        {
            IsWalking = true;
        }

        if (IsWalking)
        {
            _staminaController.weAreSprinting = false;
            m_Rb.velocity =
                new Vector3(move_H * moveSpeed,
                    m_Rb.velocity.y,
                    move_V * moveSpeed);
        }
        if (!IsWalking && (move_H != 0 || move_V !=0))
        {
            if (_staminaController.playerStamina > 0)
            {
                _staminaController.weAreSprinting = true;
                _staminaController.Sprinting();
                m_Rb.velocity =
                    new Vector3(move_H * runSpeed,
                        m_Rb.velocity.y,
                        move_V * runSpeed);

                print(m_Rb.velocity);
            }
            else
            {
                IsWalking = true;
            }
        }

        //Police Animate Controller
        if (move_H < 0)
        {
            targetRotation.y = 270;
            PoliceAni.SetBool("Walking", true);
        }
        if (move_H > 0)
        {
            targetRotation.y = 90;
            PoliceAni.SetBool("Walking", true);
        }

        if (VerticalMove.VerticalMoving == true)
        {
            if (move_V < 0)
            {
                targetRotation.y = 180;
                PoliceAni.SetBool("Walking", true);
            }
            if (move_V > 0)
            {
                targetRotation.y = 0;
                PoliceAni.SetBool("Walking", true);
            }
            if (move_H > 0 && move_V > 0)
            {
                targetRotation.y = 45;
                PoliceAni.SetBool("Walking", true);
            }
            if (move_H > 0 && move_V < 0)
            {
                targetRotation.y = 135;
                PoliceAni.SetBool("Walking", true);
            }
            if (move_H < 0 && move_V > 0)
            {
                targetRotation.y = 315;
                PoliceAni.SetBool("Walking", true);
            }
            if (move_H < 0 && move_V < 0)
            {
                targetRotation.y = 225;
                PoliceAni.SetBool("Walking", true);
            }
        }

        if (
            Input.GetKey(KeyCode.LeftShift) &&
            _staminaController.playerStamina > 0
        )
        {
            PoliceAni.SetBool("Running", true);
        }
        else
        {
            PoliceAni.SetBool("Running", false);
        }

        if (move_H == 0 && move_V == 0)
        {
            PoliceAni.SetBool("Walking", false);
            PoliceAni.SetBool("Running", false);
        }

        transform.rotation =
            Quaternion
                .Lerp(transform.rotation,
                Quaternion.Euler(targetRotation),
                Time.fixedDeltaTime * turnSpeed);
        //m_Rb.velocity = new Vector3(move_H * moveSpeed , m_Rb.velocity.y , move_V * moveSpeed);

        /*if(Input.GetButtonDown("Jump"))
        {
            m_Rb.velocity = new Vector3(m_Rb.velocity.x , jumpForce , m_Rb.velocity.z);
        }*/
    }
}
