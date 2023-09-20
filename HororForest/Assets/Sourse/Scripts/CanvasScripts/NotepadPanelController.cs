using UnityEngine;

public class NotepadPanelController : MonoBehaviour
{
    private bool _isEnableTextTABPanel = true;
    private bool _isEnablePanel = true;

    [SerializeField] private PressTAB _textTABPanel;
    [SerializeField] private GameObject _messegePanel;
    [SerializeField] private MessegeManager _messageManager1;
    [SerializeField] private MessegeManager _messageManager2;

    private void Update()
    {
        ChangeStatePAnel();
    }
    private void ChangeStatePAnel()
    {
        if (_textTABPanel._firstNotepad.activeSelf == false)
        {
            if (_isEnablePanel && Input.GetKeyDown(KeyCode.Tab))
            {
                _messegePanel.SetActive(true);
                _isEnablePanel = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                ToggleMessageManagers(true);
                CloseTABText();
            }
            else if (_isEnablePanel == false && Input.GetKeyDown(KeyCode.Tab))
            {
                ToggleMessageManagers(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                _messegePanel.SetActive(false);
                _isEnablePanel = true;
            }
        }
    }
    private void ToggleMessageManagers(bool isActive)
    {
        _messageManager1.ToggleSwitchPage(isActive);
        _messageManager2.ToggleSwitchPage(isActive);
    }
    private void CloseTABText()
    {
        if (_isEnableTextTABPanel)
        {
            _textTABPanel._textMeshProUGUI.SetActive(false);
            _isEnableTextTABPanel = false;
        }
    }
}
