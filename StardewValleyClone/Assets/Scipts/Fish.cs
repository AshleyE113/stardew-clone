using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float speed;
    public FishData fishInfo;
    void Start()
    {
        
    }

    void Update()
    {
        float step = speed * Time.deltaTime; 
        this.transform.position = Vector2.MoveTowards(this.transform.position, FishCatching.Instance.Target.transform.position, step); 
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player"){
            this.gameObject.SetActive(false);
            this.gameObject.transform.parent = FishCatching.Instance.CaptureFish.transform;
            var d = this.gameObject.GetComponent<AssignData_FishType>();
            fishInfo = d.FD;   //get access to the assigned thing in the above script
            InventoryManager.Instance.CurrentFish = fishInfo.f;  //save the image from data to invent script
            InventoryManager.Instance.placeItem = true;

        }
    }
}
