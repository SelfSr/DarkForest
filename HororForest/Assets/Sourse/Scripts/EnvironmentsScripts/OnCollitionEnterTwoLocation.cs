using UnityEngine;

public class OnCollitionEnterTwoLocation : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject[] _hidedObjects;
    private void OnTriggerEnter(Collider other)
    {
        if (_audioSource.isPlaying == false)
        {
            foreach (var obj in _hidedObjects)
            {
                obj.SetActive(false);
            }
        }
    }
}
