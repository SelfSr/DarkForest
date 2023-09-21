using UnityEngine;

public class TriggerActionController : MonoBehaviour
{
    private const string SITUATION = "Situation";

    [SerializeField] private Animator _animator;
    [SerializeField] private float _delay = 1f;
    [SerializeField] private int _situation = 0;

    [SerializeField] private bool _isHideScream = false;
    [SerializeField] private float _delayHideScream = 1f;
    [SerializeField] private GameObject _scream;

    private void OnTriggerEnter(Collider other)
    {
        Invoke("PlayTriggerAction", _delay);
        if (_isHideScream)
            Invoke("HideScream", _delayHideScream);
    }
    private void PlayTriggerAction()
    {
        _animator.SetInteger(SITUATION, _situation);
    }
    private void HideScream()
    {
        _scream.SetActive(false);
    }
}
