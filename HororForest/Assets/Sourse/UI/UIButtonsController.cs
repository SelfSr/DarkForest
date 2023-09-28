using UnityEngine;

public class UIButtonsController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourse;

    public void PlayButton()
    {
        _audioSourse.Play();
        CutsceneManager.Instance.StartCutscene("CutScene_1");
    }
}
