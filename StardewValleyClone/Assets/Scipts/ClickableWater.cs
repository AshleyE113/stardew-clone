using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableWater : MonoBehaviour
{
 
    //public static ClickableArea Instance;
    //public bool inField;
    public GameObject Player;
    // void Awake() {
    //     Instance = this;
    // }
    void Start()
    {
        ClickableArea.Instance.inField = false;
    }
    void Update()
    {
        //this.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y+1f);   //still need a camera track
    }
    void OnMouseDown() {
    }
    void OnMouseOver() {
        ClickableArea.Instance.inField = true;
    }
    void OnMouseExit()
    {
        ClickableArea.Instance.inField = false;
    }
}
