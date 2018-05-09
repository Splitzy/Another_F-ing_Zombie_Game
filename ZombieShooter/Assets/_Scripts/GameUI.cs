using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    private int health;
    public int score;
    private float stamina;
    public int highScore;

    public Slider healthSlider;
    public Slider staminaSlider;
    public GameObject scoreText;


    private void OnEnable()
    {
        PlayerBehaviour.OnUpdateHealth += HandleonUpdateHealth;
        PlayerBehaviour.OnUpdateStamina += HandleonUpdateStamina;
        AddScore.OnSendScore += HandleonSendScore;
    }

    private void OnDisable()
    {
        PlayerBehaviour.OnUpdateHealth -= HandleonUpdateHealth;
        PlayerBehaviour.OnUpdateStamina -= HandleonUpdateStamina;
        AddScore.OnSendScore -= HandleonSendScore;
    }

    void Start ()
    {
        UpdateUI();
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    void HandleonUpdateHealth(int newHealth)
    {
        health = newHealth;
        UpdateUI();
    }

    void HandleonUpdateStamina(float newStamina)
    {
        stamina = newStamina;
        UpdateUI();
    }

    void HandleonSendScore(int theScore)
    {
        score += theScore;
        UpdateUI();
    }
	
	void UpdateUI()
    {
        scoreText.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        healthSlider.value = health;
        staminaSlider.value = stamina;

        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
        }
	}
}
