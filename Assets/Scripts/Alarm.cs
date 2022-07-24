using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _volumeChanger;
    private bool _isAlarmOn;
    private float _maximumVolume = 1f;
    private float _minimumVolume = 0f;
    private float _target;

    private void Start()
    {
        _audioSource.volume = 0.001f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Robber>(out Robber robber))
        {
            _isAlarmOn = true;
            _target = _maximumVolume;
            _volumeChanger = StartCoroutine(VolumeChange());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Robber>(out Robber robber))
        {
            _isAlarmOn = false;
            _target = _minimumVolume;
            _volumeChanger = StartCoroutine(VolumeChange());
        }
    }

    private IEnumerator VolumeChange()
    {        
        float maxDelta = 0.1f;
        var waitForOneQuarterSecond = new WaitForSecondsRealtime(0.25f);        

        while (_audioSource.volume != _target)
        {            
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _target, maxDelta);
            yield return waitForOneQuarterSecond;            
        }
        
        StopCoroutine(_volumeChanger);
    }
}