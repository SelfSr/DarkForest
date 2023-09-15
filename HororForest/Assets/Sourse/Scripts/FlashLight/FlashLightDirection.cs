using UnityEngine;

public class FlashLightDirection : MonoBehaviour
{
    [SerializeField] private Transform aimTarget;
    [SerializeField] private float targetRange = 10f;
    [SerializeField] private Transform mainCamera;

    void Update()
    {
        Ray desiredTargetRay = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector2(Screen.width / 2, -Screen.height + 400));
        Vector3 desiredTargetPosition = desiredTargetRay.origin + desiredTargetRay.direction * targetRange;
        aimTarget.position = desiredTargetPosition;
    }
}
