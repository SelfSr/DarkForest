using UnityEngine;
using DG.Tweening;

public class TeleportObjectScript : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject[] _objectsToTransport;
    [SerializeField] private float[] countsMovement = new float[3];
    [SerializeField] private float _AnimationTime;
    [SerializeField] private GameObject _trggerObject;

    [SerializeField] private bool _isShowObject = false;

    private void Update()
    {
        if (_trggerObject.activeSelf == true)
            TeleportObject();
    }
    private void TeleportObject()
    {
        _objectsToTransport[0].transform.DOMove(new Vector3(countsMovement[0], countsMovement[1], countsMovement[2]), _AnimationTime);
        _animator.SetInteger("Situation", 0);
        if (_isShowObject)
            foreach (var obj in _objectsToTransport)
                obj.SetActive(true);
    }
}
