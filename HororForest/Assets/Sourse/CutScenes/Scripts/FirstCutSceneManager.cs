using UnityEngine;

public class FirstCutSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _hideObject;
    [SerializeField] private GameObject[] _showObject;

    public void DisableObject()
    {
        foreach (var obj in _hideObject)
            obj.SetActive(false);
    }
    public void EnableObject()
    {
        foreach (var obj in _showObject)
            obj.SetActive(true);
    }
}
