using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool empty;
    public Sprite icon;
     public int ID;
    public string type;
    public string description;
    public GameObject item;


    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = icon;
    }

}
