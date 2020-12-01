using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    public Animator anim;
    public GameObject StrRenderer;
    public GameObject UI;
    public GameObject Player;
    [Header("Physics")]
    public float speed;
    public Rigidbody2D rb;
    Vector2 movement;
    [Header("Inputs")]
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;
    [Header("Status")]
    public bool faceLeft;
    public bool faceRight;
    public bool faceUp;
    public bool faceDown;
    public bool canMove;
    public bool stateFishing;
    public int fishstate;
    public bool stateFarming;
    public int farmstate;
    public bool addState;
    public bool farmhit;
    
    void Awake() {
        Instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        faceLeft = false;
        faceRight = false;
        faceUp = false;
        faceDown = true;
        canMove = true;
        Fishing.Instance.Bait.GetComponent<SpriteRenderer>().enabled = false;
        stateFishing = false;  //Fishingstate
        fishstate = 0;  //fishing state: determine steps of fishing
        stateFarming = false;  //FarmingState
        farmstate = 0;  //farming state: determine steps of farming
        addState = false;
        farmhit = false;
    }
     void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        rb.velocity = new Vector2(movement.x * speed, movement.y* speed);  
    }
    void Update()
    {
        switch(FunctionManager.Instance.currentState){
            case FunctionManager.PossibleState.FISHING:
                stateFishing = true;
                stateFarming = false;
                    if(addState){
                    fishstate = 1; 
                    addState = false;
                    }
            break;
             
            case FunctionManager.PossibleState.FARMING:
                stateFarming = true;
                stateFishing = false;
                farmstate = 1;
                fishstate = 0;
            break;

            case FunctionManager.PossibleState.NONE:
                stateFishing = false;
                stateFarming = false;
            break; 
        }

        if(stateFishing){
            SwitchingFishState();
            farmstate = 0;
            }else{
            fishstate = 0;
        }
         if(stateFarming){
            fishstate = 0;
            SwitchingFarmState();
            }else{
            farmstate = 0;
        }

        UI.transform.eulerAngles = new Vector3(0, 0, 0); //the UI should not flip
        movement = Vector2.zero;
        if(movement == Vector2.zero){ //the direction player is facing + animation true false
            if(faceLeft){
                anim.SetBool("leftWalk", false);
                anim.SetBool("faceLeft", true);
                    //NONTRue
                    anim.SetBool("upWalk", false);
                    anim.SetBool("faceUp", false);
                    anim.SetBool("downWalk", false);
                    anim.SetBool("faceDown", false);
            }else if(faceRight){
                anim.SetBool("leftWalk", false);
                anim.SetBool("faceLeft", true);
                    //NONTRue
                    anim.SetBool("upWalk", false);
                    anim.SetBool("faceUp", false);
                    anim.SetBool("downWalk", false);
                    anim.SetBool("faceDown", false);
            }else if(faceDown){
                anim.SetBool("downWalk", false);
                anim.SetBool("faceDown", true);
                    //NONTRue
                    anim.SetBool("upWalk", false);
                    anim.SetBool("faceUp", false);
                    anim.SetBool("leftWalk", false);
                    anim.SetBool("faceLeft", false);
            }else if(faceUp){
                anim.SetBool("upWalk", false);
                anim.SetBool("faceUp", true);
                    //NONTRue
                    anim.SetBool("downWalk", false);
                    anim.SetBool("faceDown", false);
                    anim.SetBool("leftWalk", false);
                    anim.SetBool("faceLeft", false);
            }
        }
        //deteact which direction is facing while clicking which input
        if(canMove){  //set whether player can move while fishing or farming
        Fishing.Instance.Bait.GetComponent<SpriteRenderer>().enabled = false;
        StrRenderer.GetComponent<LineRenderer>().enabled = false;
            if (Input.GetKey(rightKey))
            {
                movement += Vector2.right;
                transform.eulerAngles = new Vector3(0, 180, 0);  //flip player
                    faceLeft = false;
                    faceRight = true;
                    faceUp = false;
                    faceDown = false;
                anim.SetBool("leftWalk", true);
                anim.SetBool("faceLeft", false);
            }
            if (Input.GetKey(leftKey))
            {
                movement += Vector2.left;
                transform.eulerAngles = new Vector3(0, 0, 0);
                    faceLeft = true;
                    faceRight = false;
                    faceUp = false;
                    faceDown = false;
                anim.SetBool("leftWalk", true);
                anim.SetBool("faceLeft", false);
            }
            if (Input.GetKey(upKey))
            {
                movement += Vector2.up;
                    faceLeft = false;
                    faceRight = false;
                    faceUp = true;
                    faceDown = false;
                anim.SetBool("upWalk", true);
                anim.SetBool("faceUp", false);

            }
            if (Input.GetKey(downKey))
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movement += Vector2.down;
                    faceLeft = false;
                    faceRight = false;
                    faceUp = false;
                    faceDown = true;
                anim.SetBool("downWalk", true);
                anim.SetBool("faceDown", false);

            }
        }

        if(fishstate ==1 && stateFarming==false &&ClickableArea.Instance.inField == true){   //Fishing Controls + Animation: if state is 1, not farming, click in field> do animation
                if(Input.GetMouseButton(0)){
                if(faceDown){
                    anim.SetBool("faceDown", false);
                    anim.SetBool("downRaise", true);
                }
                 if(faceUp){
                    anim.SetBool("faceUp", false);
                    anim.SetBool("upRaise", true);
                }
                 if(faceLeft ){
                    anim.SetBool("faceLeft", false);
                    anim.SetBool("leftRaise", true);
                }
                  if(faceRight){
                    anim.SetBool("faceLeft", false);
                    anim.SetBool("leftRaise", true);
                }
                }
        }
        if(farmstate == 2){     //Ploughing Grounds Controls + Animation
                if(faceDown){
                    anim.SetBool("faceDown", false);
                    anim.SetBool("downDig", true);
                    MarkTile(new Vector3(0,-0.6f,0));
                }
                 if(faceUp){
                    anim.SetBool("faceUp", false);
                    anim.SetBool("upDig", true);
                    MarkTile(new Vector3(0,0.6f,0));
                }
                 if(faceLeft){
                    anim.SetBool("faceLeft", false);
                    anim.SetBool("leftDig", true);
                    MarkTile(new Vector3(-0.6f,0,0));
                }
                  if(faceRight){
                    anim.SetBool("faceLeft", false);
                    anim.SetBool("leftDig", true);
                    MarkTile(new Vector3(0.6f,0,0));
                }
                farmstate = 1;  //return to original state
                canMove = true;
            }
    }
    void SwitchingFishState(){    //FishingState
            switch(fishstate){
                case 1:
                    if(Input.GetMouseButtonUp(0)){ //mouseUp, do state 2 stuff
                        StrRenderer.GetComponent<LineRenderer>().enabled = true;
                        fishstate = 2;  //move to next,  ==raise  ==2 
                    }
                break;
                case 2 :
                    canMove = false;
                    if(faceDown){
                        anim.SetBool("downCast", true);
                        anim.SetBool("downRaise", false);
                    }
                    if(faceUp){
                        anim.SetBool("upCast", true);
                        anim.SetBool("upRaise", false);
                    }
                    if(faceLeft ){
                        anim.SetBool("leftCast", true);
                        anim.SetBool("leftRaise", false);
                    }
                    if(faceRight){
                        anim.SetBool("leftCast", true);
                        anim.SetBool("leftRaise", false);
                    }
                    if(Input.GetMouseButtonDown(0)){  //if click while state 2, change to state3
                        fishstate = 3;
                    }
                break;
                case 3 :
                    canMove = false;
                break;
            }
    }
    void SwitchingFarmState(){    //FarmingState
         switch(farmstate){
            case 1:
                if(Input.GetMouseButton(0)&&ClickableArea.Instance.inField == true){ 
                    canMove = false;
                    farmstate = 2;
                }
            break;
        }
    }
    void OnTriggerEnter2D(Collider2D col) {   //Detect when player can cast
        if(col.gameObject.tag == "Bait"){
            if(Fishing.Instance.timer>1){ //cooldown time after reel in
            canMove = true;
            }
            Fishing.Instance.Bait.GetComponent<SpriteRenderer>().enabled = false;
            StrRenderer.GetComponent<LineRenderer>().sortingOrder = 0;//changing sorting layer of the linerenderer;Player = 1;
        }
    }
    void OnTriggerExit2D(Collider2D col) {
         if(col.gameObject.tag == "Bait"){
          Debug.Log("here");
            //canMove = false; //player cannot move while casting
            if(Fishing.Instance.timer>3){ //cooldown time after reel in
            }
            Fishing.Instance.Bait.GetComponent<SpriteRenderer>().enabled = true;
            StrRenderer.GetComponent<LineRenderer>().sortingOrder = 2; //changing sorting layer of the linerenderer;Player = 1;
        }
    }

    //This is Jason, I'm adding a checker function to link this player object with the tilemap
    void MarkTile(Vector3 offset)
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            Tilemap tmpmap = TileManager.tileManager.GroundTilemap;
            Vector3Int tmpcellpos = tmpmap.WorldToCell(transform.position+offset);
        var tmptile = tmpmap.GetTile(tmpcellpos);
        if(TileManager.tileManager.allTiles[tmptile].Seedable)
        {
            tmpmap.SetTileFlags(tmpcellpos, TileFlags.None);
            tmpmap.SetColor(tmpcellpos, Color.black);
        }
        //}
    }
}

