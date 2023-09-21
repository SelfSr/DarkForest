using UnityEngine;

public class BlockRoad : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private float _duration;

    private void OnTriggerExit(Collider other)
    {
        foreach (var obj in gameObjects)
            obj.SetActive(true);
        Invoke("HideBlock", _duration);
    }
    private void HideBlock()
    {
        foreach(var obj in gameObjects)
            obj.SetActive(false);
    }
}
