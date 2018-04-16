using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    private int health;
    private int score;
    private int stamina;
    //private string gameInfo = "";

    public Slider healthSlider;
    public Slider staminaSlider;
    public GameObject scoreText;

    //private Rect boxRect = new Rect(10, 10, 300, 50);

    private void OnEnable()
    {
        PlayerBehaviour.OnUpdateHealth += HandleonUpdateHealth;
        //PlayerBehaviour.OnUpdateStamina += HandleonUpdateStamina;
        AddScore.OnSendScore += HandleonSendScore;
    }

    private void OnDisable()
    {
        PlayerBehaviour.OnUpdateHealth -= HandleonUpdateHealth;
        //PlayerBehaviour.OnUpdateStamina -= HandleonUpdateStamina;
        AddScore.OnSendScore -= HandleonSendScore;
    }

    void Start ()
    {
        UpdateUI();	
	}

    void HandleonUpdateHealth(int newHealth)
    {
        health = newHealth;
        UpdateUI();
    }

    //void HandleonUpdateStamina(int newStamina)
    //{
    //    stamina = newStamina;
    //    UpdateUI();
    //}

    void HandleonSendScore(int theScore)
    {
        score += theScore;
        UpdateUI();
    }
	
	void UpdateUI()
    {
		//gameInfo = "Score: " + score.ToString() + "\nHealth: " + health.ToString();
        scoreText.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        healthSlider.value = health;
        staminaSlider.value = stamina;
	}

    //void OnGUI()
    //{
    //    GUI.Box(boxRect, gameInfo);
    //}
}
