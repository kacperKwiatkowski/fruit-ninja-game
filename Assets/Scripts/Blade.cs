using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{

    public float minVelo = 0.1f;
    private Vector3 lastMousePos;
    private Vector3 mouseVelo;

    private Collider2D col;
    private Rigidbody2D rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        SetBladeToMouse();
    }
    
    private void FixedUpdate()
    {
        col.enabled = IsMouseMoving();
    }

    private void SetBladeToMouse()
    {
        var mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        rb.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private bool IsMouseMoving()
    {
        Vector3 curMousePos = transform.position;
        float traveled = (lastMousePos - curMousePos).magnitude;
        lastMousePos = curMousePos;

        if (traveled > minVelo)
        {
            return true;
        }
        else return false;
    }
}
