using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentChanger : MonoBehaviour
{
    public GameObject ZeruPlayer;
    public GameObject ClimbingPoint;
    public GameObject ClimbingPoint2;
    public GameObject ClimbingPoint3;
    public GameObject ClimbingPoint4;

    public static int num;
    public Climbing Climbing;

    void Update()
    {
        if(Climbing.z_Climbing == true)
        {
            if(num == 1)
            {
                Rope1();
            }
            else if (num == 2)
            {
                Rope2();
            }
            else if (num == 3)
            {
                Rope3();
            }
            else if (num == 4)
            {
                Rope4();
            }
        }
    }

    void Rope1()
    {
        ZeruPlayer.transform.position = ClimbingPoint.transform.position;
    }

    void Rope2()
    {
        ZeruPlayer.transform.position = ClimbingPoint2.transform.position;
    }  

    void Rope3()
    {
        ZeruPlayer.transform.position = ClimbingPoint3.transform.position;
    } 

    void Rope4()
    {
        ZeruPlayer.transform.position = ClimbingPoint4.transform.position;
    }         

}

