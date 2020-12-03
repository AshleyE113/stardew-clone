using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToPlant : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LandPlot;
    public GameObject Seeds;
    public bool OnLand;
    public bool isDragging;
    public GameObject newInstance;
    public bool readyToHarvest;
    public bool inHere;
    public Sprite[] Plant1;
    public float Start_Time = 40;
    //private int plant_index = 0;

    WaitForSeconds delay = new WaitForSeconds(5f);
    

    ///*
    void Start()
    {
        readyToHarvest = false;
        inHere = false;       
    }
    //*/

    private void OnMouseDown()
    {
        isDragging = true; 
    }

    //Gets te mouse's position in the game scene
    private void OnMouseUp() 
    {
        isDragging = false;    
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }

        if (OnLand == true && readyToHarvest == false && inHere == false)
        {
            StartCoroutine(ShowGrowth());
        }
    } 

    IEnumerator ShowGrowth()
    {
        /*Destroy(Plant1[plant_index++]);
        if (plant_index < Plant1.Length)
        {
            Invoke("ShowGrowth", 5f);
        }*/
        inHere = true;
        for (int i = 0; i < Plant1.Length; i++)
        {
            Debug.Log("In loop");
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Plant1[i];
            yield return delay;

            if (i == Plant1.Length-1)
            {
                Debug.Log("breaking");
                readyToHarvest = true;
                inHere = false;
                break;
            }
            
            /* if (Start_Time % 5 == 0)
            {
                Debug.Log("In if");
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Plant1[i];
            } */
            
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnLand = true;
        //Seeds.SetActive(false);
        Debug.Log("In the soil");
        
        //Destroy(newInstance);
        //As time passes, the plants grow
        
    }
}
