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
        Debug.Log("Triggering here");
        GetComponent<SpriteRenderer>().color = HasSeeds;
        GrowPlant();
        canHarvest = true;
    }
    

    //Must...
//Start off with a small sprite and then as time passes it grows.
    void GrowPlant()
    {
        //Instansiate a sprite, a small square
        //Rend_spr = gameObject.AddComponent<SpriteRenderer>(); //as SpriteRenderer;
        //Rend_spr.color = new Color(1.0f, 2.0f, 3.0f, 4.0f);
        Sprite.Create(appearance, new Rect(1.9f, 1.9f, 1.9f, 1.9f), new Vector2(Seeds.transform.position.x, Seeds.transform.position.y));
        Debug.Log("Hey! I'm here");

    }

    private void OnMouseEnter()
    {
        mouseOver = true;
    }
    void Reap()
    {
        GetComponent<SpriteRenderer>().color = NoSeeds;
        Debug.Log("Reaping here");
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
