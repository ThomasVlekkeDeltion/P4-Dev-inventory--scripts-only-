using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public Item activeerItem;
    public GameObject ttPanel;

    //tt = tooltip
    private void Start()
    {
        ttPanel = GameObject.Find("TooltipPanel");
        ttPanel.SetActive(false);
    } 

}
