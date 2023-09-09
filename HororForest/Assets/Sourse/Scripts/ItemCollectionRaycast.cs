using UnityEngine;

public class ItemCollectionRaycast : MonoBehaviour
{
    [SerializeField] private float _distanceRay = 5;
    private GameObject _selectedObject;
    private Transform m_Transform;
    private RaycastHit hit;
    [HideInInspector] public Ray ray;

    private TriggerForOutline _triggerForOutline;

    private void Start()
    {
        m_Transform = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {

        ray = new Ray(transform.position, transform.forward);
        //Debug.DrawRay(m_Transform.position, m_Transform.forward * _distanceRay);
        if (Physics.Raycast(ray, out hit, _distanceRay))
        {
            var trigger = hit.collider.GetComponent<TriggerForOutline>();
            if (trigger != null)
            {
                if (trigger != _triggerForOutline)
                {
                    //print(hit);
                    trigger.OnOutline();
                    _triggerForOutline = trigger;
                }
            }
            else if (_triggerForOutline != null)
            {
                //print(hit);
                _triggerForOutline.OffOutline();
                _triggerForOutline = null;
            }
        }
        else if(_triggerForOutline)
        {
            _triggerForOutline.OffOutline();
            _triggerForOutline = null;
        }
    }
}
