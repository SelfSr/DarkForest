using UnityEngine;

public class SwitchBooks : MonoBehaviour
{
    [SerializeField] private GameObject _triggerObjectForSwitch;
    [SerializeField] private GameObject _showObject;
    [SerializeField] private GameObject _hideObject;

    public void SwitchBook()
    {
        if (_triggerObjectForSwitch.activeSelf == true)
        {
            _hideObject.SetActive(false);
            _showObject.SetActive(true);
        }
    }
}
