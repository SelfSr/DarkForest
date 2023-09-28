using System.Collections;
using UnityEngine;

public class FogAndAudioMiksher : MonoBehaviour
{
    [SerializeField] private AudioSource _wind;
    [SerializeField] private AudioSource _echoCreepySound;
    [SerializeField] private AudioSource _SoundOfNightForest;

    private void OnTriggerEnter()
    {
        StartCoroutine(IncrementTolimit());
        StartCoroutine(VolumeState());
    }
    private IEnumerator IncrementTolimit()
    {
        while (RenderSettings.fogDensity <= 0.18f)
        {
            RenderSettings.fogDensity += 0.001f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    private IEnumerator VolumeState()
    {
        while (_wind.volume >= 0 || _echoCreepySound.volume >= 0 || _SoundOfNightForest.volume >= 0)
        {
            _wind.volume -= 0.002f;
            _SoundOfNightForest.volume -= 0.001f;
            _echoCreepySound.volume -= 0.001f;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
