using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject enemy, enemy1, enemy2;
    public float spawnTime;
    float m_spawnTime;
    int m_Score;
    bool m_isGameOver;
    UIController uiController;
    void Start()
    {
        m_spawnTime = 0;
        uiController = FindObjectOfType<UIController>();
        uiController.SetScoreText("Score: " + m_Score.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameOver)
        {
            m_spawnTime = 0;
            uiController.ShowGameOverPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if (m_spawnTime <= 0)
        {
            SpawnEnemy();
            m_spawnTime = spawnTime;
        }
    }
    public void RePlay()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void SpawnEnemy()
    {
        float RanPosX = Random.Range(-7f, 7f);
        Vector2 spawnPos = new Vector2(RanPosX, 7);
        if (enemy && m_Score <= 10)
        {
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }
        else if (enemy1 && 10 < m_Score && m_Score <= 20)
        {
            Instantiate(enemy1, spawnPos, Quaternion.identity);
        }
        else
        {
            Instantiate(enemy2, spawnPos, Quaternion.identity);
        }
    }
    public void SetScore(int value)
    {
        m_Score = value;
    }
    public int GetScore()
    {
        return m_Score;
    }
    public void ScoreIncrement()
    {
        m_Score++;
        uiController.SetScoreText("Score: " + m_Score.ToString());
    }
    public void SetGameOverState(bool state)
    {
        m_isGameOver = state;
    }
    public bool IsGameOver()
    {
        return m_isGameOver;
    }
}
