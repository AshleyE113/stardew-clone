using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSubScript : MonoBehaviour
{
    [SerializeField] private UI_Invent uiInvent;
    private Inventory inventory;
    // Start is called before the first frame update
    private void Awake()
    {
        inventory = new Inventory();
        uiInvent.SetInventory(inventory);
    }

}
