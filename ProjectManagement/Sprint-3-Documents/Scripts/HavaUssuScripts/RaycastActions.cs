using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastActions : MonoBehaviour
{
    private Camera cam;
    private Ray ray;
    private RaycastHit hit;
    [SerializeField] private Light mylight;
    

    private Targetable currentTargetable;
    public Collectable currentCollectable;
    private Interactable currentInteractable;
    void Start()
    {
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if(Physics.Raycast(ray,out hit, 100))
        {
            if (hit.collider.TryGetComponent(out Targetable targetable))
            {
                currentTargetable = targetable;
                currentTargetable.ToggleHightLight(true);
                if (currentTargetable.TryGetComponent(out Collectable collectable))
                {
                    currentCollectable = collectable;
                }
                if (currentTargetable.TryGetComponent(out Interactable interactable))
                {
                    currentInteractable = interactable;
                }
            }
            else if (currentTargetable)
            {
                currentTargetable.ToggleHightLight(false);
                currentTargetable = null;
                if (currentCollectable)
                {
                    currentCollectable = null;
                }
                if (currentInteractable)
                {
                    currentInteractable = null;
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.E)) // "E" harfine basýlýrsa
        {
            if (currentCollectable) // Bu bir toplanabilir nesneyse
            {
                currentCollectable.Collect();
                currentCollectable = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.E)) // "E" harfine basýlýrsa
        {
            if (currentInteractable) // Bu bir toplanabilir nesneyse
            {
                currentInteractable.Interact();
                currentInteractable = null;
            }
        }

    }
}
