using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CameraTriggeredAnimation : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(CheckVisibility());
    }

    private void Update()
    {
        //if (mainCamera != null)
        //{
        //    Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);

        //    if (GeometryUtility.TestPlanesAABB(planes, GetComponent<Renderer>().bounds))
        //    {
        //        // Объект виден в поле зрения камеры
        //        Debug.Log("Object is visible on the screen: " + gameObject.name);
        //    }
        //    else
        //    {
        //        // Объект не виден в поле зрения камеры
        //    }
        //}
        //else
        //{
        //    Debug.LogError("Main camera reference is missing!");
        //}
    }

    private IEnumerator CheckVisibility()
    {
        while (true)
        {
            if (mainCamera != null)
            {
                Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);

                if (GeometryUtility.TestPlanesAABB(planes, GetComponent<Renderer>().bounds))
                {
                    // Объект виден в поле зрения камеры
                    Debug.Log("Object is visible on the screen: " + gameObject.name);
                }
                else
                {
                    // Объект не виден в поле зрения камеры
                }
            }
            else
            {
                Debug.LogError("Main camera reference is missing!");
            }
            yield return new WaitForSeconds(1);
        }
    }
}