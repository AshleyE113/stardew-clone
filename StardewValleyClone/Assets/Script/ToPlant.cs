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

    //For Grow fun

    ///*
    void Start()
    {
        //newInstance = Instantiate(Seeds, new Vector3(0, 0, 0), Quaternion.identity);        
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
    } 

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnLand = true;
        Debug.Log("In the soil");
        Seeds.SetActive(false);
        //Destroy(newInstance);
    }
}
