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
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            _rig.weight = 0;
        else if (_stateLight == true)
            _rig.weight = 1;
        EnableOrDisableLight();
    }
    private void EnableOrDisableLight()
    {
        if (Input.GetKeyDown(KeyCode.F) && _stateLight == false && IsAnimationPlaying("EnableFlash") == false)
        {
            _rig.weight = 1;
            _animator.SetBool("Enable", true);
            _animator.Play("FlashTake");
            _animator.SetBool("Disable", false);
            Invoke("EnableFlash", 0.44f);
        }
        else if (Input.GetKeyDown(KeyCode.F) && _stateLight == true && IsAnimationPlaying("FlashPutAway") == false)
        {
            _animator.SetBool("Disable", true);
            _animator.Play("FlashPutAway");
            _animator.SetBool("Enable", false);
            DisableFlash();
            Invoke("SetRigWight", 0.44f);
        }
    }
    private void EnableFlash()
    {
        _soundFlashLight.Play();
        _lightFlash.enabled = true;
        _stateLight = true;
    }
    private void DisableFlash()
    {
        _lightFlash.enabled = false;
        _stateLight = false;
        _soundFlashLight.Play();
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

    public bool IsAnimationPlaying(string animationName)
    {
        var animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if (animatorStateInfo.IsName(animationName))
            return true;

        return false;
    }
}
