using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wire : MonoBehaviour
{
    private LineRenderer line;
    [SerializeField] private string destinationTag;
    [SerializeField] private List<Light> connectedLights; // List to hold connected lights (make sure to assign the lights in the Inspector)
    private Vector3 offset;
    private bool isConnected = false; // Track the connection state of this wire

    private Camera shelterCamera; // Reference to the ShelterCamera

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        // Turn off the connected lights initially
        SetLightsState(false);

        // Find the ShelterCamera by tag
        shelterCamera = GameObject.FindGameObjectWithTag("ShelterCamera").GetComponent<Camera>();
    }

    public void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }

    public void OnMouseDrag()
    {
        Vector3 mouseWorldPos = MouseWorldPosition();
        Vector3 wireStartPos = mouseWorldPos + offset;
        Vector3 wireEndPos = transform.position;

        // Calculate the distance between the wire start and end positions
        float distance = Vector3.Distance(wireStartPos, wireEndPos);

        // Set the wire start position
        line.SetPosition(0, wireStartPos);

        // Set the wire end position based on the distance from the start position
        line.SetPosition(1, wireStartPos + (wireEndPos - wireStartPos).normalized * distance);
    }

    private void OnMouseUp()
    {
        Vector3 rayOrigin = shelterCamera.transform.position;
        Vector3 rayDir = MouseWorldPosition() - shelterCamera.transform.position;
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, rayDir, out hitInfo))
        {
            if (hitInfo.transform.tag == destinationTag)
            {
                line.SetPosition(0, hitInfo.transform.position);
                transform.gameObject.GetComponent<Collider>().enabled = false;
                isConnected = true;

                // Enable the connected lights
                SetLightsState(true);
            }
            else
            {
                line.SetPosition(0, transform.position);
                isConnected = false;

                // Disable the connected lights
                SetLightsState(false);
            }
        }
    }

    public bool IsConnected()
    {
        return isConnected;
    }

    public List<Light> GetConnectedLights()
    {
        return connectedLights;
    }

    private void SetLightsState(bool state)
    {
        foreach (Light light in connectedLights)
        {
            light.enabled = state;
        }
    }

    private Vector3 MouseWorldPosition()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Mathf.Abs(shelterCamera.transform.position.z);

        return shelterCamera.ScreenToWorldPoint(mouseScreenPos);
    }

    private void Update()
    {
        Cursor.visible = true;
    }
}