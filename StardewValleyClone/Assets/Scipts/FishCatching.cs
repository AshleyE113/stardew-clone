using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Reminder:
//when linking with the player script, if the indicator is appearing, it wont be fishstate 3, may be turn it other state, so player wont reel it back during catching
//u are controlling the green thing not the fishicon
public class FishCatching : MonoBehaviour
{
    public Animator baitAnim;
    public static FishCatching Instance;
    public GameObject Target;
    [Header("Types")]
    public GameObject[] L1FishType;  //fish
    public GameObject[] L2FishType;  //nonfish
    public GameObject[] TrashType;   //trash
    [Header("Sliders&UI")]
    public GameObject FishCatchIndicator; //the slider thing
    public GameObject HoeButton;
    public Slider Side;
    public Image fill;
    public Image greenBox;
    public Slider Main;
    public Slider Indicator;
    public RectTransform greenRect;  //greenbox
    public RectTransform fishIconRect;  //fishIcon
    public GameObject FishingBar;
    public GameObject Bubble;
    [Header("Values")]
    public int n; //determine type of fish
    public int h; //determine if hit a fish
    public float timer; //waiting for hit time
    public float fishingTime; //amount in the side bar
    public float greenPos; //destination
    public float timer2; 
    public int fishIconPos; //destination
    public float currentfishIconPos;  
    [Header("Status")]
    public bool hit; //just to indicate in inspector whether player hit sth 
    public bool determine;
    public bool startTime; //when the timecount start
       public bool startTime2; //determine if it its ground reel in
    bool fluctuate;
    public bool catching;  //if player is playing the mini fish game to catch fish
    [Header("Captured Fish")]
    public List<GameObject> CaughtFish = new List<GameObject>();
    public GameObject CaptureFish;
      public enum FishType 
    {
    NONE,Trash,Type2,Type1
    };
    public FishType currentFishType = FishType.NONE;
    void Awake(){
        Instance = this;
    }
    void Start()
    {
        timer = 0;
        timer2 = 0;
        n = 0;
        FishCatchIndicator.SetActive(false);//later remove
        InvokeRepeating ("GreenPosRan", 0, 2);
        fluctuate = false;
        greenPos = 0;
        fishIconPos = 0;
        currentfishIconPos = 0;
        currentFishType = FishType.NONE; 
    }
//order of stuff: player cast (fishstate2==true)> determine if hit a fish(h)>wait few seconds, if hit, display slider(do the whole slider fluctuating thing)> if manage to click many times and fish icon stay in green within time, fish caught> force reel in(turn fishstate to 3)
   //should this be a separate fishstate
    void Update()
    {
        FishingBar.transform.eulerAngles = new Vector3(0, 0, 0);
        RectTransform rt = FishingBar.GetComponent<RectTransform>();
        Bubble.transform.eulerAngles = new Vector3(0, 0, 0);
        if(PlayerMovement.Instance.faceLeft==true){rt.transform.localPosition = new Vector3(-63, -106, 0);}
        if(PlayerMovement.Instance.faceRight==true){rt.transform.localPosition = new Vector3(63, -106, 0);}
        if(PlayerMovement.Instance.faceDown==true){rt.transform.localPosition = new Vector3(-63, -106, 0);}
            if(determine){
                startTime2 = true;
                if(h<=3 && h>=1){ //0,1,2: have fish
                    hit = true;
                    CalProb(); //do once each time, do it first
                    startTime = true;
                }else if(h>3){ //3,4: no fish
                    hit = false;
                    FishCatchIndicator.SetActive(false);
                }
            }
          if(startTime){   //start only when player hit sth
              timer+=Time.deltaTime;
          }
          if(startTime2){   //start only when player hit sth
              timer2+=Time.deltaTime;
          }

          if(timer2>1){
              if(!Detection.Instance.inWater){
                  PlayerMovement.Instance.fishstate = 3;
                  startTime2 = false;
                  timer2 = 0;
                  Reset();
                  determine = false;
              }
          }
          if(timer>3){ //wait time before hit/nt, mini fish game time
            fluctuate = true;
                if(currentFishType != FishType.Trash){
                    PlayerMovement.Instance.fishstate = 4;
                    FishCatchIndicator.SetActive(true);
                    BarControl();
                    FishIconFluctuate();
                    FishTimeCounter();
                    HoeButton.GetComponent<Button>().interactable = false; //player cant click this while doing mini game
                }else{
                    PlayerMovement.Instance.fishstate = 3; //instant reel in
                    InstanciateTrash();
                }
          }
        Side.value = fishingTime;
        Main.value = greenPos;
        Indicator.value = currentfishIconPos;
        DefineType();
            if(fishingTime>=100){ //turn the indicator off, reset value
                FishCatchIndicator.SetActive(false);
                Reset();
                HoeButton.GetComponent<Button>().interactable = true;  //player can click this while doing mini game
                PlayerMovement.Instance.fishstate = 3; //reel in
                //Instanciate
                if(currentFishType != FishType.Trash){
                    InstanciateFishType();
                }
            }
            if(greenPos>0&&Input.GetKeyDown(KeyCode.Space) == false ){  //greebar lower when release
                greenPos-=0.05f; 
            }
        
    }
    bool rectOverlaps(RectTransform rectTrans1, RectTransform rectTrans2)
{
    Rect rect1 = new Rect(rectTrans1.localPosition.x, rectTrans1.localPosition.y, rectTrans1.rect.width, rectTrans1.rect.height);
    Rect rect2 = new Rect(rectTrans2.localPosition.x, rectTrans2.localPosition.y, rectTrans2.rect.width, rectTrans2.rect.height);

    return rect1.Overlaps(rect2);
}

