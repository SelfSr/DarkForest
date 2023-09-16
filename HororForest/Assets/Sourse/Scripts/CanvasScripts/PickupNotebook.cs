using UnityEngine;

public class PickupNotebook : MonoBehaviour
{
    private int _rayDistance = 4;
    static public int numberNotebook = 0;

    [SerializeField] private GameObject _hidedObject;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private ItemCollectionRaycast _itemCollectionRaycast;

    private void Update()
    {
        if (Physics.Raycast(_itemCollectionRaycast.ray, _rayDistance, _layerMask))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _hidedObject.SetActive(false);
                numberNotebook++;
            }
        }
    }
}
