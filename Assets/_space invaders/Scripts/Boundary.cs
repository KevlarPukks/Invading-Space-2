﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script defines the size of the ‘Boundary’ depending on Viewport. When objects go beyond the ‘Boundary’, they are destroyed or deactivated.
/// </summary>
public class Boundary : MonoBehaviour {

    Vector2 boundareCollider;

    //receiving collider's component and changing boundary borders
    private void Start()
    {
        ResizeCollider();
    }

    //changing the collider's size up to Viewport's size multiply 1.5
    void ResizeCollider() 
    {        
        Vector2 viewportSize = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)) * 2;
        viewportSize.x *= 1.5f;
        viewportSize.y *= 1.5f;
        boundareCollider = viewportSize;
    }

    private void Update()
    {
        if (transform.position.y > boundareCollider.y)
        {
            gameObject.SetActive(false);
        }
    }

    //when another object leaves collider
  

}
