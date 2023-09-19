using UnityEngine;

public class StateNotepad : MonoBehaviour
{
    [SerializeField] private GameObject _hideObject;
    [SerializeField] private GameObject[] _showObjects;

    private void FixedUpdate()
    {
        Invoke("CheckState", 2);
    }
    private void CheckState()
    {
        if (_hideObject.activeSelf == false)
        {
            foreach (GameObject objectForShow in _showObjects)
            {
                objectForShow.SetActive(true);
            }
        }
    }
}
