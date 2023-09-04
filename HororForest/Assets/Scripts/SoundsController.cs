using UnityEngine;

public class SoundsController : MonoBehaviour
{
    [SerializeField] private AudioClip[] _footSteps;
    [SerializeField] private AudioSource _playerAudio;
    [SerializeField] private Animator _animator;
    public void FootStep()
    {
        int randSound = Random.Range(0, _footSteps.Length);
        _playerAudio.PlayOneShot(_footSteps[randSound]);
    }
}
