using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _smoothSlider;
    [SerializeField] private Character _character;

    private float _nextValue;
    private float _duration;

    private void Awake()
    {
        _smoothSlider.value = 1;
        _duration = 1f;
    }

    private void OnEnable()
    {
        _character.HealthChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _character.HealthChanged -= OnValueChanged;
    }

    public void Reset()
    {
        _smoothSlider.value = 1;
    }

    private IEnumerator ChangeValue()
    {
        float elapsedTime = 0;
        float currentValue = _smoothSlider.value;

        while (elapsedTime < _duration)
        {
            elapsedTime += Time.deltaTime;
            _smoothSlider.value = Mathf.Lerp(currentValue, _nextValue, elapsedTime / _duration);

            yield return null;
        }
    }

    private void OnValueChanged(float value)
    {
        _nextValue = value;
        StartCoroutine(ChangeValue());
    }
}