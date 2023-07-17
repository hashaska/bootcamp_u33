using System.Collections.Generic;
using UnityEngine;

public class MainLightConnector : MonoBehaviour
{
    [SerializeField] private List<Light> connectedLights = new List<Light>(); // Initialize as an empty list

    public Light mainLight; // Reference to the main light to be controlled

    private bool allLightsOn = false;

    private void Start()
    {
        // Turn off the main light initially
        mainLight.enabled = false;
    }

    private void Update()
    {
        CheckLightsStatus();
    }

    private void CheckLightsStatus()
    {
        int activatedLightsCount = 0;

        // Count the number of activated lights
        foreach (Light light in connectedLights)
        {
            if (light.enabled)
            {
                activatedLightsCount++;
            }
        }

        // Check if all 18 lights are turned on
        allLightsOn = (activatedLightsCount == connectedLights.Count);

        // Activate/deactivate the main light based on allLightsOn status
        mainLight.enabled = allLightsOn;
    }

    // Public property to access the connectedLights list
    public List<Light> ConnectedLights
    {
        get { return connectedLights; }
        set { connectedLights = value; }
    }
}