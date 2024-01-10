using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu,_gameOverMenu,_winPanel;
    [SerializeField] private TMP_Text _timeTX;
    [SerializeField] private float _time;

    private void Start()
    {
        _pauseMenu.SetActive(false);
        _gameOverMenu.SetActive(false);
        _winPanel.SetActive(false);
        Time.timeScale = 1;
        
    }


    private void Update()
    {
        //time.........
        if(DragScript.isStart == true)
        {
            _time -= Time.deltaTime;
        }
        
        if(_time <= 0)
        {
            _gameOverMenu.SetActive(true);
            _time = 0;
            Time.timeScale = 0;
            
        }
        TimeUpdate();
        if(Wingame.winGame == true)
        {
            _winPanel.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
    private void TimeUpdate()
    {
        _timeTX.text = Mathf.FloorToInt(_time).ToString();
    }
    public void PauseBTN()
    {
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);

    }
    public void ResumeBTN()
    {
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
    }
    public void RestartBTN()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _pauseMenu.SetActive(false);
    }
    public void NextBTN()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        _pauseMenu.SetActive(false);
    }
    public void MainMenu()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(0);
        _pauseMenu.SetActive(false);
    }
    public void PlayBTN()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void ExitBTN()
    {
        Time.timeScale = 0;
        Application.Quit();

    }
}
