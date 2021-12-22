using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    private Slider _healthSlider;

    private int minValue = 0;
    private int maxValue = 100;
    private int currentValue;
    
    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
        _healthSlider.minValue = minValue;
        _healthSlider.maxValue = maxValue;
        currentValue = maxValue;
        _healthSlider.value = currentValue;
    }

    public void DecreaseHealthSlider(int damage)
    {
        _healthSlider.value -= damage;
    }

    public void IncreaseHealthSlider(int heal)
    {
        _healthSlider.value += heal;
    }
}
