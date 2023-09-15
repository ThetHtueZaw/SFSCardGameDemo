using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TMP_Text _countSecTxt;

    public void StartCount()
    {
        StopTimer();

        StartCoroutine(CountTimer(10));
    }

    private void StopTimer()
    {
        StopCoroutine(CountTimer(0));
    }

    IEnumerator CountTimer(float duration)
    {

        while (duration > 0)
        {
            duration -= Time.deltaTime;
            _countSecTxt.text = "" + (int)duration;

            yield return new WaitForEndOfFrame();
        }
    }
}
