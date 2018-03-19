using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public void StartGame()
    {
        SceneManager.LoadScene("Zombie Shooter Level 1");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Game Over");
    }
	
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Continue()
    {

    }
}
