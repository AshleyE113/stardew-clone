using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farming : MonoBehaviour
{
    //Is it better to have an array or an ArrayList?
    //ArrayLists are muatable while arrays aren't
    // List pf 5 can change, an array of 5 can't...
    public GameObject[][] crops;

    public GameObject LandPlot;

    public Color HasSeeds;
    public GameObject Seeds;

    // Start is called before the first frame update
    void Start()
    {
        /*
        for (int land_row = 0; land_row < 6; land_row++)
        {
            for (int land_col = 5; land_col > 0; land_col--)
            {
                crops[land_row][land_col] = LandPlot;
            }
        }
        */
    }

    // Start is called before the first frame update

    private void OnCollisionExit2D(Collision2D Seed)
    {
        //GetComponent<SpriteRenderer>().color = HasSeeds;
        Debug.Log("Left the soil area");
        //new Color(0.63f, 0.78f, 0.61f);
    }
}
