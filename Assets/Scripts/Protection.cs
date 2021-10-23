using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protection : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private float _duration = 1f;
    private float _volumeScale;
    private float _runningTime;
    private Coroutine _currentCorutine;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        StartChangeValue(1);
    }

    private void StartChangeValue(float targetVolume)
    {
        if(_currentCorutine != null)
        {
            StopCoroutine(_currentCorutine);
        }

        _currentCorutine = StartCoroutine(ChangeVolume(targetVolume));
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        StartChangeValue(0);
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        _runningTime = 0;
        var waitForSeconds = new WaitForSeconds(0.1f);

        while (_audio.volume != targetVolume)
        {
            _runningTime += Time.deltaTime;
            _volumeScale = _runningTime / _duration;

            _audio.volume = Mathf.MoveTowards(_audio.volume, targetVolume, _volumeScale);
            yield return waitForSeconds;
        }
    }
}
