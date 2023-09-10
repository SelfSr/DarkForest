using UnityEngine;

public class NotepadPanelController : MonoBehaviour
{
    private bool _isEbableTextTABPanel = true;
    private bool _isEbablePanel = true;

    [SerializeField] private PressTAB _textTABPanel;
    [SerializeField] private GameObject _messegePanel;
    [SerializeField] private MessegeManager _messegeManager;

    private void Update()
    {
        ChangeStatePAnel();
    }
    private void ChangeStatePAnel()
    {
        if (_textTABPanel._firstNotepad.activeSelf == false)
        {
            if (_isEbablePanel && Input.GetKeyDown(KeyCode.Tab))
            {
                _messegePanel.SetActive(true);
                _isEbablePanel = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                _messegeManager.ToggleSwitchPage(true);
                CloseTABText();
            }
            else if (_isEbablePanel == false && Input.GetKeyDown(KeyCode.Tab))
            {
                _messegeManager.ToggleSwitchPage(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                _messegePanel.SetActive(false);
                _isEbablePanel = true;
            }
        }
    }
    private void CloseTABText()
    {
        if (_isEbableTextTABPanel)
        {
            _textTABPanel._textMeshProUGUI.SetActive(false);
            _isEbableTextTABPanel = false;
        }
    }
}
