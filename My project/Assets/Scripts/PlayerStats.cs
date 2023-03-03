using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int health;

    public GameObject gameOverMenu;

    public void TakeDamage(){
        health-=1;
        CheckDeath();
    }

    private void CheckDeath(){
        if(health<=0){
            gameOverMenu.SetActive(true);
            Destroy(gameObject);
        }
    }
}
