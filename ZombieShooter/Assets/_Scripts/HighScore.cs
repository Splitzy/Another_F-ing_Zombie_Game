using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    private int hScore;
    public GameObject highScoreText;

	void Start()
    {
        hScore = PlayerPrefs.GetInt("highScore", 0);

        highScoreText.GetComponent<UnityEngine.UI.Text>().text = hScore.ToString();
	}
}
