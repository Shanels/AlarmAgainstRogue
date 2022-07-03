using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _target = 1f;

    private void Start()
    {
        StartCoroutine(VolumeUp());
        _audioSource.volume = 0f;
    }

    private IEnumerator VolumeUp()
    {
        var maxDelta = 0.1f;
        var waitForOneQuarterSecond = new WaitForSecondsRealtime(0.25f);

        while (true)
        {
            if(_audioSource.volume == 0.1f)
            {
                _target = 1;
            }
            else if (_audioSource.volume == 1)
            {
                _target = 0.1f;
            }

            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _target, maxDelta);
            yield return waitForOneQuarterSecond;            
        }
    }
}
