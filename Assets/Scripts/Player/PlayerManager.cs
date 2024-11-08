using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using StarterAssets;
using UnityEngine.Events;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Camera _Camera;
    [SerializeField] AudioSource _AudioSource;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private UnityEvent fireWeapon;
    private bool _Shoot = false;
    private Vector3 mousePos;
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            TakeDamage(20);
            UpdateHealthUI();
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            // Player is defeated, you can add game over logic here
            Debug.Log("Player defeated!");
        }
    }

    private void UpdateHealthUI()
    {
        healthText.text = "Health: " + currentHealth.ToString();
    }
    private void Update()
    {
        TriggerShoot();
    }
    public void Ray()
    {
        Debug.Log("you fired");
        mousePos = Input.mousePosition;
        mousePos = _Camera.ScreenToWorldPoint(mousePos);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.collider.tag == "Zombie")
            {
                Zombie enemy = hit.transform.GetComponent<Zombie>();
                if (enemy != null)
                {
                    enemy.Attacked();
                }
            }
         
        }
    }
    public void SetShootTrue()
    {
        _Shoot = true;
    }
    public void SetShootFalse()
    {
        _Shoot = false;
    }
    public void TriggerShoot()
    {
        if (_Shoot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray();
                _AudioSource.Play();
                fireWeapon.Invoke();
            }
        }
    }
   public void OnCuerserLockedTrue()
    {
        Cursor.lockState = CursorLockMode.Locked;
  

    }
    public void OnCuerserLockedFalse()
    {
        Cursor.lockState = CursorLockMode.None;

    }
}
