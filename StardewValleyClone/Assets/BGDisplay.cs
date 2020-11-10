using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGDisplay : MonoBehaviour
{
    public GameObject BGland;
    // Makes it easier to create the BG
    void Start()
    {
        //For covering screen with grass
        /*
        for (int x_pos = 0; x_pos <10; x_pos++)
        {
            for (int y_pos = 10; y_pos > 0; y_pos--)
            {
                Instantiate(BGDisplay, new Vector3(x_pos, y_pos, 0));
            }
        }
        */
        
    }

}
