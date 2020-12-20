using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableArea : MonoBehaviour
{
    public static ClickableArea Instance;
    public bool inField;
    public GameObject Player;
    void Awake() {
        Instance = this;
    }
    void Start()
    {
        inField = false;
    }
    void Update()
    {
        this.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y+1f);   //still need a camera track
    }
    void OnMouseDown() {
    }
    void OnMouseOver() {
        Debug.Log(this.gameObject.layer);
        LayerMask mask = LayerMask.GetMask("Clickable Area"); 
        if(this.gameObject.layer == mask){
        inField = false;   //true
        }else{
            inField = true;  //false
        }
        //Debug.Log("inarea");
    }
    void OnMouseExit()
    {
        inField = false;
    }
}
