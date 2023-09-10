using TMPro;
using UnityEngine;

public class PressTAB : MonoBehaviour
{
    private bool _isTrigger = true;
    public GameObject _firstNotepad;
    public GameObject _textMeshProUGUI;

    public void FixedUpdate()
    {
        if(_firstNotepad.activeSelf == false && _isTrigger)
        {
            _isTrigger = false;
            _textMeshProUGUI.SetActive(true);
        }
    }
}
