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
    private SimpleInvent inventory;
    WaitForSeconds delay = new WaitForSeconds(3f);
    //ArrayList Inventory = new ArrayList();

    ///*

    //Put tag on mouse
    void Start()
    {
        readyToHarvest = false;
        inHere = false; 
        inventory = GameObject.FindGameObjectWithTag("Seed").GetComponent<SimpleInvent>();
    }
    //*/

    private void OnMouseDown()
    {
        isDragging = true; 
        
        if (readyToHarvest == true)
        {
            Debug.Log("Ready to reap!");
            //Seeds.SetActive(false);
            for (int i = 0; i < inventory.Slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    Debug.Log("Reaping time!");
                    inventory.isFull[i] = true;
                    break;
                }
            }
            //Inventory.Add(Plant1[Plant1.Length-1]);
        }
    }

    //Gets te mouse's position in the game scene
    private void OnMouseUp() 
    {
        isDragging = false;    
    }

    void Update()
    {
        //Commented out by Jason
        //Jason: In SDV this is not done by dragging but pressing buttons while selecting on the seed in inventroy
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

    //Mod by Jason
    public IEnumerator ShowGrowth()
    {
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
