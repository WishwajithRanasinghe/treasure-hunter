using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wingame : MonoBehaviour
{
    public static bool winGame;
    private void Start()
    {
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
        }
    }
}
