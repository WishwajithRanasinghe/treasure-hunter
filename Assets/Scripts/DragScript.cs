using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class DragScript : MonoBehaviour
{
    private Vector2 _difference = Vector2.zero;
    private Vector2 _direction;
    private Rigidbody2D _rBody;
    [SerializeField] private float _dragForce= 10f;
    [SerializeField] private bool _isDrag;
    public static bool isStart;
    private void Start()
    {
        _rBody = GetComponent<Rigidbody2D>();
        isStart = false;
    }
    private void Update()
    {
        if(_isDrag == true)
        {
            //_rBody.velocity = _direction * _moveSpeed * Time.deltaTime;
            _rBody.AddForce(_direction * _dragForce * Time.deltaTime , ForceMode2D.Impulse);
        }
        else
        {
            _rBody.velocity = Vector2.zero;
        }
        
    }
    private void OnMouseDown()
    {
        
        _difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        isStart = true;
    }
    private void OnMouseDrag()
    {
        //_rBody.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - _difference;
        _direction= (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - _difference;
        _isDrag = true;



    }
    private void OnMouseUp()
    {
        _isDrag = false;
    }
}
