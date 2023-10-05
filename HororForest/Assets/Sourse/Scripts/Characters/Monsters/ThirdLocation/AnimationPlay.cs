using UnityEngine;

public class AnimationPlay : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    void Start()
    {
        _animator.SetTrigger("Spawn");
    }
}
