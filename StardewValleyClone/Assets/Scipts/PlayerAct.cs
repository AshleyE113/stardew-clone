using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAct : MonoBehaviour
{
    public GameObject StrRenderer;
    public Animator anim;
    public GameObject Player;
    void Start()
    {
        anim = Player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
//        if(Fishing.Instance.canFish){ //if player is not ready to cast, dont play animation
// if(Fishing.Instance.canCast){
//         if(Input.GetMouseButton(0)){ //this side control mainly the animation of the player when casting
//             //canMove = false;
            
//                 if(PlayerMovement.Instance.faceDown){
//                     Debug.Log("yehhhhhhh");
//                     anim.SetBool("faceDown", false);
//                     anim.SetBool("downRaise", true);
//                 }
//                  if(PlayerMovement.Instance.faceUp){
//                     anim.SetBool("faceUp", false);
//                     anim.SetBool("upRaise", true);
//                 }
//                  if(PlayerMovement.Instance.faceLeft ){
//                     anim.SetBool("faceLeft", false);
//                     anim.SetBool("leftRaise", true);
//                 }
//                   if(PlayerMovement.Instance.faceRight){
//                     anim.SetBool("faceLeft", false);
//                     anim.SetBool("leftRaise", true);
//                 }
//             PlayerMovement.Instance.raise = true;
//         }
// }
//         if(PlayerMovement.Instance.raise){
//             PlayerMovement.Instance.canMove = false;
//             if(Input.GetMouseButtonUp(0)){
//                  StrRenderer.GetComponent<FishingLine>().enabled = true;
//                  if(PlayerMovement.Instance.faceDown){
//                     anim.SetBool("downCast", true);
//                     anim.SetBool("downRaise", false);
//                 }
//                  if(PlayerMovement.Instance.faceUp){
//                     anim.SetBool("upCast", true);
//                     anim.SetBool("upRaise", false);
//                 }
//                  if(PlayerMovement.Instance.faceLeft ){
//                     PlayerMovement.Instance.anim.SetBool("leftCast", true);
//                     PlayerMovement.Instance.anim.SetBool("leftRaise", false);
//                 }
//                   if(PlayerMovement.Instance.faceRight){
//                     PlayerMovement.Instance.anim.SetBool("leftCast", true);
//                     PlayerMovement.Instance.anim.SetBool("leftRaise", false);
//                 }
//                     PlayerMovement.Instance.raise = false;
//             }
//         }
//     }
    
//     //Ploughing Grounds Controls + Animation
// if(Ploughing.Instance.canDig){
//         if(Input.GetMouseButton(0)){ 
//             if(PlayerMovement.Instance.faceDown){
//                     PlayerMovement.Instance.anim.SetBool("faceDown", false);
//                     PlayerMovement.Instance.anim.SetBool("downDig", true);
//                 }
//                  if(PlayerMovement.Instance.faceUp){
//                     PlayerMovement.Instance.anim.SetBool("faceUp", false);
//                     PlayerMovement.Instance.anim.SetBool("upDig", true);
//                 }
//                  if(PlayerMovement.Instance.faceLeft ){
//                     PlayerMovement.Instance.anim.SetBool("faceLeft", false);
//                     PlayerMovement.Instance.anim.SetBool("leftDig", true);
//                 }
//                   if(PlayerMovement.Instance.faceRight){
//                     PlayerMovement.Instance.anim.SetBool("faceLeft", false);
//                     PlayerMovement.Instance.anim.SetBool("leftDig", true);
//                 }
//         }
//     }    
//     }
}
}
