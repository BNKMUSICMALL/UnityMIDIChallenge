using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text m_ScoreText;
    [SerializeField] private Text m_GameoverText;

    public void SetScore(int score)
    {
        m_ScoreText.text = $"Score : {score}";
    }

    public void ShowGameOver()
    {
        m_GameoverText.text = "Press spacebar to restart the game";
    }

#if UNITY_EDITOR
    public void SetTestData(Text scoreTxt, Text gameOverTxt)
    {
        m_ScoreText = scoreTxt;
        m_GameoverText = gameOverTxt;
    }
#endif
}
