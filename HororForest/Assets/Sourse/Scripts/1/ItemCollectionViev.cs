using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollectionViev : MonoBehaviour
{
    [SerializeField] private ItemCollection _itemCollection;
    [SerializeField] private TextMeshProUGUI _count;
    [SerializeField] private GameObject victoryPanel;

    private void Start()
    {
        OnItemAdded();
    }
    private void Update()
    {
        if (_itemCollection.CurrentCount == _itemCollection.MaxCount)
        {
            victoryPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
    private void OnEnable()
    {
        _itemCollection.itemAdded += OnItemAdded;
    }
    private void OnDisable()
    {
        _itemCollection.itemAdded -= OnItemAdded;
    }

    private void OnItemAdded()
    {
        _count.text = $"{_itemCollection.CurrentCount}/{_itemCollection.MaxCount}";
    }
}
