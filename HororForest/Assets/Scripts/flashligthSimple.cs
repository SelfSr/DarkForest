using UnityEngine;
using UnityEngine.Animations.Rigging;

public class flashligthSimple : MonoBehaviour
{
    [SerializeField] private Light _lightFlash;
    [SerializeField] private AudioSource _soundFlashLight;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rig _rig;

    public bool _stateLight;

    private void Start()
    {
        _rig.weight = 0;
        CheckFlashLight();
    }
    private void Update()
    {
        EnableOrDisableLight();
    }
    private void EnableOrDisableLight()
    {
        if (Input.GetKeyDown(KeyCode.F) && _stateLight == false)
        {
            _rig.weight = 1;
            _animator.SetBool("Enable", true);
            _lightFlash.enabled = true;
            _stateLight = true;
            _soundFlashLight.Play();
            _animator.Play("FlashTake");
            _animator.SetBool("Disable", false);
        }
        else if (Input.GetKeyDown(KeyCode.F) && _stateLight == true)
        {
            _animator.SetBool("Disable", true);
            _lightFlash.enabled = false;
            _stateLight = false;
            _soundFlashLight.Play();
            _animator.Play("FlashPutAway");
            _animator.SetBool("Enable", false);
            Invoke("SetRigWight", 0.45f);
        }
    }
    private void SetRigWight()
    {
        _rig.weight = 0;
    }
    private void CheckFlashLight()
    {
        if (_stateLight == true)
            _lightFlash.enabled = true;
        else if (_stateLight == false)
            _lightFlash.enabled = false;
    }
}
