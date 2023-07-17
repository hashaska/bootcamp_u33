using System.Collections.Generic;
using UnityEngine;

public class StreetLightConnector : MonoBehaviour
{
    [SerializeField] private List<Light> streetLights = new List<Light>(); // List to hold street lights (make sure to assign the lights in the Inspector)
    public Light mainLight; // Reference to the main light to be controlled

    private bool allLightsOn = false;

    private void Start()
    {
        // Turn off the street lights initially
        SetStreetLightsState(false);
    }

    private void Update()
    {
        CheckLightsStatus();
    }

    private void CheckLightsStatus()
    {
        allLightsOn = mainLight.enabled;

        // Activate/deactivate the street lights based on allLightsOn status
        SetStreetLightsState(allLightsOn);
    }

    private void SetStreetLightsState(bool state)
    {
        foreach (Light light in streetLights)
        {
            light.enabled = state;
        }
    }

    public List<Light> StreetLights
    {
        get { return streetLights; }
        set { streetLights = value; }
    }
}