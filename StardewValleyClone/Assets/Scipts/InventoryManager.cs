using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("InventoryRelated")]
    public GameObject[] slot; //slots in inspector to place slot ui and for position
    public bool[] full;  //check if slots are full
    public static InventoryManager Instance; 
    public bool placeItem;   //on off for placing item
    public bool placeSeed;
    public List<GameObject> PlacedItem = new List<GameObject>(); //not important
    public GameObject CurrentFish; //save variable to get data from fish
    public GameObject plant;
    [Header("UI")]
    public GameObject InventoryUI;
    [Header("HotBar")]
    public GameObject[] hbSlot;
    public bool[] hbFull;
    

    void Awake() {
        Instance = this;
    }
    void Start()
    {
        InventoryUI.SetActive(false);
        placeItem = false;   //later turn false 
        placeSeed = false;
        // for (int i = 0; i < slot.Length; i++)
        //     {
        //     }
    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.E)){
           InventoryUI.SetActive(true);
       }
        if(placeItem){
            for (int i = 0; i < slot.Length; i++)  //inventory do this once again for seed
            {
                if(full[i] == false){
                    full[i] = true;
                    Instantiate(CurrentFish, slot[i].transform, false);
                    break;
                }
            }
             for (int i = 0; i < hbSlot.Length; i++)  //hotbar
            {
                if(hbFull[i] == false){
                    hbFull[i] = true;
                    Instantiate(CurrentFish, hbSlot[i].transform, false);
                    break;
                }
            }
            placeItem = false;
        }
        if(placeSeed){
            for (int i = 0; i < slot.Length; i++)  //inventory do this once again for seed
            {
                if(full[i] == false){
                    full[i] = true;
                    Instantiate(plant, slot[i].transform, false);
                    break;
                }
            }
             for (int i = 0; i < hbSlot.Length; i++)  //hotbar
            {
                if(hbFull[i] == false){
                    hbFull[i] = true;
                    Instantiate(plant, hbSlot[i].transform, false);
                    break;
                }
            }
            placeSeed = false;
        }
        ChechFullness();

    }

    public void ClickOff(){
        InventoryUI.SetActive(false);
    }
    void ChechFullness(){  //if everyslot is full
          for (int i = 0; i < slot.Length; i++)
            {
                if(full[i] == true){
                    placeItem = false;
                }
            }
    }
}
