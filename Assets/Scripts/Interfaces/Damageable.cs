using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damageable : MonoBehaviour
{
    private float health;
    private Slider healthBar;
    private UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public void receiveDamage(float damageToReceive)
    {
        health -= damageToReceive;

        if (health <= 0f)
        {
            die();
        }

        if (this.gameObject.CompareTag("Player")==true)
        {
            uiManager.setPlayerHealth(health);
        }
        else
        {
            healthBar.value = health;
        }
    }

    void die()
    {
        Destroy(gameObject);
    }
}
