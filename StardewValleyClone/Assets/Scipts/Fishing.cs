using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
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
    [Header("Position&Speed")]
    Vector3 mousePos;
    public float speed;
    float distance;
    public float thrust;
    Vector2 playerPos;
    [Header("Status")]
    public bool hold;
    // public bool canCast;
    bool startT;
    public float timer;
    // public bool canFish;
    bool decrease;

    //Added by Jason
    public int State;
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
        timer = 0;
        startT = false;
    }

    void Update()
    {
        float step = speed * Time.deltaTime; //casting bait with speed
        Bait.transform.position = Vector2.MoveTowards(Bait.transform.position, Target.transform.position, step); //Bair always move towards the target
        playerPos = Player.transform.position;  //always get player position
        powerbar.value = power;  //display value on slider, when press, value increase

            if(PlayerMovement.Instance.fishstate == 1){ //state 1: player can cast
                if(Input.GetMouseButton(0)&&ClickableArea.Instance.inField == true){  //Input.GetKey(KeyCode.Space)
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
                    PlayerMovement.Instance.canMove = false;
                }
            }
            if(hold && PlayerMovement.Instance.fishstate == 2){ //holding mouse and state2
                    finalValue = power;
                    Debug.Log("yes"); //take the y of mousepos
                    Bait.SetActive(true);
                    ThrowBait(); //throw the bait
                    Slider.SetActive(false);

                    //Added by Jason
                    //CheckTileFishable();
            }
            if(PlayerMovement.Instance.fishstate == 3){ //state 3, player can reel in
                    ReelIn();
            }
            if(startT){ //cooldown time start counting
                    timer+=Time.deltaTime;
            }
            if(timer>1){  //wait for time until going back to state 1: can cast again
                    PlayerMovement.Instance.fishstate = 1; //return to original state
                    startT = false;
                    timer = 0;
            }
        
        if(power<25){   //Changing colors of power indicator bar:
            fill.GetComponent<Image>().color = new Color32(255, 25, 0, 255);  //red
        }else if(power>25&&power<50){
            fill.GetComponent<Image>().color = new Color32(255, 124, 0, 255);
        }else if(power>50&&power<75){
            fill.GetComponent<Image>().color = new Color32(255, 203, 0, 255);
        }else if(power>75&&power<=100){
            fill.GetComponent<Image>().color = new Color32(0, 255, 18, 255);
        }

        //Added by Jason
        State = PlayerMovement.Instance.fishstate;
    }

    void ThrowBait(){   //cast out the bait into the water, can do tile checking here inside this function!!
        Bait.transform.LookAt(mousePos);
        distance = CalDistance(finalValue);  //calculate available distance from casting strength
//        Debug.Log(distance);
        //change throw direction according to face direction
            if(PlayerMovement.Instance.faceDown==true){Target.transform.position= new Vector2(Target.transform.position.x, Target.transform.position.y-distance);}
            if(PlayerMovement.Instance.faceUp==true){Target.transform.position= new Vector2(Target.transform.position.x, Target.transform.position.y+distance);}
            if(PlayerMovement.Instance.faceLeft==true){Target.transform.position= new Vector2(Target.transform.position.x-distance, Target.transform.position.y-0.5f);}
            if(PlayerMovement.Instance.faceRight==true){Target.transform.position= new Vector2(Target.transform.position.x+distance, Target.transform.position.y-0.5f);}
        hold = false;

        //Added by Jason
        //CheckTileFishable(); later uncomment
    }
    void ReelIn(){  //ReelIn function
            Target.transform.position = playerPos; //the bait goes back to player
            startT = true;
            power = 0; //reset power
            PlayerMovement.Instance.canMove = true;  //player can move again after reeling in
            FishCatching.Instance.Reset();
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
                }
    }
    public float CalDistance(float x){
        float d = x/30;
        return d;
    }

    //Added by Jason
    //This is a function dedicated to check the tile, the Debug.Log() will get called whenever the target object hits a non-water tile
    //However I am confused why it won't return to the idle animation state, I'll need to take a closer look at how the animation was managed here 
    // public void CheckTileFishable()
    // {
    //     var tmp_tm = TileManager.tileManager;
    //     var tmp_pm = PlayerMovement.Instance;
    //     if (tmp_tm.CheckTheTile(Vector3Int.RoundToInt(Target.transform.position), tmp_tm.GroundTilemap) != 0)
    //     {
    //         //tmp_pm.SwitchingFishState();
    //         //tmp_pm.anim.SetBool("downCast");
    //         //tmp_pm.fishstate = 3;
    //         Debug.Log("This tile is not fishable!");
    //     }
    // }
}
