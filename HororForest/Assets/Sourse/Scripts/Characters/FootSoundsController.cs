using UnityEngine;

public class FootSoundsController : MonoBehaviour
{
    [SerializeField] private AudioClip[] _footSteps;
    [SerializeField] private AudioSource _footAudio;
    [SerializeField] private Animator _animator;
    [SerializeField] private CustomCharacterController _characterController;
    private void FootStep()
    {
        int randSound = Random.Range(0, _footSteps.Length);
        _footAudio.PlayOneShot(_footSteps[randSound]);
    }
}
