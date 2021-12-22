using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    private Light _light;
    
    [SerializeField] private float turnedInIntensity = 6f;
    [SerializeField] private float turnedOffIntansity = 0f;

    private bool isWorked = true;

    private void Awake()
    {
        _light = GetComponent<Light>();
    }

    private void Update()
    {
        SwitchLightning();
    }

    private void SwitchLightning()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isWorked)
            {
                _light.intensity = turnedOffIntansity;
            }
            else
            {
                _light.intensity = turnedInIntensity;
            }

            isWorked = !isWorked;
        }
    }
}
