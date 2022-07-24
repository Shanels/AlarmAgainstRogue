using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private bool _isAlarmOn;
    private float _maximumVolume = 1f;
    private float _minimumVolume = 0f;

    private void Start()
    {
        StartCoroutine(VolumeChange());
        _audioSource.volume = _minimumVolume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Robber>(out Robber robber))
        {           
            _isAlarmOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Robber>(out Robber robber))
        {            
            _isAlarmOn = false;
        }
    }

    private IEnumerator VolumeChange()
    {
        float _target = _minimumVolume;
        float maxDelta = 0.1f;
        var waitForOneQuarterSecond = new WaitForSecondsRealtime(0.25f);

        while (true)
        {
            if (_isAlarmOn)
            {
                _target = _maximumVolume;
            }
            else if (_isAlarmOn == false)
            {
                _target = _minimumVolume;
            }

            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _target, maxDelta);
            yield return waitForOneQuarterSecond;
        }
    }
}