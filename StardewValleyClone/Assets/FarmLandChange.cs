using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLandChange : MonoBehaviour
{
    public Color HasSeeds;
    public GameObject Seeds;
    // Start is called before the first frame update


    private void OnCollisionEnter2D(Collision2D Seeds)
    {
        Debug.Log("Staying here");
        GetComponent<SpriteRenderer>().color = HasSeeds;
        //new Color(0.63f, 0.78f, 0.61f);
    }

    private void OnCollisionStay2D(Collision2D Seeds)
    {
        Debug.Log("Staying here");
        GetComponent<SpriteRenderer>().color = HasSeeds;     
    }

    // Update is called once per frame
    /*void Update()
    {
        if (ToPlant.OnLand)
        {
            GetComponent<SpriteRenderer>().color = waterColor;
            new Color(0.63f, 0.78f, 0.61f);
        }
    }
    */
}
