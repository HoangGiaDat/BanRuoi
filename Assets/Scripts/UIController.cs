using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text ScoreText;
    public GameObject GameOverPanel;
     public void SetScoreText(string txt)
    {
        ScoreText.text = txt;
    }
    public void ShowGameOverPanel(bool isShow)
    {
        GameOverPanel.SetActive(isShow);
    }
}
