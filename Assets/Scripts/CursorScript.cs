using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    [SerializeField] private Texture2D _nCursor,_cCursor;

    private void Awake()
    {
        ChanegeCursor(_nCursor);
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    private void Update()
    {
        
        if(Input.GetMouseButton(0))
        {
            ChanegeCursor(_cCursor);
        }
        else
        {
            ChanegeCursor(_nCursor);
        }
    }
    private void ChanegeCursor(Texture2D _cursorType)
    {
        Cursor.SetCursor(_cursorType,Vector2.zero,CursorMode.Auto);
    }
}
