using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public static Detection Instance;
    public bool inWater;
    public bool startDetect;
    public GameObject Player;
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
        if(PlayerMovement.Instance.faceUp==true){this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y+1f, 0);}
        if(PlayerMovement.Instance.faceRight==true){this.transform.position = new Vector3(Player.transform.position.x+1f, Player.transform.position.y, 0);}  
        if(PlayerMovement.Instance.faceLeft==true){this.transform.position = new Vector3(Player.transform.position.x-1f, Player.transform.position.y, 0);}
        if(PlayerMovement.Instance.faceDown==true){this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y-1f, 0);}
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
