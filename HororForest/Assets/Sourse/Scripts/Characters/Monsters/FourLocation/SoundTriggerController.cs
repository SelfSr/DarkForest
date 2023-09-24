using System.Collections;
using UnityEngine;

public class SoundTriggerController : MonoBehaviour
{
    [SerializeField] private GameObject _triggerObject;
    [SerializeField] private bool _stateObject = false;

    [Header("Audio")]
    [SerializeField] private bool _isEnableAudio = false;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _delayToPlaySound = 1f;

    [Header("MainObject")]
    [SerializeField] private GameObject _mainObject;

    [Header("ParticleSystem")]
    [SerializeField] private bool _isEnableParticleSystem = false;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _delayToPlayParticle = 1f;

    [Header("ParticleSound")]
    [SerializeField] private bool _isEnableSoundParticle = false;
    [SerializeField] private AudioSource _audioSourceParticle;
    [SerializeField] private float _delayToPlaySoundParticle = 1f;

    [Header("OtherFunctions")]
    [SerializeField] private float _delayToCheck = 1f;
    [SerializeField] private bool _isEnableotherScreams = false;
    [SerializeField] private GameObject[] _otherScreams;
    private bool _isPlayOnceAudio = true;
    private bool _isPlayOnceParticle = true;
    private bool _isPlayOnceSoundParticle = true;

    private void Start()
    {
        StartCoroutine(CheckState());
    }
    private IEnumerator CheckState()
    {
        while (true)
        {
            if (_triggerObject.activeSelf == _stateObject)
            {
                _mainObject.SetActive(true);
                if (_isEnableAudio)
                {
                    Invoke("PlaySound", _delayToPlaySound);
                }
                if (_isEnableParticleSystem)
                {
                    Invoke("PlayParticle", _delayToPlayParticle);
                }
                if(_isEnableSoundParticle)
                {
                    Invoke("PlaySoundParticle", _delayToPlaySoundParticle);
                }
                if (_isEnableotherScreams)
                {
                    EnableOtherScreams();
                }

            }
            yield return new WaitForSeconds(_delayToCheck);
        }
    }
    private void PlaySound()
    {
        if (_isPlayOnceAudio)
        {
            _audioSource.Play();
            _isPlayOnceAudio = false;
        }
    }
    private void PlayParticle()
    {
        if (_isPlayOnceParticle)
        {
            _particleSystem.Play();
            _isPlayOnceParticle = false;
        }
    }
    private void PlaySoundParticle()
    {
        if( _isPlayOnceSoundParticle)
        {
            _audioSourceParticle.Play();
            _isPlayOnceSoundParticle = false;
        }
    }
    private void EnableOtherScreams()
    {
        foreach (var screamObject in _otherScreams)
        {
            screamObject.SetActive(true);
        }
    }
}
