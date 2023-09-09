using TMPro;
using UnityEngine;

public class VictoryPanel : MonoBehaviour
{
    [SerializeField] private ItemCollection _itemCollection;
    [SerializeField] private GameObject victoryPanel;

    private void Update()
    {
        if (_itemCollection.CurrentCount == _itemCollection.MaxCount)
        {
            victoryPanel.SetActive(true);
        }
    }
}
