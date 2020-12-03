using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Reminder:
//Three types of fishing materials: 
//switch script on when fishstate = 2;
//different level of fish cause a different in the size of green bar
//when linking with the player script, if the indicator is appearing, it wont be fishstate 3, may be turn it other state, so player wont reel it back during catching
public class FishCatching : MonoBehaviour
{
    [Header("Types")]
    public GameObject[] L1FishType;  //fish
    public GameObject[] L2FishType;  //nonfish
    public GameObject[] TrashType;   //trash
    [Header("Sliders&UI")]
    public GameObject FishCatchIndicator; //the slider thing
    public Slider Side;
    public Image fill;
    [Header("Values")]
    public int n; //determine type of fish
    public int h; //determine if hit a fish
    public float timer; //waiting for hit time
    public float fishingTime; //amount in the side bar
    [Header("Status")]
    public bool hit; //just to indicate in inspector whether player hit sth 
    bool determine;
    public bool startTime; //when the timecount start
    
    [Header("Captured Fish")]
    public List<GameObject> CaughtFish = new List<GameObject>();
    void Start()
    {
        timer = 0;
        h = Random.Range(0,4); 
        determine = true;
        FishCatchIndicator.SetActive(false);//later remove
    }
//order of stuff: player cast (fishstate2==true)> determine if hit a fish(h)>wait few seconds, if hit, display slider(do the whole slider fluctuating thing)> if manage to click many times and fish icon stay in green within time, fish caught> force reel in(turn fishstate to 3)
   //should this be a separate fishstate
    void Update()
    {
        //detect if the front tile is water, Jason is doing it
            Debug.Log("h = "+h);
            if(determine){
                if(h<=1 && h>=0){ //0,1,2: have fish
                    hit = true;
                    CalProb(); //do once each time, do it first
                    startTime = true;
                }else if(h>1 && h<=4){ //3,4: no fish
                    hit = false;
                    FishCatchIndicator.SetActive(false);
                }
            }
          if(startTime){   //start only when player hit sth
              timer+=Time.deltaTime;
          }
          if(timer>3){ //wait time before hit/nt
            FishCatchIndicator.SetActive(true);
            //make the bait constant shake while doing fluctuate (animation)
            FishTimeCounter();
          }
        Side.value = fishingTime;
        if(fishingTime>=100){ //turn the indicator off, reset value
            FishCatchIndicator.SetActive(false);
            fishingTime = 0; //reset value
            startTime = false; //stop timer
            timer = 0; //reset value
            //review the status of the fish icon, if not on the right spot, no fish?
        }

    }

    void CalProb(){
    n = Random.Range(0,99);  //determine which type of fish, do this somewhere first?  then later when reel in, instanciate the fish
    Debug.Log("n = "+ n);
    //h = -1; //stop the random number, to do only once 
    determine = false;
    }

    void BarFluctuates(){ //when linking with the player script, if the indicator is appearing, it wont be fishstate 3, may be turn it other state, so player wont reel it back during catching

    }
    void FishTimeCounter(){
        if(fishingTime<=100){
            fishingTime+=0.1f;
        }
           if(fishingTime<25){   //Changing colors of power indicator bar:
            fill.GetComponent<Image>().color = new Color32(255, 25, 0, 255);  //red
        }else if(fishingTime>25&&fishingTime<50){
            fill.GetComponent<Image>().color = new Color32(255, 124, 0, 255);
        }else if(fishingTime>50&&fishingTime<75){
            fill.GetComponent<Image>().color = new Color32(255, 203, 0, 255);
        }else if(fishingTime>75&&fishingTime<=100){
            fill.GetComponent<Image>().color = new Color32(0, 255, 18, 255);
        }
    }
    void InstanciateFishType(){ //if successfully catch a fish, instantiate. if not, this wont happen
        if(n<=30){
            int r = Random.Range(0, L1FishType.Length);
            GameObject Fish = Instantiate(L1FishType[r], Fishing.Instance.Bait.transform.position, Quaternion.identity)  as GameObject;
            CaughtFish.Add(Fish);
        }else if(n>30 && n<=65){
            int r = Random.Range(0, L2FishType.Length);
            GameObject Fish = Instantiate(L2FishType[r], Fishing.Instance.Bait.transform.position, Quaternion.identity)  as GameObject;
            CaughtFish.Add(Fish);
        }else if(n>65){
            int r = Random.Range(0, TrashType.Length);
            GameObject Fish = Instantiate(TrashType[r], Fishing.Instance.Bait.transform.position, Quaternion.identity)  as GameObject;
            CaughtFish.Add(Fish);
        }
    }

}
