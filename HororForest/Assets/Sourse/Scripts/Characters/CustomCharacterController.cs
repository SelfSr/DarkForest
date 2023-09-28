using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CustomCharacterController : MonoBehaviour
{
    public float jumpForce = 3.5f;
    public float walkingSpeed = 2f;
    public float runningSpeed = 6f;
    public float currentSpeed;
    private float animationInterpolation = 1f;

    [HideInInspector] public bool isKeyLocked = false;

    public Animator _animator;
    public Rigidbody _rigidbody;
    public Transform _mainCamera;
    [SerializeField] private StaminaController _staminaController;
    [SerializeField] private Rig _rig;
    [SerializeField] private Transform _aimTarget;
    [SerializeField] private float _targetRange = 0.5f;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            _audioSource.Play();

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, _mainCamera.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                Walk();
            }
            else
            {
                _staminaController.UseStamina();
                if (_staminaController._stamina > 1)
                    Run();
                else
                    Walk();
            }
        }
        else
        {
            Walk();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_staminaController._stamina > 25)
                _animator.SetTrigger("Jump");
        }

        Ray desiredTargetRay = _mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        Vector3 desiredTargetPosition = desiredTargetRay.origin + desiredTargetRay.direction * _targetRange;
        _aimTarget.position = desiredTargetPosition;
    }
    private void LateUpdate()
    {
        Vector3 camF = _mainCamera.forward;
        Vector3 camR = _mainCamera.right;
        camF.y = 0;
        camR.y = 0;
        Vector3 movingVector;
        movingVector = Vector3.ClampMagnitude(camF.normalized * Input.GetAxis("Vertical") * currentSpeed + camR.normalized * Input.GetAxis("Horizontal") * currentSpeed, currentSpeed);
        _animator.SetFloat("magnitude", movingVector.magnitude / currentSpeed);
        _rigidbody.velocity = new Vector3(movingVector.x, _rigidbody.velocity.y, movingVector.z);
        _rigidbody.angularVelocity = Vector3.zero;
    }
    void Run()
    {
        animationInterpolation = Mathf.Lerp(animationInterpolation, 1.5f, Time.deltaTime * 3);
        _animator.SetFloat("x", Input.GetAxis("Horizontal") * animationInterpolation);
        _animator.SetFloat("y", Input.GetAxis("Vertical") * animationInterpolation);

        currentSpeed = Mathf.Lerp(currentSpeed, runningSpeed, Time.deltaTime * 3);
    }
    void Walk()
    {
        animationInterpolation = Mathf.Lerp(animationInterpolation, 1f, Time.deltaTime * 3);
        _animator.SetFloat("x", Input.GetAxis("Horizontal") * animationInterpolation);
        _animator.SetFloat("y", Input.GetAxis("Vertical") * animationInterpolation);

        currentSpeed = Mathf.Lerp(currentSpeed, walkingSpeed, Time.deltaTime * 3);
    }
    public void Jump()
    {
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}