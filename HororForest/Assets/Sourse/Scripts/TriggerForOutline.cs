using UnityEngine;

[RequireComponent(typeof(Outline))]
public class TriggerForOutline : MonoBehaviour
{
    private Outline _outline;
    private void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineWidth = 0;
    }
    public void OnOutline()
    {
        _outline.OutlineWidth = 5;
    }
    public void OffOutline()
    {
        _outline.OutlineWidth = 0;
    }
}
