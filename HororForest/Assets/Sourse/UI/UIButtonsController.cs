using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonsController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourse;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _startUI;

    private AudioSource[] allAudioSources;

    void Start()
    {
        // Получаем все звуковые источники на сцене
        allAudioSources = FindObjectsOfType<AudioSource>();
    }
    private void Update()
    {
        if (!_startUI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_pausePanel.activeSelf == false)
                {
                    allAudioSources = FindObjectsOfType<AudioSource>();
                    _pausePanel.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    foreach (var audioSource in allAudioSources)
                        audioSource.Pause();
                    Cursor.visible = true;
                    Time.timeScale = 0f;
                }
                else
                {
                    allAudioSources = FindObjectsOfType<AudioSource>();
                    _pausePanel.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                    foreach (var audioSource in allAudioSources)
                        audioSource.UnPause();
                    Cursor.visible = false;
                    Time.timeScale = 1f;
                }
            }
        }
    }
    public void PlayButton()
    {
        _audioSourse.Play();
        CutsceneManager.Instance.StartCutscene("CutScene_1");
    }
    public void ReastartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        _audioSourse.Play();
        Application.Quit();
    }
}
