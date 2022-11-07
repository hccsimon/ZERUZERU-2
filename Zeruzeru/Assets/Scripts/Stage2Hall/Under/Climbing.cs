using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{   
    public bool z_Climbing =false;
    public ParentChanger ParentChanger;

    Collider m_Collider;
    Rigidbody m_Rigid;

    void Start()
    {
        m_Rigid = GetComponent<Rigidbody>();
        m_Collider = GetComponent<Collider>();

        Physics.IgnoreLayerCollision(3, 8);
    }

    void Update()
    {
        if(z_Climbing == true && Input.GetKeyDown(KeyCode.Space))
        {
            z_Climbing = false;
            m_Rigid.useGravity = true;
            m_Collider.enabled = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Rope") && z_Climbing == false)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                z_Climbing = true;
                m_Collider.enabled = false;
                m_Rigid.useGravity = false;
                ParentChanger.num = 1;
            }
        }

        if(other.CompareTag("Rope2") && z_Climbing == false)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                z_Climbing = true;
                m_Collider.enabled = false;
                m_Rigid.useGravity = false;
                ParentChanger.num = 2;
            }
        }

        if(other.CompareTag("Rope3") && z_Climbing == false)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                z_Climbing = true;
                m_Collider.enabled = false;
                m_Rigid.useGravity = false;
                ParentChanger.num = 3;
            }
        }

        if(other.CompareTag("Rope4") && z_Climbing == false)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                z_Climbing = true;
                m_Collider.enabled = false;
                m_Rigid.useGravity = false;
                ParentChanger.num = 4;
            }
        }
    }

}
