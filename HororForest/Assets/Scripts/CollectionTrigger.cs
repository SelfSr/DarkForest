using UnityEngine;

public class CollectionTrigger : MonoBehaviour
{
    [SerializeField] private ItemCollection _collection;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out ItemTarget itemTarget))
        {
            _collection.Add(itemTarget);
        }
    }
}
