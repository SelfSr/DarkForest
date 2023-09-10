using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PickUpFlashLight : MonoBehaviour
{
    [SerializeField] private GameObject _hidedObject;
    [SerializeField] private GameObject _emergenceObject;
    [SerializeField] private Rig _rig;
    [SerializeField] private ItemCollectionRaycast _itemCollectionRaycast;
    [SerializeField] private GameObject _textMeshProUGUI;

    [SerializeField] private LayerMask _layerMaskFlashLight;
    private int _rayDistance = 4;

    private void OnEnable()
    {
        _rig.weight = 0f;
        _emergenceObject.SetActive(false);
    }
    private void Update()
    {
        if (Physics.Raycast(_itemCollectionRaycast.ray, _rayDistance, _layerMaskFlashLight))
        {
            _textMeshProUGUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                _hidedObject.SetActive(false);
                _emergenceObject.SetActive(true);
                _rig.weight = 1f;
            }
        }
        else
        {
            _textMeshProUGUI.SetActive(false);
        }
        if (_hidedObject.activeSelf == false)
        {
            _textMeshProUGUI.SetActive(false);
        }
    }
}
