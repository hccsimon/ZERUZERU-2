using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public GameObject RopeButton;
    public GameObject RopeButton2;
    public GameObject RopeButton3;
    public GameObject RopeButton4;
    public Climbing Climbing;

    

    public float SwingPower = 5f;
    
    void Update()
    {
        if(ParentChanger.num == 1)
        {
            float Horizontal = Input.GetAxis("Horizontal") * SwingPower;
            float Vertical = Input.GetAxis("Vertical") * SwingPower;

            //RopeButton.GetComponent<Rigidbody>().AddForce(transform.forward * Vertical, ForceMode.Force);
            RopeButton.GetComponent<Rigidbody>().AddForce(transform.right * Horizontal, ForceMode.Force);
        }

        if(ParentChanger.num == 2)
        {
            float Horizontal = Input.GetAxis("Horizontal") * SwingPower;
            float Vertical = Input.GetAxis("Vertical") * SwingPower;

            //RopeButton2.GetComponent<Rigidbody>().AddForce(transform.forward * Vertical, ForceMode.Acceleration);
            RopeButton2.GetComponent<Rigidbody>().AddForce(transform.right * Horizontal, ForceMode.Force);
        }

        if(ParentChanger.num == 3)
        {
            float Horizontal = Input.GetAxis("Horizontal") * SwingPower;
            float Vertical = Input.GetAxis("Vertical") * SwingPower;

            //RopeButton3.GetComponent<Rigidbody>().AddForce(transform.forward * Vertical, ForceMode.Acceleration);
            RopeButton3.GetComponent<Rigidbody>().AddForce(transform.right * Horizontal, ForceMode.Force);
        }

        if(ParentChanger.num == 4)
        {
            float Horizontal = Input.GetAxis("Horizontal") * SwingPower;
            float Vertical = Input.GetAxis("Vertical") * SwingPower;

            //RopeButton4.GetComponent<Rigidbody>().AddForce(transform.forward * Vertical, ForceMode.Acceleration);
            RopeButton4.GetComponent<Rigidbody>().AddForce(transform.right * Horizontal, ForceMode.Force);
        }
    }
}
