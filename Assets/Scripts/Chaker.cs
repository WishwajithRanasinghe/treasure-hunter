using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaker : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
