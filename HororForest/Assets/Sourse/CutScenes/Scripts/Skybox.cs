using UnityEngine;

public class Skybox : MonoBehaviour
{
    [SerializeField] Material newSkyboxMaterial;
    [SerializeField] private bool isEnableFog = true;
    [SerializeField] private bool isDisableFog = true;
    [SerializeField] private bool isEnableDay = false;
    [SerializeField] private bool isEnableWind = false;
    [SerializeField] private WindZone _windZone;
    public Color ambientLightColor = Color.black;

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
        if (isDisableFog)
        {
            RenderSettings.fog = false;
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
