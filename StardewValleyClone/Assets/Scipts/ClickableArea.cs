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
        this.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y+0.2491404f);   //still need a camera track
    }
    void OnMouseDown() {
    }
    void OnMouseOver() {
        inField = true;
        Debug.Log("inarea");
    }
    void OnMouseExit()
    {
        inField = false;
    }
}