    void CalProb(){
    n = Random.Range(0,99);  //determine which type of fish, do this somewhere first?  then later when reel in, instanciate the fish
    Debug.Log("n = "+ n);
    determine = false;
    }
    void GreenPosRan(){
        if(fluctuate){
        fishIconPos = Random.Range(0,9);  //the fish icon fluctuation
        }
    }
    void BarControl(){ //when linking with the player script, if the indicator is appearing, it wont be fishstate 3, may be turn it other state, so player wont reel it back during catching
        if(Input.GetKey(KeyCode.Space)&&greenPos<10){
            greenPos+=0.1f;
        }
    }
    void FishIconFluctuate(){
        if(currentFishType == FishType.Type1){ //type1 difficulty speed
            if(currentfishIconPos<fishIconPos){ currentfishIconPos+=0.05f; }
            if(currentfishIconPos>fishIconPos){ currentfishIconPos-=0.05f; }   //how to make it lerp?
        }
        if(currentFishType == FishType.Type2){ //type2 difficulty speed
            if(currentfishIconPos<fishIconPos){ currentfishIconPos+=0.02f; }
            if(currentfishIconPos>fishIconPos){ currentfishIconPos-=0.02f; }   //how to make it lerp?
        }
    }
    void FishTimeCounter(){
            if (rectOverlaps(greenRect, fishIconRect))
            {
                if(fishingTime<=100){ //side bar increase, later make it if icon is not on green UI, value decrease
                fishingTime+=0.2f;
                greenBox.GetComponent<Image>().color = new Color(218, 255, 218, 1f);
                }
            }else
            {
                if(fishingTime>=0){ //side bar increase, later make it if icon is not on green UI, value decrease
                fishingTime-=0.1f;
                greenBox.GetComponent<Image>().color = new Color(218, 255, 218, 0.6f);
                }
            }

           if(fishingTime<25){   //Changing colors of side indicator bar:
            fill.GetComponent<Image>().color = new Color32(255, 25, 0, 255);  //red
        }else if(fishingTime>25&&fishingTime<50){
            fill.GetComponent<Image>().color = new Color32(255, 124, 0, 255);
        }else if(fishingTime>50&&fishingTime<75){
            fill.GetComponent<Image>().color = new Color32(255, 203, 0, 255);
        }else if(fishingTime>75&&fishingTime<=100){
            fill.GetComponent<Image>().color = new Color32(0, 255, 18, 255);
        }
    }
    void DefineType(){
        if(n>0 && n<=35){
        currentFishType = FishType.Trash; //trash
        }else if(n>35 && n<=70){
        currentFishType = FishType.Type2;
        }else if(n>70){
        currentFishType = FishType.Type1; 
        }
    }
    void InstanciateTrash(){
         if(currentFishType == FishType.Trash){ //trash
            int r = Random.Range(0, TrashType.Length);
            GameObject Fish = Instantiate(TrashType[r], Fishing.Instance.Bait.transform.position, Quaternion.identity)  as GameObject;
            CaughtFish.Add(Fish);
        }
    }
    void InstanciateFishType(){ //if successfully catch a fish, instantiate. if not, this wont happen
        if(currentFishType == FishType.Type2){ //L2
            int r = Random.Range(0, L2FishType.Length);
            GameObject Fish = Instantiate(L2FishType[r], Fishing.Instance.Bait.transform.position, Quaternion.identity)  as GameObject;
            CaughtFish.Add(Fish);
    
        }else if(currentFishType == FishType.Type1){ //L3
            int r = Random.Range(0, L1FishType.Length);
            GameObject Fish = Instantiate(L1FishType[r], Fishing.Instance.Bait.transform.position, Quaternion.identity)  as GameObject;
            CaughtFish.Add(Fish);
        }

    }

    public void Reset(){
        fishingTime = 0; //reset value
        startTime = false; //stop timer
        timer = 0; //reset value
        timer2 = 0;
        greenPos = 0;  //reset value //later remove it
        fluctuate = false;
        fishIconPos = 0;
        currentfishIconPos = 0;
        determine = false; //!new placement
    }

}
