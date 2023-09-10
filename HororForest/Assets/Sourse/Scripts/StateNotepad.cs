using UnityEngine;

public class StateNotepad : MonoBehaviour
{
    [SerializeField] private GameObject _hideObject;
    [SerializeField] private GameObject _showObject;

    private void Update()
    {
        Invoke("CheckState", 1);
    }
    private void CheckState()
    {
        if(_hideObject.activeSelf == false)
        {
            _showObject.SetActive(true);
        }
    }
}
