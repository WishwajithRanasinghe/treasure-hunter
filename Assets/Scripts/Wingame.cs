using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wingame : MonoBehaviour
{
    public static bool winGame;

    private AudioScript1 _audioScript;
    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            _audioScript = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioScript1>();
        }
        

        winGame = false;
    }
    private void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            winGame = true;
            _audioScript.GameWinSound();
        }
    }
}
