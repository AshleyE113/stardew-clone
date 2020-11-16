using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLine : MonoBehaviour
{
    public GameObject rodTip;          // Reference to the starting pt
    public GameObject baitPt;          // Reference to the ending point
    public float lineWidth;
    private LineRenderer line;                // Line Renderer
 
     // Use this for initialization
     void Start () {
         // Add a Line Renderer to the GameObject
         line = this.gameObject.GetComponent<LineRenderer>();
         // Set the width of the Line Renderer
         line.SetWidth(lineWidth, lineWidth);
         // Set the number of vertex fo the Line Renderer
         line.SetVertexCount(2); //the vertex must be 2
     }
     
     void Update () {
         // Check if the GameObjects are not null
         if (rodTip != null && baitPt != null)
         {
             // Update position of the two vertex of the Line Renderer
             line.SetPosition(0, rodTip.transform.position);
             line.SetPosition(1, baitPt.transform.position);
         }
     }
 }