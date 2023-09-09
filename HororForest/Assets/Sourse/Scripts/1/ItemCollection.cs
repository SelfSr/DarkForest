using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    [SerializeField] private List<ItemTarget> _itemTargets;

    private int _currentCount;
    private int _maxCount;
    public int CurrentCount => _currentCount;
    public int MaxCount => _maxCount;

    public event Action itemAdded;
    private void Awake()
    {
        _maxCount = _itemTargets.Count;
    }
    public void Add(ItemTarget item)
    {
        _currentCount++;
        _itemTargets.Remove(item);
        Destroy(item.gameObject);
        itemAdded?.Invoke();
    }
}
