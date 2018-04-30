using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public delegate void UpdateHealth (int newHealth);
    public static event UpdateHealth OnUpdateHealth;
    public delegate void UpdateStamina(float newStamina);
    public static event UpdateStamina OnUpdateStamina;

    public int health = 100;
    public float maxStamina = 100;
    private float stamina;

    private Animator gunAnim;
	
	void Start()
    {
        gunAnim = GetComponent<Animator>();
        stamina = maxStamina;

        SendHealthData();
        SendStaminaData();

        InvokeRepeating("RefreshStamina", 0, 1);
    }
	

	void Update ()
    {
		if(Input.GetMouseButtonDown(0) && !PauseMenu.isPaused)
        {
            //GetComponent<AudioSource>().Play();
            //gunAnim.SetBool("isFiring", true);
        }

        if (Input.GetMouseButtonUp(0) && !PauseMenu.isPaused)
        {
            //gunAnim.SetBool("isFiring", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint();
        }

        
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        SendHealthData();

        if (health <= 0)
        {
            Die();
        }
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
