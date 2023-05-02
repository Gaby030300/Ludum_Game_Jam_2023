using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int Score = 0;
    public static int Strike = 0;

    public Text counterStrike;
    public Text counterScore;

    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject WonPanel;
  
    void Update()
    {
        counterStrike.text = "STRIKES: " + Strike.ToString();
        counterScore.text = "SCORE: " + Score.ToString();

        if (Strike == 3)
        {
            GameOverPanel.SetActive(true);
        }
        if(Score == 4)
        {
            WonPanel.SetActive(true);
        }
    }
}
