using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody2D rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SetBladeToMouse();
    }

    private void SetBladeToMouse()
    {
        var mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        rb.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
