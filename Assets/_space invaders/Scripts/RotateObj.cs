using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    [SerializeField] private float secsPerRotation;

    [SerializeField] private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(360 /secsPerRotation * Time.deltaTime * direction);
    }
}
