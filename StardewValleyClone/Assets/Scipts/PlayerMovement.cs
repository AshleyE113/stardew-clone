using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    public Animator anim;
    public GameObject StrRenderer;
    public GameObject UI;
    [Header("Physics")]
    public float speed;
    Rigidbody2D rb;
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
    private bool raise;
    
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
          raise = false;
            StrRenderer.GetComponent<FishingLine>().enabled = false;
    }

     void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        rb.velocity = new Vector2(movement.x * speed, movement.y* speed);  

    }
    void Update()
    {
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
        //FishingControl+animation on Click
if(Fishing.Instance.canFish){ //if player is not ready to cast, dont play animation
        if(Input.GetMouseButton(0)){ //this side control mainly the animation of the player when casting
            //canMove = false;
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
            raise = true;
        }
        if(raise){
            canMove = false;
            if(Input.GetMouseButtonUp(0)){
                 StrRenderer.GetComponent<FishingLine>().enabled = true;
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
                    raise = false;
            }
        }
    }
    }
    void OnTriggerEnter2D(Collider2D col) {   //Detect when player can cast
        if(col.gameObject.tag == "Bait"){
            Debug.Log("here");
            canMove = true; //player can move after reeling in
            if(Fishing.Instance.timer>3){ //cooldown time after reel in
            Fishing.Instance.canCast = true; //can cast again after cool down
            }
            Fishing.Instance.Bait.GetComponent<SpriteRenderer>().enabled = false;
            StrRenderer.GetComponent<LineRenderer>().sortingOrder = 0;//changing sorting layer of the linerenderer;Player = 1;
        }
    }
    void OnTriggerExit2D(Collider2D col) {
         if(col.gameObject.tag == "Bait"){
            Debug.Log("here");
            canMove = false; //player cannot move while casting
            if(Fishing.Instance.timer>3){ //cooldown time after reel in
            Fishing.Instance.canCast = false; 
            }
            Fishing.Instance.Bait.GetComponent<SpriteRenderer>().enabled = true;
            StrRenderer.GetComponent<LineRenderer>().sortingOrder = 2; //changing sorting layer of the linerenderer;Player = 1;
        }
    }
}
