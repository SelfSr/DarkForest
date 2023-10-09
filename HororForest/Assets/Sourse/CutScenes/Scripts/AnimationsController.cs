using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    [SerializeField] private Animator[] _animators;
    [SerializeField] private int _situaion = 0; 

    public void OnEnable()
    {
        foreach (var animator in _animators)
        {
            animator.SetInteger("Situation", _situaion);
        }
    }
}
