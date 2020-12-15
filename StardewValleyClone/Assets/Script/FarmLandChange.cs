using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLandChange : MonoBehaviour
{
    public Color HasSeeds;
    public Color NoSeeds;
    public GameObject Seeds;

    public Texture2D appearance;
    private Sprite sprout;

    private SpriteRenderer Rend_spr;
    public bool canHarvest;
    public bool mouseOver;

    void Start()
    {
        mouseOver = false;   
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        GetComponent<SpriteRenderer>().color = HasSeeds;
        canHarvest = true;
    }
    

    private void OnMouseEnter()
    {
        mouseOver = true;
    }
    void Reap()
    {
        GetComponent<SpriteRenderer>().color = NoSeeds;
    }

    // Update is called once per frame
    void Update()
    {
        if (canHarvest && Input.GetMouseButtonDown(0) && mouseOver == true)
        {
            Reap();
        }
    }
    
}
