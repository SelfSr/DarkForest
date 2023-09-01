using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetSceneLoad : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    public void Change(int index)
    {
        SceneManager.LoadScene(index);
    }
    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            pausePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }
    public void ContinuePlay()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
