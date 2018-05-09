using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    private int hScore;
    public GameObject highScoreText;

	void Update ()
    {
        hScore = PlayerPrefs.GetInt("HighScore");

        highScoreText.GetComponent<UnityEngine.UI.Text>().text = hScore.ToString();
	}
}
