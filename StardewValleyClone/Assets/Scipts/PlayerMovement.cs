using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Vector2 movement;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;
    Animator anim;
    public bool faceLeft;
    public bool faceRight;
    public bool faceUp;
    public bool faceDown;

    void Start()
    {
          rb = GetComponent<Rigidbody2D>();
          anim = GetComponent<Animator>();
          faceLeft = false;
          faceRight = false;
          faceUp = false;
          faceDown = true;
    }

     void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        rb.velocity = new Vector2(movement.x * speed, movement.y* speed);  

    }
    void Update()
    {
        movement = Vector2.zero;
        if(movement == Vector2.zero){
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
     
        //deteacrt which direction is facing while clicking which input
        if (Input.GetKey(rightKey))
        {
            movement += Vector2.right;
            transform.eulerAngles = new Vector3(0, 180, 0);  //flip object
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
            movement += Vector2.down;
                faceLeft = false;
                faceRight = false;
                faceUp = false;
                faceDown = true;
            anim.SetBool("downWalk", true);
            anim.SetBool("faceDown", false);

        }


    }
}
