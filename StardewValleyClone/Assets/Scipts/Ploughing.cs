using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//determine the front tile of player to be swap to a ready to spawn seed ground
public class Ploughing : MonoBehaviour
{
     public static Ploughing Instance;
     public bool canDig;
   void Awake() {
        Instance = this;
    }
    void Start()
    {
        canDig = false;
    }

    void Update()
    {
        
    }
}
