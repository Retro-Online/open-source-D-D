using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
  
    private bool inventoryEnabled;
    public GameObject inventory;

    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    public GameObject slotHolder;
    void start()
    {
        allSlots = 40;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            
            if(slot[i].GetComponent<Slot>().item == null)
                slot[i].GetComponent<Slot>().empty = true;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)){
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled == true)
        {
            inventory.SetActive(true);
        }
        else{
            inventory.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
        }
    }
    void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if(slot[i].GetComponent<Slot>().empty)
            {
                //additem to slot 
                itemObject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().description = itemDescription;
                    
                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
            } 
        } 
    }
}
//The host doesn’t allow starting the debugger. If needed, ask them to enable it.