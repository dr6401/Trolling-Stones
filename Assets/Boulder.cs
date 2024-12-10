using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;

public class Boulder : MonoBehaviour
{
    private Vector3 _initialPosition;
    private Vector3 _boulderPosition;
    private Vector3 _mousePosition;

    private void Awake()
    {
        _initialPosition = transform.position;
        _boulderPosition = _initialPosition + new Vector3(0, 1);
        //GetComponent<LineRenderer>().SetPosition(0, _boulderPosition);
        //GetComponent<LineRenderer>().SetPosition(1, _initialPosition + new Vector3(0, (float)0.3));
    }

    private void Update()
    {
        //GetComponent<LineRenderer>().SetPosition(0, _boulderPosition);
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //GetComponent<LineRenderer>().SetPosition(1, _mousePosition + new Vector3(0, 0, 2));
    }

    private void OnMouseDown()
    {
        //GetComponent<LineRenderer>().enabled = true;
        //GetComponent<LineRenderer>().SetPosition(0, _boulderPosition);
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //GetComponent<LineRenderer>().SetPosition(1, new Vector3(_mousePosition.x, _mousePosition.y));
    }
    
    private void OnMouseUp()
    {
        //GetComponent<LineRenderer>().enabled = false;
    }

}
