using UnityEngine;
using DG.Tweening;

public class TeleportObjectScript : MonoBehaviour
{
    [SerializeField] private bool _isAnimate = false;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject[] _objectsToTransport;
        [Header("")]
    [SerializeField] private float[] countsMovement = new float[3];
    [SerializeField] private float _AnimationTime;
    [SerializeField] private GameObject _trggerObject;
        [Header("Rotate")]
    [SerializeField] private float[] countsRotate = new float[3];

    [SerializeField] private bool _isShowObject = false;

    private bool _isOneTeleport = true;

    private void Update()
    {
        if (_trggerObject.activeSelf == true)
            TeleportObject();
    }
    private void OnTriggerEnter(Collider other)
    {
        TeleportObject();
    }
    private void TeleportObject()
    {
        if (_isOneTeleport)
        {
            _objectsToTransport[0].transform.DOMove(new Vector3(countsMovement[0], countsMovement[1], countsMovement[2]), _AnimationTime);
            _objectsToTransport[0].transform.DORotate(new Vector3(countsRotate[0], countsRotate[1], countsRotate[2]), _AnimationTime);
            if (_isAnimate)
                _animator.SetInteger("Situation", 0);
            if (_isShowObject)
                foreach (var obj in _objectsToTransport)
                    obj.SetActive(true);
            _isOneTeleport = false;
        }
    }
}
