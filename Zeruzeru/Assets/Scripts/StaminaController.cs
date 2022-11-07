using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaminaController : MonoBehaviour
{
    [Header("Stamina Main Parameters")]
    public float playerStamina = 100.0f;
    [SerializeField] private float maxStamina = 100.0f;
    [HideInInspector] public bool hasRegenerated = true;
    [HideInInspector] public bool weAreSprinting = false;

    [Header("Stamina Regen Parameters")]
    [Range(0,50)] [SerializeField] private float StaminaDrain = 0.5f;
    [Range(0,50)] [SerializeField] private float StaminaRegen = 0.5f;

    [Header("Stamina Speed Parameters")]
    [SerializeField] private int slowedRunSpeed = 4;
    [SerializeField] private int normalRunSpeed = 8;

    [Header("Stamina UI Parameters")]
    [SerializeField] private Image StaminaProgressUIR = null;
    [SerializeField] private Image StaminaProgressUIL = null;
    [SerializeField] private CanvasGroup sliderCanvasGroup = null;

    public PlayerController PlayerController;

    private void Update()
    {
        if(!weAreSprinting)
        {
            if(playerStamina <= maxStamina - 0.01 && !Input.GetKey(KeyCode.LeftShift))
            {
                playerStamina +=StaminaRegen * Time.deltaTime;
                UpdateStamina(1);

                if(playerStamina >= maxStamina)
                {
                    //PlayerController.SetRunSpeed(normalRunSpeed);
                    sliderCanvasGroup.alpha = 0;
                    hasRegenerated = true;
                }
            }
        }
    }

    public void Sprinting()
    {
        if(hasRegenerated)
        {
            weAreSprinting = true;
            playerStamina -= StaminaDrain * Time.deltaTime;
            UpdateStamina(1);

            /*if(playerStamina <=0)
            {
                hasRegenerated = false;
                sliderCanvasGroup.alpha = 0;
            }*/
        }
    }

    void UpdateStamina(int value)
    {
        StaminaProgressUIR.fillAmount = playerStamina / maxStamina;
        StaminaProgressUIL.fillAmount = playerStamina / maxStamina;

        if(value == 0)
        {
            sliderCanvasGroup.alpha = 0;
        }
        else
        {
            sliderCanvasGroup.alpha = 1;
        }
    }
}
