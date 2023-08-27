using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishWindow : MonoBehaviour
{
    [SerializeField] private Finish _finish;
    [SerializeField] private CanvasGroup _canvasGroup;

    private float _time;

    private void Update()
    {
        if(_time > 0)
        {
            _time -= Time.deltaTime;
        }
        if(_time < 0)
        {
            HideWindow();
        }
    }

    private void OnEnable()
    {
        _finish.ShowFinishWindow += ShowWindow;
    }

    private void OnDisable()
    {
        _finish.ShowFinishWindow -= ShowWindow;
    }

    private void HideWindow()
    {
        _canvasGroup.alpha = 0;
        _time = 0;
    }

    private void ShowWindow()
    {
        _time = 5;
        _canvasGroup.alpha = 1;
    }
}
