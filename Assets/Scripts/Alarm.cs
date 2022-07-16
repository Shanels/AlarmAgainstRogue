using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Animator _animator;

    private float _target = 0f;

    private void Start()
    {
        StartCoroutine(VolumeChange());
        _audioSource.volume = 0f;
    }

    private IEnumerator VolumeChange()
    {
        var maxDelta = 0.1f;
        var waitForOneQuarterSecond = new WaitForSecondsRealtime(0.25f);

        while (true)
        {
            if (_animator.enabled)
            {
                _target = 1f;
            }
            else if (_animator.enabled == false)
            {
                _target = 0f;
            }

            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _target, maxDelta);
            yield return waitForOneQuarterSecond;
        }
    }
}
