using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] private Transform target;
    public UnityEvent events;
    private float health = 20;
    private float maxHealth = 20;
    private bool killed=false;
    private void Awake()
    {
        healthBar.value=health/maxHealth;
    }
    private void die()
    {
        events.Invoke();
        StartCoroutine(CountDie());


        
    }
    public void Attacked()
    {
        health=health-3;
        UpdateHealthBar();
        if (health<=0 && killed==false)
        {
            die();
            killed=true;
        }
    }
    private void UpdateHealthBar()
    {
        healthBar.value = health / maxHealth;

    }
    private IEnumerator CountDie()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);

    }
   
}
