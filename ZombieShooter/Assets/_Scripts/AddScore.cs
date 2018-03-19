using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public delegate void sendScore(int theScore);
    public static event sendScore OnSendScore;

    public int score = 10;

    public void DoSendScore()
    {
        if(OnSendScore != null)
        {
            OnSendScore(score);
        }
    }
}
