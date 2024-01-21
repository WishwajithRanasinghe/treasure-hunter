using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu,_gameOverMenu,_winPanel,_optionMenu,_tutorialPanel;
    [SerializeField] private TMP_Text _timeTX;
    [SerializeField] private float _time;
    [SerializeField] private Slider _master,_music,_sfx;
    [SerializeField] private AudioMixer _mixer;
    private float volume,volume2,volume3;
    private AudioScript1 _audioScript;

    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            _audioScript = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioScript1>();
        }
        
        _pauseMenu.SetActive(false);
        _gameOverMenu.SetActive(false);
        _winPanel.SetActive(false);
        //_optionMenu.SetActive(false);
        Time.timeScale = 1;
        if(_tutorialPanel != null)
        {
            _tutorialPanel.SetActive(true);
        }

        AudioControl();
        
    }


    private void Update()
    {
        //time.........
        if(DragScript.isStart == true)
        {
            _time -= Time.deltaTime;
            
            if(_tutorialPanel != null)
            {
                _tutorialPanel.SetActive(false);
            }
        }
        if(_time <= 10)
        {
            _audioScript.GameTimer(true);
        }
        
        if(_time <= 0)
        {

            _gameOverMenu.SetActive(true);
            _audioScript.GameOverSound();
            _audioScript.GameTimer(false);
    
            _time = 0;
            Time.timeScale = 0;
            
        }
        TimeUpdate();
        if(Wingame.winGame == true)
        {
            _winPanel.SetActive(true);
            Time.timeScale = 0;
        }
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            _pauseMenu.SetActive(false);
            _gameOverMenu.SetActive(false);
            _winPanel.SetActive(false);
            _optionMenu.SetActive(false);
        }
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            _pauseMenu.SetActive(false);
            _gameOverMenu.SetActive(false);
            _winPanel.SetActive(false);
        }
        
        
    }
    private void AudioControl()
    {
        if(PlayerPrefs.HasKey("MasterVolume"))
        {
           LoadVolume(); 
        }
        else
        {
            MasterVolume();
            MusicVolume();
            SfxrVolume();

        }

    }
    private void LoadVolume()
    {
        _master.value = PlayerPrefs.GetFloat("MasterVolume");
        _music.value = PlayerPrefs.GetFloat("MusicVolume");
        _sfx.value = PlayerPrefs.GetFloat("SfxVolume");

        MasterVolume();
        MusicVolume();
        SfxrVolume();

    }

    public void MasterVolume()
    {
        volume = _master.value;
        _mixer.SetFloat("Master",Mathf.Log10(volume)* 20);
        PlayerPrefs.SetFloat("MasterVolume",volume);
    }
    public void MusicVolume()
    {
        volume2 = _music.value;
        _mixer.SetFloat("Music",Mathf.Log10(volume2)* 20);
        PlayerPrefs.SetFloat("MusicVolume",volume2);
        
    }
    public void SfxrVolume()
    {
        volume3 = _sfx.value;
        _mixer.SetFloat("SFX",Mathf.Log10(volume3)* 20);
        PlayerPrefs.SetFloat("SfxVolume",volume3);
        
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
        
        SceneManager.LoadScene(0);
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
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
    public void OptionBTN()
    {
        Time.timeScale = 0;
        _optionMenu.SetActive(true);
        
    }
    public void OptionExit()
    {
        
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
        _optionMenu.SetActive(false);
    }
}
