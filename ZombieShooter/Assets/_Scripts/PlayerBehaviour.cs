using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public delegate void UpdateHealth (int newHealth);
    public static event UpdateHealth OnUpdateHealth;
    //public delegate void UpdateStamina(int newStamina);
    //public static event UpdateStamina OnUpdateStamina;

    public int health = 100;
    //public int maxStamina = 100;
    //private int stamina;

    private Animator gunAnim;
	
	void Start()
    {
        gunAnim = GetComponent<Animator>();
        //stamina = maxStamina;

        SendHealthData();
        //SendStaminaData();
    }
	

	void Update ()
    {
		if(Input.GetMouseButtonDown(0) && !PauseMenu.isPaused)
        {
            GetComponent<AudioSource>().Play();
            gunAnim.SetBool("isFiring", true);
        }

        if (Input.GetMouseButtonUp(0) && !PauseMenu.isPaused)
        {
            gunAnim.SetBool("isFiring", false);
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

    //public void Sprint()
    //{
    //    if (Input.GetKey(KeyCode.LeftShift))
    //    {
    //        stamina -= 2;

    //        if (stamina <= 0)
    //        {
    //            stamina += 2;

    //            if (stamina >= maxStamina)
    //            {
    //                stamina = maxStamina;
    //            }
    //        }
    //    }
    //}

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

    //void SendStaminaData()
    //{
    //    if (OnUpdateStamina != null)
    //    {
    //        OnUpdateStamina(stamina);
    //    }
    //}
}
