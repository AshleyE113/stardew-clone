﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    public static Fishing Instance;
    [Header("UI")]
    public Slider powerbar;
    public GameObject Slider;
    public float power;
    public float finalValue;
    public Image fill;
    [Header("OtherObject")]
    public GameObject Bait;
    public GameObject Player;
    public Rigidbody2D brb;
    public GameObject Target;
    // public FishingLine fl;
    [Header("Position&Speed")]
    Vector3 mousePos;
    public float speed;
    float distance;
    public float thrust;
    Vector2 playerPos;
    [Header("Status")]
    public bool hold;
    public bool canCast;
    bool startT;
    public float timer;
    public bool canFish;
    bool decrease;
    void Awake() {
        Instance = this;
    }
    void Start()
    {
        power=0;
        powerbar.value=0;
        hold = false;
        Bait.SetActive(false);
        brb = Bait.GetComponent<Rigidbody2D>();
        Slider.SetActive(false);
        canCast = true;
        timer = 0;
        startT = false;
        canFish = true;  //switch to false if plyer is not holding the fishing rod
    }

    void Update()
    {
        float step = speed * Time.deltaTime; //casting bait with speed
        Bait.transform.position = Vector2.MoveTowards(Bait.transform.position, Target.transform.position, step); //Bair always move towards the target
        playerPos = Player.transform.position;  //always get player position
        
        powerbar.value = power;  //display value on slider, when press, value increase
        if(canFish){ //if player is not holding a fishing rod, this will not happen
            if(canCast){ //if player can cast
                if(Input.GetMouseButton(0)){  //Input.GetKey(KeyCode.Space)
                    Slider.SetActive(true);
                    Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  //get mouseposition
                    mousePos = worldMousePos;
                    if(power>99){  //line 63-72: this make power being able to increase and decrease on hold
                        decrease = true; 
                    }else if(power<1){
                       decrease = false; 
                    }
                    if(decrease){
                      power-=1f;
                    }else{
                       power+=1f;  
                    }//ends here
                    hold = true;
                }
            }
            if(hold && canCast){
                if(Input.GetMouseButtonUp(0)){  //determine the final strength of the cast
                    finalValue = power;
                    Debug.Log(finalValue);   //take the y of mousepos
                    Bait.SetActive(true);
                    //Bait.GetComponent<Rigidbody2D>().AddForce(Vector2.left,ForceMode2D.Impulse);//add a slight force to mimic the curve
                    ThrowBait(); //this is where the bait get thrown
                    Slider.SetActive(false);
                    canCast = false;
                    //render line
         
                }
            }
            if(!canCast){ //is cancast is false, player can reel in
                ReelIn();
            }
        }//ends here
            if(startT){ //cooldown time start counting
                timer+=Time.deltaTime;
                canFish = false;
            }
            if(timer>3){  //is less than this time, player cannot cast again: cooldown time after reel in, regain fishing ability after cooldown time
                canFish = true;
                canCast = true; 
                startT = false;
                timer = 0;
            }
        //Changing colors of power indicator bar:
        if(power<25){
            fill.GetComponent<Image>().color = new Color32(255, 25, 0, 255);  //red
        }else if(power>25&&power<50){
            fill.GetComponent<Image>().color = new Color32(255, 124, 0, 255);
        }else if(power>50&&power<75){
            fill.GetComponent<Image>().color = new Color32(255, 203, 0, 255);
        }else if(power>75&&power<=100){
            fill.GetComponent<Image>().color = new Color32(0, 255, 18, 255);
        }
    }

    void ThrowBait(){   //cast out the bait into the water, can do tile checking here inside this function!!
        Bait.transform.LookAt(mousePos);
        distance = CalDistance(finalValue);  //calculate available distance from casting strength
        Debug.Log(distance);
        //change throw direction according to face direction
            if(PlayerMovement.Instance.faceDown==true){Target.transform.position= new Vector2(Target.transform.position.x, Target.transform.position.y-distance);}
            if(PlayerMovement.Instance.faceUp==true){Target.transform.position= new Vector2(Target.transform.position.x, Target.transform.position.y+distance);}
            if(PlayerMovement.Instance.faceLeft==true){Target.transform.position= new Vector2(Target.transform.position.x-distance, Target.transform.position.y-0.5f);}
            if(PlayerMovement.Instance.faceRight==true){Target.transform.position= new Vector2(Target.transform.position.x+distance, Target.transform.position.y-0.5f);}
        hold = false;
        canCast = false;
    }
    void ReelIn(){  //ReelIn function
        if(Input.GetMouseButtonDown(0)){ 
            Target.transform.position = playerPos; //the bait goes back to player
            startT = true;
            //deactivate line renderer
            power = 0; //reset power
            PlayerMovement.Instance.canMove = true;  //player can move again after reeling in
                if(PlayerMovement.Instance.faceDown){
                    PlayerMovement.Instance.anim.SetBool("downCast", false);
                    PlayerMovement.Instance.anim.SetBool("downHit", true);
                }
                 if(PlayerMovement.Instance.faceUp){
                    PlayerMovement.Instance.anim.SetBool("upCast", false);
                    PlayerMovement.Instance.anim.SetBool("upHit", true);
                }
                if(PlayerMovement.Instance.faceLeft || PlayerMovement.Instance.faceRight){
                    PlayerMovement.Instance.anim.SetBool("leftCast", false);
                    PlayerMovement.Instance.anim.SetBool("leftHit", true);
                    //PlayerMovement.Instance.anim.SetBool("leftRaise", false);
                }
        }
        
    }
    public float CalDistance(float x){
        float d = x/30;
        return d;
    }
  


  
}