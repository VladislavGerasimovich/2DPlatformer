using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishWindow : MonoBehaviour
{
    [SerializeField] private Finish _finish;
    [SerializeField] private CanvasGroup _canvasGroup;

    private float _time;
    private Coroutine _changeVisibility;

    private void OnEnable()
    {
        _finish.ShowFinishWindow += Play;
    }

    private void OnDisable()
    {
        _finish.ShowFinishWindow -= Play;
    }

    private void Play()
    {
        _changeVisibility = StartCoroutine(ShowWindow());
    }

    private IEnumerator ShowWindow()
    {
        _time = 0;

        while(_time < 5)
        {
            _time += Time.deltaTime;
            _canvasGroup.alpha = 1;
            yield return null;
        }

        StopCoroutine(_changeVisibility);
        _canvasGroup.alpha = 0;
    }
}
