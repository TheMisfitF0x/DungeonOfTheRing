using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public Slider playerHealth;

    public void setPlayerHealth(float health)
    {
        playerHealth.value = health;
    }

    public void setPlayerMaxHealth(float health)
    {
        playerHealth.maxValue = health;
    }
}
