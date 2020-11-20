using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{

    [SerializeField]
    private int stamina;
    private int currentStamina;

    [SerializeField]
    private int staminaIncreaseSpeed;

    [SerializeField]
    private int staminaRechargeTime;
    private int currentStaminaReChargeTime;

    private bool staminaUsed;

    [SerializeField]
    private Image[] images_Gauge;

    private const int SP = 0;
    
    void Start()
    {
        currentStamina = stamina;
    }

    void Update()
    {
        GagueUpdate();
        SPRecover();
        SPRechargeTime();
    }

    private void SPRechargeTime()
    {
        if (staminaUsed)
        {
            if(currentStaminaReChargeTime < staminaRechargeTime)
            {
                currentStaminaReChargeTime++;
            }
            else
            {
                staminaUsed = false;
            }
        }
    }

    private void SPRecover()
    {
        if(!staminaUsed && currentStamina < stamina)
        {
            currentStamina += staminaIncreaseSpeed;
        }
    }

    private void GagueUpdate()
    {
        images_Gauge[SP].fillAmount = (float)currentStamina / stamina;
    }

    public void DecreaseStamina(int _count)
    {
        staminaUsed = true;
        currentStaminaReChargeTime = 0;

        if(currentStamina - _count > 0)
        {
            currentStamina -= _count;
            
        }
        else {
            currentStamina = 0;
        }
    }

    public int GetCurrentSP()
    {
        return currentStamina;
    }

}
