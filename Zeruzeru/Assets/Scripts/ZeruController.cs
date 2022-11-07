using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeruController : MonoBehaviour
{
    public float moveSpeed = 3;
    public float runSpeed = 4;
    public float turnSpeed = 10f;
    public float jumpForce;
    private bool IsWalking;

    public Rigidbody m_Rb;
    public Animator ZeruAni;

    float move_H;
    float move_V;
    bool isGround = true;

    float PlayerRotate = 0;

    public ZeruStaminaController _ZerustaminaController;

    void Start()
    {
        //_staminaController = GetComponent<StaminaController>();
        m_Rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        move_H = Input.GetAxis("Horizontal");

        if (UnderPoliceRoom.VerticalMoving2 == true)
        {
            move_V = Input.GetAxis("Vertical");
        }else
        {
            move_V = 0f;
        }

        Vector3 targetRotation = transform.rotation.eulerAngles;

        if (
            Input.GetKey(KeyCode.LeftShift) &&
            _ZerustaminaController.playerStamina > 0
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
            _ZerustaminaController.weAreSprinting = false;
            m_Rb.velocity =
                new Vector3(move_H * moveSpeed,
                    m_Rb.velocity.y,
                    move_V * moveSpeed);
        }
        if (!IsWalking && move_H != 0)
        {
            if (_ZerustaminaController.playerStamina > 0)
            {
                _ZerustaminaController.weAreSprinting = true;
                _ZerustaminaController.Sprinting();
                m_Rb.velocity =
                    new Vector3(move_H * runSpeed,
                        m_Rb.velocity.y,
                        move_V * moveSpeed);
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
            ZeruAni.SetBool("Walking", true);
        }
        if (move_H > 0)
        {
            targetRotation.y = 90;
            ZeruAni.SetBool("Walking", true);
        }

        if (UnderPoliceRoom.VerticalMoving2 == true)
        {
            if (move_V < 0)
            {
                targetRotation.y = 180;
                ZeruAni.SetBool("Walking", true);
            }
            if (move_V > 0)
            {
                targetRotation.y = 0;
                ZeruAni.SetBool("Walking", true);
            }
            if (move_H > 0 && move_V > 0)
            {
                targetRotation.y = 45;
                ZeruAni.SetBool("Walking", true);
            }
            if (move_H > 0 && move_V < 0)
            {
                targetRotation.y = 135;
                ZeruAni.SetBool("Walking", true);
            }
            if (move_H < 0 && move_V > 0)
            {
                targetRotation.y = 315;
                ZeruAni.SetBool("Walking", true);
            }
            if (move_H < 0 && move_V < 0)
            {
                targetRotation.y = 225;
                ZeruAni.SetBool("Walking", true);
            }
        }

        if (
            Input.GetKey(KeyCode.LeftShift) &&
            _ZerustaminaController.playerStamina > 0
        )
        {
            ZeruAni.SetBool("Running", true);
        }
        else
        {
            ZeruAni.SetBool("Running", false);
        }

        if (move_H == 0 && move_V == 0)
        {
            ZeruAni.SetBool("Walking", false);
            ZeruAni.SetBool("Running", false);
        }

        transform.rotation =
            Quaternion
                .Lerp(transform.rotation,
                Quaternion.Euler(targetRotation),
                Time.fixedDeltaTime * turnSpeed);
        //m_Rb.velocity = new Vector3(move_H * moveSpeed , m_Rb.velocity.y , move_V * moveSpeed);

        if(Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            m_Rb.velocity = new Vector3(m_Rb.velocity.x , jumpForce , m_Rb.velocity.z);
            ZeruAni.SetTrigger("Jump");
            //isGround = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }


}
