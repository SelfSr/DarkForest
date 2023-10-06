using UnityEngine;

public class PickUpLesnikBook : MonoBehaviour
{
    private int _rayDistance = 4;
    static public int _numberLesnikBook;

    [SerializeField] private GameObject _hidedObject;
    [SerializeField] private GameObject _showObject;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private ItemCollectionRaycast _itemCollectionRaycast;

    private void Update()
    {
        if (Physics.Raycast(_itemCollectionRaycast.ray, _rayDistance, _layerMask))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _hidedObject.SetActive(false);
                _showObject.SetActive(true);
                _numberLesnikBook = 3;
            }
        }
    }
}
