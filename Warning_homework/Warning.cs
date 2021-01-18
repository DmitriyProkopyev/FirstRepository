using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Warning : MonoBehaviour
{
    [SerializeField] private float _durationOfWarning;
    [SerializeField] private AudioClip _warningSound;

    private Coroutine _volumeChanger;
    private AudioSource _audioSource;
    private bool isVolumeChanging;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(_warningSound);
        isVolumeChanging = false;
    }

    private float LimitValue(float value, float minLimit = float.MinValue, float maxLimit = float.MaxValue)
    {
        if (value < minLimit)
            return minLimit;
        if (value > maxLimit)
            return maxLimit;
        return value;
    }

    private IEnumerator ChangeSoundVolume(float wantedVolume, float durationInSeconds)
    {
        isVolumeChanging = true;
        wantedVolume = LimitValue(wantedVolume, 0, 1);
        durationInSeconds = LimitValue(durationInSeconds, minLimit: 0);

        float durationInFrames = durationInSeconds * 60;
        float _everyFrameVolumeUpdate = (wantedVolume - _audioSource.volume) / durationInFrames;
        bool ToLoud = _audioSource.volume < wantedVolume;
        

        while ((_audioSource.volume < wantedVolume && ToLoud) || (_audioSource.volume > wantedVolume && !ToLoud))
        {
            _audioSource.volume += _everyFrameVolumeUpdate;
            yield return new WaitForEndOfFrame();
        }

        isVolumeChanging = false;
    }

    private void StartNewVolumeChanging(float wantedVolume, float durationOfWarning)
    {
        if (isVolumeChanging)
        {
            StopCoroutine(_volumeChanger);
            isVolumeChanging = false;
        }
        _volumeChanger = StartCoroutine(ChangeSoundVolume(wantedVolume, durationOfWarning));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            StartNewVolumeChanging(1, _durationOfWarning);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            StartNewVolumeChanging(0, _durationOfWarning);
        }
    }
}
