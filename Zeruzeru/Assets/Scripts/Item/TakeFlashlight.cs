using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeFlashlight : MonoBehaviour
{
    //This is the script for "Flashlight" on Police's room table

    public GameObject Flashlight; //Item on table
    public GameObject ForShowing;

    private bool Showing = false;
    

    void OnTriggerStay(Collider TakingZone)
    {
        if(TakingZone.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.Space) )
            {
                ForShowing.SetActive(true);
                Destroy(Flashlight);
            }
        }
    }
}
