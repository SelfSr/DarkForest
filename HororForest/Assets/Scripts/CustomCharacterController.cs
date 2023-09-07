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

    void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, _mainCamera.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            // Зажаты ли еще кнопки A S D?
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                Walk();
            }
            // Если нет, то тогда бежим!
            else
            {
                _staminaController.UseStamina();
                if (_staminaController._stamina > 1)
                    Run();
                else
                    Walk();
            }
        }
        // Если W & Shift не зажаты, то мы просто идем пешком
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
        // Здесь мы задаем движение персонажа в зависимости от направления в которое смотрит камера
        // Сохраняем направление вперед и вправо от камеры 
        Vector3 camF = _mainCamera.forward;
        Vector3 camR = _mainCamera.right;
        // Чтобы направления вперед и вправо не зависили от того смотрит ли камера вверх или вниз, иначе когда мы смотрим вперед, персонаж будет идти быстрее чем когда смотрит вверх или вниз
        // Можете сами проверить что будет убрав camF.y = 0 и camR.y = 0 :)
        camF.y = 0;
        camR.y = 0;
        Vector3 movingVector;
        // Тут мы умножаем наше нажатие на кнопки W & S на направление камеры вперед и прибавляем к нажатиям на кнопки A & D и умножаем на направление камеры вправо
        movingVector = Vector3.ClampMagnitude(camF.normalized * Input.GetAxis("Vertical") * currentSpeed + camR.normalized * Input.GetAxis("Horizontal") * currentSpeed, currentSpeed);
        // Magnitude - это длинна вектора. я делю длинну на currentSpeed так как мы умножаем этот вектор на currentSpeed на 86 строке. Я хочу получить число максимум 1.
        _animator.SetFloat("magnitude", movingVector.magnitude / currentSpeed);
        //Debug.Log(movingVector.magnitude / currentSpeed);
        // Здесь мы двигаем персонажа! Устанавливаем движение только по x & z потому что мы не хотим чтобы наш персонаж взлетал в воздух
        _rigidbody.velocity = new Vector3(movingVector.x, _rigidbody.velocity.y, movingVector.z);
        // У меня был баг, что персонаж крутился на месте и это исправил с помощью этой строки
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