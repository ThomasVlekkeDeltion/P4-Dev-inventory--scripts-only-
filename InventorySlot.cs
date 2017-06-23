using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public Image thisImage;
    public Item thisItem;
    public Item tempStore;
    public Inventory inventory;

    //tt = tooltip
    public Text ttName;
    public Text ttDiscription;
    public Text ttRarity;
    public Image ttIcon;


    private void Awake()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();

        ttName = GameObject.Find("TPName").GetComponent<Text>();
        ttDiscription = GameObject.Find("TPDiscription").GetComponent<Text>();
        ttRarity = GameObject.Find("TPRarity").GetComponent<Text>();
        ttIcon = GameObject.Find("TPSprite").GetComponent<Image>();
    }

    public void OnClick()
    {
        if (thisItem == null)
        {
            if (inventory.activeerItem != null) //als de local inventoryslot null is, dan is held item niet null
            {
                thisItem = inventory.activeerItem;
                inventory.activeerItem = null;
                thisImage.sprite = thisItem.sprite;
                thisImage.enabled = true;
            }
        }
        else
        {
            if (inventory.activeerItem == null) //als de local inventoryslot niet null is, dan is activeerItem leeg
            {
                inventory.activeerItem = thisItem;
                thisItem = null;
                thisImage.sprite = null;
                thisImage.enabled = false;
            }
            else //als de local inventoryslot EN held item niet null zijn
            {
                tempStore = thisItem;
                thisItem = inventory.activeerItem;
                inventory.activeerItem = tempStore;
                tempStore = null;
                thisImage.sprite = thisItem.sprite;
                thisImage.enabled = true;
            }
        }
    }

    private void Update()
    {
        //alleen checken als inventory geopend is
        if (thisItem != null)
        {
            thisImage.sprite = thisItem.sprite;
            thisImage.enabled = true;

           
        }
    }

    
    public void OnPointerEnter()
    {
        if (thisItem != null)
        {
            inventory.ttPanel.SetActiveer(true);
            ttName.text = thisItem.itemNaam;
            ttDiscription.text = thisItem.discription;
            ttRarity.text = thisItem.rarity.ToString();
            ttIcon.sprite = thisItem.sprite;
        }

        else
        {
            print("this is empty");
        }

    }

    public void OnPointerExit()
    {
        inventory.ttPanel.SetActiveer(false);
        ttName.text = null;
        ttDiscription.text = null;
        ttRarity.text = null;
        ttIcon.sprite = null;
    }
}
