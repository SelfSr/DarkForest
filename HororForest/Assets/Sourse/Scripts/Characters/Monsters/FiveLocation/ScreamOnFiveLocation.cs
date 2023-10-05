using UnityEngine;

public class ScreamOnFiveLocation : MonoBehaviour
{
    [SerializeField] private Light _flashLight;
    [SerializeField] private GameObject _scream;
    [SerializeField] private AudioSource[] _audioSource = new AudioSource[3];
    [SerializeField] private Animator[] _animator;

    private bool _isOnePlay = true;

    private void OnTriggerEnter(Collider other)
    {
        Invoke("HideAnimation", 1f);
    }
    private void HideAnimation()
    {
        if (_isOnePlay)
        {
            while (_flashLight.spotAngle < 150)
                _flashLight.spotAngle += 2f;
            Invoke("DisableFlashLight", 0.07f);
            _audioSource[1].Play();
            _isOnePlay = false;
            _animator[0].SetBool("IsHade", true);
            Invoke("HideScream", 0.9f);
        }
    }
    private void HideScream()
    {
        _scream.SetActive(false);
    }
    private void DisableFlashLight()
    {
        if (_flashLight.enabled == true)
        {
            _flashLight.enabled = false;
            _audioSource[0].Play();
        }
        Invoke("RestartFlashLight", 3);
        _flashLight.spotAngle = 50;
    }
    private void RestartFlashLight()
    {
        if (_flashLight.enabled == false)
        {
            _audioSource[2].Play();
            _animator[1].SetBool("Enable", true);
            _flashLight.enabled = true;
        }
    }
}
