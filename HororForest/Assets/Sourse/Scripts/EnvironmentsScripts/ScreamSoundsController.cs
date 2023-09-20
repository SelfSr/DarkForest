using UnityEngine;
using DG.Tweening;

public class ScreamSoundsController : MonoBehaviour
{

    [Header("Sound")]
    [SerializeField] private bool _isAnimateTriggerAction = true;
    [SerializeField] private Transform _ActionFromTrigger;
    [SerializeField] private float _delayToPlaySound;
    [SerializeField] private AudioSource _screamsSound;

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
            if (_isAnimateTriggerAction)
                AnimateTriggerAction();
            if (_isShowScream)
                Invoke("ShowScreamObject", _delayToShowScream);
            if (_isExistenceOtherScreams)
                EnableTriggerOnOtherCollaiders();
            _isOnePlayScream = false;
        }
    }
    private void AnimateTriggerAction()
    {
        DOTween.Sequence()
                .Append(_ActionFromTrigger.DOLocalMove(new Vector3(-2.3f, -0.5f, -2f), 2f))
                .Append(_ActionFromTrigger.DOLocalMove(new Vector3(-7f, -0.5f, 5f), 2f))
                .SetEase(Ease.Linear)
                .SetDelay(_delayToPlaySound);
    }
    private void PlaySound()
    {
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
