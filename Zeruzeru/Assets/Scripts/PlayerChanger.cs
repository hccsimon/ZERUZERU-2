using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChanger : MonoBehaviour
{
    [Header("Police")]
    public PlayerController _Player1Controller;
    public StaminaController _Player1Stamina;
    public Animator Player1Anim;

    [Header("Zeruzeru")]
    public ZeruController _Player2Controller;
    public ZeruStaminaController _Player2Stamina;
    public Animator Player2Anim;

    [Header("Else")]
    public int PlayerNumber;


    public void Changer(int current)
    {
        if(current == 1) //Player1
        {
            _Player1Controller.enabled =true;
            _Player1Stamina.enabled =true;
            Player1Anim.enabled = true;

            _Player2Controller.enabled =false;
            _Player2Stamina.enabled =false;
            Player2Anim.enabled = false;

            PlayerNumber = 1;
        }

        if(current == 2) //Player2
        {
            _Player1Controller.enabled =false;
            _Player1Stamina.enabled =false;
            Player1Anim.enabled = false;

            _Player2Controller.enabled =true;
            _Player2Stamina.enabled =true;
            Player2Anim.enabled =true;

            PlayerNumber = 2;
        }

        if(current == 3) // Both can't moving
        {
            _Player1Controller.enabled =false;
            _Player1Stamina.enabled =false;
            Player1Anim.enabled = false;

            _Player2Controller.enabled =false;
            _Player2Stamina.enabled =false;
            Player2Anim.enabled =false;
        }
    }
}
