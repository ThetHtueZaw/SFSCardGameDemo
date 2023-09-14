using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void StartTimer(float duration)
    {
        StopTimer();

        StartCoroutine(CountTimer(duration));
    }

    private void StopTimer()
    {
        StopCoroutine(CountTimer(0));
    }

    IEnumerator CountTimer(float duration)
    {
        _slider.maxValue = duration;
        _slider.value = _slider.maxValue;

        while(duration > 0)
        {
            _slider.value -= Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
    }
}
