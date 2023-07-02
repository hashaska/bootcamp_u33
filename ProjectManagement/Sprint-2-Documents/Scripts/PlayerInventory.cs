using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;
    public List<itemType> inventoryList;
    public int selectedItem;
    public float playerReach;
    [SerializeField] private GameObject throwItem_gameobject;
    private Rigidbody rgb;
    public GameObject PcPanel;

    [Space(20)] [Header("keys")] [SerializeField]
    private KeyCode throwItemKey;
    [SerializeField]
    private KeyCode pickItemKey;

    [Space(20)] [Header("Item gameobjects")] [SerializeField]
    private GameObject flash_item;

    [SerializeField] private GameObject sphere_item;
    [SerializeField] private GameObject capsule_item;
    [SerializeField] private GameObject cylinder_item;

    [Space(20)] [Header("Item prefabs")] [SerializeField]
    private GameObject flash_prefab;
    [SerializeField] private GameObject sphere_prefab;
    [SerializeField] private GameObject capsule_prefab;
    [SerializeField] private GameObject cylinder_prefab;

    [Space(20)] [Header("Slots")] [SerializeField]
    private Image[] inventorySlotImage = new Image [9];
    [SerializeField] private Image[] inventoryBackgroundImage = new Image [9];
    [SerializeField] private Sprite emptySlotSprite;
    
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject pickUp_Gameobject;

    private Dictionary<itemType, GameObject> itemSetActive = new Dictionary<itemType, GameObject>() { };
    private Dictionary<itemType, GameObject> itemInstantiate = new Dictionary<itemType, GameObject>() { };
    private void Start()
    {
        Instance = this;
        itemSetActive.Add(itemType.flash,flash_item);
        itemSetActive.Add(itemType.sphere,sphere_item);
        itemSetActive.Add(itemType.capsule,capsule_item);
        itemSetActive.Add(itemType.cylinder,cylinder_item);
        
        itemInstantiate.Add(itemType.flash,flash_prefab);
        itemInstantiate.Add(itemType.sphere,sphere_prefab);
        itemInstantiate.Add(itemType.capsule,capsule_prefab);
        itemInstantiate.Add(itemType.cylinder,cylinder_prefab);
        rgb = gameObject.GetComponent<Rigidbody>();
        NewItemSelected();
    }

    private void Update()
    {
        // pickup
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray,out hitInfo,playerReach))
        {
            Ipickable item = hitInfo.collider.GetComponent<Ipickable>();
            
            if (item != null)
            {
               pickUp_Gameobject.SetActive(true);
                if (Input.GetKey(pickItemKey))
                {
                    inventoryList.Add(hitInfo.collider.GetComponent<Itempickable>().itemScriptableObject.item_type);
                    item.PickItem();  
                }
                
            }
            else if (hitInfo.collider.CompareTag("PC") && Input.GetKey(pickItemKey))
            {
                PcPanel.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                pickUp_Gameobject.SetActive(false);   
            }
            
            
        }
        else
        {
            pickUp_Gameobject.SetActive(false);
        }
        //throw
        if (Input.GetKeyDown(throwItemKey) && inventoryList.Count > 1)
        {

          GameObject InstantiatedItem = Instantiate(itemInstantiate[inventoryList[selectedItem]],position: throwItem_gameobject.transform.position,new Quaternion());

          InstantiatedItem.GetComponent<Rigidbody>().isKinematic = false;
            
            inventoryList.RemoveAt(selectedItem);

            if (selectedItem != 0)
            {
                selectedItem -= 1;
            }
            NewItemSelected();
        }
        //Item UI
        for (int i = 0; i < 4; i++)
        {
            if (i < inventoryList.Count)
            {
                inventorySlotImage[i].sprite = itemSetActive[inventoryList[i]].GetComponent<Item>().itemScriptableObject.item_sprite;
            }
            else
            {
                inventorySlotImage[i].sprite = emptySlotSprite;
            }
            
        }
        
        int a = 0;
        foreach(Image image in inventoryBackgroundImage)
        {
            if (a == selectedItem)
            {
                image.color = new Color32(145, 255, 126, 255);
            }
            else
            {
                image.color = new Color32(219, 219, 219, 255);
            }
            a++;
        }

        
        if (Input.GetKeyDown(KeyCode.Alpha1) && inventoryList.Count > 0)
        {
            //gameobject item = selecteditem???
            selectedItem = 0;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && inventoryList.Count > 1)
        {
            selectedItem = 1;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && inventoryList.Count > 2)
        {
            selectedItem = 2;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && inventoryList.Count > 3)
        {
            selectedItem = 3;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && inventoryList.Count > 4)
        {
            selectedItem = 4;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) && inventoryList.Count > 5)
        {
            selectedItem = 5;
            NewItemSelected();
        }
        /*
        else if (Input.GetKeyDown(KeyCode.Alpha7) && inventoryList.Count > 6)
        {
            selectedItem = 6;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8) && inventoryList.Count > 7)
        {
            selectedItem = 7;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9) && inventoryList.Count > 8)
        {
            selectedItem = 8;
            NewItemSelected();
        }
      */  
    }

    private void NewItemSelected()
    {
        flash_item.SetActive(false);
        sphere_item.SetActive(false);
        capsule_item.SetActive(false);
        cylinder_item.SetActive(false);

        GameObject selectedItemGameObject = itemSetActive[inventoryList[selectedItem]];
        selectedItemGameObject.SetActive(true);
    }
    
    
}

public interface Ipickable
{
    void PickItem();
}