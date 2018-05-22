using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

    public delegate void UpdateHealth (int newHealth);
    public static event UpdateHealth OnUpdateHealth;
    public delegate void UpdateStamina(float newStamina);
    public static event UpdateStamina OnUpdateStamina;

    public int health = 100;
    public float maxStamina = 100;
    public float stamina;
    public bool isDamaged = false;

    void Start()
    {
        stamina = maxStamina;

        SendHealthData();
        SendStaminaData();

        InvokeRepeating("RefreshStamina", 0, 1);
    }
	

	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint();
        }
    }

    public void TakeDamage (int damage)
    {
        isDamaged = true;

        health -= damage;

        SendHealthData();

        if (health <= 0)
        {
            Die();
        }

        Invoke("Reset", 0.1f);
    }

    private void Reset()
    {
        isDamaged = false;
    }



    void RefreshStamina()
    {
        stamina += 5;

        if(stamina >= maxStamina)
        {
            stamina = maxStamina;
        }

        SendStaminaData();
    }

    public void Sprint()
    {
        if (stamina > 2)
        {
            stamina -= 0.5f;
        }

        SendStaminaData();
    }

    void Die()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Game Over");
    }

    void SendHealthData()
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }

    void SendStaminaData()
    {
        if (OnUpdateStamina != null)
        {
            OnUpdateStamina(stamina);
        }
    }
}
