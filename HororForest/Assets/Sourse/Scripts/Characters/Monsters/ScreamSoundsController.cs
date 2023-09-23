using UnityEngine;
using DG.Tweening;

public class ScreamSoundsController : MonoBehaviour
{

    [Header("Sound")]
    [SerializeField] private float _delayToPlaySound;
    [SerializeField] private AudioSource _screamsSound;
    [SerializeField] private bool _isHideObjects = false;
    [SerializeField] private GameObject[] _hideObjects;

    [Header("Scream")]
    [SerializeField] private bool _isShowScream = false;
    [SerializeField] private float _delayToShowScream;
    [SerializeField] private GameObject _screamObject;

    [Header("OtherScreams")]
    [SerializeField] private bool _isExistenceOtherScreams = false;
    [SerializeField] private GameObject[] _triggers;

    private bool _isOnePlayScream = true;

    private void OnTriggerEnter(Collider collider)
    {
        if (_isOnePlayScream)
        {
            Invoke("PlaySound", _delayToPlaySound);
            if (_isShowScream)
                Invoke("ShowScreamObject", _delayToShowScream);
            if (_isExistenceOtherScreams)
                EnableTriggerOnOtherCollaiders();
            _isOnePlayScream = false;
        }
    }
    private void PlaySound()
    {
        if(_isHideObjects)
            foreach (GameObject go in _hideObjects)
                go.SetActive(false);
        _screamsSound.Play();
    }
    private void ShowScreamObject()
    {
        _screamObject.SetActive(true);
    }
    private void EnableTriggerOnOtherCollaiders()
    {
        foreach (var GO in _triggers)
            GO.SetActive(true);
    }
}
