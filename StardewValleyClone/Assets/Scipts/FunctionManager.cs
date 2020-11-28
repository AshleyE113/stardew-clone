using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionManager : MonoBehaviour
{
    public bool equipHoe;
    public bool equipRod;
    public Fishing sc;
    public PlayerMovement pm;
    public GameObject Player;
    public static FunctionManager Instance;
    void Awake() {
        Instance = this;
    }
    public enum PossibleState 
    {
    NONE,
    FISHING,
    FARMING
    };
    public PossibleState currentState = PossibleState.NONE;
    void Start()
    {
        equipHoe = false;
        equipRod = false;
    }

    void FixedUpdate()
    {
        if(equipHoe){
            currentState = PossibleState.FARMING;     
        }else if(equipRod){
            currentState = PossibleState.FISHING;
        }else{
            currentState = PossibleState.NONE;
        }

    }
    public void ClickFishingRod(){
        equipRod = true;
        equipHoe = false;
        Fishing.Instance.timer = 0;
        PlayerMovement.Instance.addState = true;
    }
    public void ClickHoe(){
        Fishing.Instance.Slider.SetActive(false);
        equipRod = false;
        equipHoe = true;
    }
}
