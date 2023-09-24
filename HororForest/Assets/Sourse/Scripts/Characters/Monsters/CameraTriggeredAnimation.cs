using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraTriggeredAnimation : MonoBehaviour
{
    private const string SITUATION = "Situation";

    private Camera mainCamera;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _checkInterval = 0.5f;

    [Header("")]
    [SerializeField] private bool _needMove = false;
    [SerializeField] private GameObject _objectToTransport;
    [SerializeField] private float[] countsMovement = new float[3];
    [SerializeField] private float _AnimationTime;

    [Header("")]
    [SerializeField] private bool _isHideObjects = false;
    [SerializeField] private GameObject[] _hideObjects;
    [SerializeField] private float _delayToHideObjects;

    [Header("Sound")]
    [SerializeField] private bool _isPlaySound = false;
    [SerializeField] private float _delayToPlaySound;
    [SerializeField] private AudioSource _audioSource;

    private bool isMoving = true;
    private bool isOnePlay = true;

    private void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(CheckVisibility());
    }
    private IEnumerator CheckVisibility()
    {
        while (true)
        {
            if (mainCamera != null)
            {
                Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);

                if (GeometryUtility.TestPlanesAABB(planes, GetComponent<Renderer>().bounds))
                {
                    _animator.SetInteger(SITUATION, 2);
                    if (_needMove)
                        MoveObject();
                    if (_isHideObjects)
                        Invoke("HideObjects", _delayToHideObjects);
                    if (_isPlaySound)
                        Invoke("PlaySound", _delayToPlaySound);
                }
            }
            else
            {
                Debug.LogError("Main camera reference is missing!");
            }
            yield return new WaitForSeconds(_checkInterval);
        }
    }
    private void MoveObject()
    {
        if (isMoving)
        {
            _objectToTransport.transform.DOMove(new Vector3(countsMovement[0], countsMovement[1], countsMovement[2]), _AnimationTime);
            isMoving = false;
        }
    }
    private void HideObjects()
    {
        foreach (GameObject go in _hideObjects)
            go.SetActive(false);
    }
    private void PlaySound()
    {
        if (isOnePlay)
        {
            _audioSource.Play();
            isOnePlay = false;
        }
    }
}