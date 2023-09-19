using UnityEngine;

public class EnvironmentsSounds : MonoBehaviour
{
    private const float MAX_VALUE = 100f;
    private const float MIN_VALUE = 1f;
    [SerializeField] private bool isPrintPercent = false;

    [SerializeField] private AudioSource _sound;
    [Range(MIN_VALUE, MAX_VALUE)]
    [SerializeField] private float _percentToPlay;

    private void Start()
    {
        InvokeRepeating("PlaySound", 1f, 5f);
    }
    private void PlaySound()
    {
        float randomValue = Random.Range(MIN_VALUE, MAX_VALUE);
        if (randomValue <= _percentToPlay)
            if (!_sound.isPlaying)
                _sound.Play();
        if (isPrintPercent)
            print(randomValue);
    }
}
