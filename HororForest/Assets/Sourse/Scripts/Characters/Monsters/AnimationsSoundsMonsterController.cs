using UnityEngine;

public class AnimationsSoundsMonsterController : MonoBehaviour
{
    [SerializeField] private AudioClip[] _footSteps;
    [SerializeField] private AudioClip[] _jumpStates;
    [SerializeField] private AudioSource _footAudio;
    [SerializeField] private Animator _animator;
    private void FootStep()
    {
        int randSound = Random.Range(0, _footSteps.Length);
        _footAudio.PlayOneShot(_footSteps[randSound]);
    }
    private void JumpUp()
    {
        _footAudio.PlayOneShot(_jumpStates[0]);
    }
    private void JumpDown()
    {
        _footAudio.PlayOneShot(_jumpStates[1]);
    }
}
