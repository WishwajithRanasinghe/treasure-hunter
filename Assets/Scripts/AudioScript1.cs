using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript1 : MonoBehaviour
{
    private AudioSource _audio;
    [SerializeField] private AudioClip _collisionClip,_WinClip,_gameOverClip,_TimerClip;
    private Rigidbody2D _rBody;
    [SerializeField] private float _collisionForce = 1f;
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _rBody = GetComponent<Rigidbody2D>();
    }
    public void GameOverSound()
    {
        _audio.Play();
        _audio.PlayOneShot(_gameOverClip);
        if(_audio.clip != _gameOverClip)
        {
            
            
        }
        
    }
    public void GameWinSound()
    {
        _audio.PlayOneShot(_WinClip);
    }
    public void GameTimer(bool isStart)
    {
        if(isStart == true)
        {
            if(_audio.isPlaying != true)
            {
                _audio.clip = _TimerClip;
                _audio.loop =true;
                _audio.Play();
            }
        }
        else
        {
            _audio.loop =true;
            _audio.Stop();
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Wall")
        {
            if(_rBody.velocity.magnitude >= _collisionForce)
            {
                _audio.PlayOneShot(_collisionClip);
            }
        }
    }*/
}
