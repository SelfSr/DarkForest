using UnityEngine;

public class Skybox : MonoBehaviour
{
    [SerializeField] Material newSkyboxMaterial;
    [SerializeField] private bool isEnableFog = true;
    [SerializeField] private bool isEnableDay = false;
    [SerializeField] private bool isEnableWind = false;
    [SerializeField] private WindZone _windZone;
    public Color ambientLightColor = Color.white;

    public void ChangeSkybox()
    {
        if (newSkyboxMaterial != null)
        {
            Camera mainCamera = Camera.main;

            if (mainCamera != null)
            {
                //mainCamera.clearFlags = CameraClearFlags.Skybox; 

                RenderSettings.skybox = newSkyboxMaterial;
            }
        }
        if (isEnableFog)
        {
            RenderSettings.fog = true;
        }
        if (isEnableDay)
        {
            RenderSettings.ambientLight = ambientLightColor;
        }
        if(isEnableWind)
        {
            _windZone.windTurbulence = 1f;
        }    
    }
}
