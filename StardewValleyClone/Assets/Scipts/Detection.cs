using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public static Detection Instance;
    public bool inWater;
    public bool startDetect;
    void Awake() {
        Instance = this;
    }
    void Start()
    {
        inWater = false;
        startDetect = false;
    }

    void Update()
    {
        if(!inWater){
            //PlayerMovement.Instance.fishstate = 3; //reel in
            //Fishing.Instance.startT = false;
            //Fishing.Instance.timer = 0;
        }
    }
     void OnTriggerEnter2D(Collider2D col) {
         //if(startDetect){
        if(col.gameObject.tag == "Water"){
            Debug.Log("its water");
            inWater = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D col) {
          if(col.gameObject.tag == "Water"){
            //Debug.Log("its water");
            inWater = false;
        }
    }
}
