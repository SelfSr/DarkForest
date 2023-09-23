using DG.Tweening;
using UnityEngine;

public class MoveObjectsScript : MonoBehaviour
{
    [SerializeField] private Transform _objectToMove;
    [SerializeField] private float[] countsFirstMovement = new float[3];
    [SerializeField] private float _firstAnimationTime;
    [SerializeField] private float[] countsSecondMovement = new float[3];
    [SerializeField] private float _secondAnimationTime;

    [Header("")]
    [SerializeField] private float _delayToMove;
    private void OnTriggerEnter(Collider collider)
    {
        DOTween.Sequence()
                .Append(_objectToMove.DOLocalMove(new Vector3(countsFirstMovement[0], countsFirstMovement[1], countsFirstMovement[2]), _firstAnimationTime))
                .Append(_objectToMove.DOLocalMove(new Vector3(countsSecondMovement[0], countsSecondMovement[1], countsSecondMovement[2]), _secondAnimationTime))
                .SetEase(Ease.Linear)
                .SetDelay(_delayToMove);
    }
}
