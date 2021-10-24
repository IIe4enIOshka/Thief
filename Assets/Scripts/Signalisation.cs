using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signalisation : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _waitForSeconds;

    private float _duration = 1f;
    private float _volumeScale;
    private float _runningTime;
    private Coroutine _currentCorutine;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        StartChangeVolume(1);
    }

    private void StartChangeVolume (float targetVolume)
    {
        if(_currentCorutine != null)
        {
            StopCoroutine(_currentCorutine);
        }

        _currentCorutine = StartCoroutine(ChangeVolume(targetVolume));
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        StartChangeVolume(0);
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        _runningTime = 0;

        var waitForSeconds = new WaitForSeconds(_waitForSeconds);

        while (_audio.volume != targetVolume)
        {
            _runningTime += Time.deltaTime;
            _volumeScale = _runningTime / _duration;

            _audio.volume = Mathf.MoveTowards(_audio.volume, targetVolume, _volumeScale);
            yield return waitForSeconds;
        }
    }
}
