using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    public float _stamina;

    [SerializeField] private AudioClip[] _environmentSounds;
    [SerializeField] private AudioSource _breathAudio;
    [SerializeField] private AudioSource _defaultBreathAudio;
    [SerializeField] private Animator _animator;
    [SerializeField] private CustomCharacterController _characterController;
    [SerializeField] private Slider _staminaSlider;

    private void Update()
    {
        if (_staminaSlider.value > 100)
            _staminaSlider.value = 100;

        RecoveryStamina();
        _stamina = _staminaSlider.value;
        if (!_breathAudio.isPlaying && !_defaultBreathAudio.isPlaying && _characterController.currentSpeed < 4.71)
            _defaultBreathAudio.PlayOneShot(_environmentSounds[2]);
    }
    public void UseStamina()
    {
        if (!_breathAudio.isPlaying && _stamina < 1)
        {
            _defaultBreathAudio.Stop();
            _breathAudio.PlayOneShot(_environmentSounds[1]);
        }
        _staminaSlider.value -= 0.25f;
    }
    private void UseJumpStamina()
    {
        _staminaSlider.value -= 25f;
    }
    public void RecoveryStamina()
    {
        _staminaSlider.value += 0.05f;
    }
}
