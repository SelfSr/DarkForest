using System.Collections;
using UnityEngine;

public class RightPlayScriptTwoLocation : MonoBehaviour
{
    [SerializeField] private GameObject _triggerObject;
    [SerializeField] private GameObject[] _collaiders;

    private void Start()
    {
        StartCoroutine(CheckVisibility());
    }
    private IEnumerator CheckVisibility()
    {
        while (true)
        {
            if (_triggerObject.activeSelf == true)
                foreach (GameObject go in _collaiders)
                    go.SetActive(true);
            yield return new WaitForSeconds(1);
        }
    }
}
