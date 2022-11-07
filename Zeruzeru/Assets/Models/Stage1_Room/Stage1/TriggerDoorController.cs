using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool openTrigger =false;


    [SerializeField] private string doorOpen = "DoorOpen";
    [SerializeField] private string doorClose = "DoorClose";

    public GameObject BoxCollider;


    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.Space) && openTrigger != true)
            {
                myDoor.Play(doorOpen, 0 , 0.0f);
                openTrigger = true;
                BoxCollider.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && openTrigger == true)
        {
            myDoor.Play(doorClose , 0, 0.0f);
            openTrigger = false;
            BoxCollider.SetActive(true);
        }
    }
}
