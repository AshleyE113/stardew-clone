using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    //This function will eventually enter the playermanager script
    void Seed()
    {
        //var currentPos = new Vector3Int((int)gameObject.transform.position.x, (int)gameObject.transform.position.y, (int)gameObject.transform.position.z);
        var currentPos = Vector3Int.FloorToInt(gameObject.transform.position);
        //Debug.Log(TileManager.tileManager.MatchTile(currentPos));
        //TileBase currentTile = TileManager.tileManager.MatchTile(currentPos);
        Vector3Int tileCellPos = TileManager.tileManager.MatchTile(currentPos);
        Debug.Log(currentPos+" "+tileCellPos);
        TileManager.tileManager.GroundTilemap.SetTileFlags(tileCellPos, TileFlags.None);
        TileManager.tileManager.GroundTilemap.SetColor(tileCellPos, Color.black);
    }

  void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Seed();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Transform>().Translate(new Vector3(.05f, 0, 0));
            //GetComponent<Transform>().Translate(Vector3.left, right...); works
            //transform. can replace GetCompt...>() section
            //GetComponent<Animator>().Play("Right");
        } 
        else if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Transform>().Translate(new Vector3(-.05f,0,0));
                //GetComponent<Animator>().Play("Left");
            
            }
            else if (Input.GetKey(KeyCode.UpArrow))
                {
                    GetComponent<Transform>().Translate(new Vector3(0, .05f, 0));
                }

              else if (Input.GetKey(KeyCode.DownArrow))
                {
                    GetComponent<Transform>().Translate(new Vector3(0, -.05f, 0));
                }
                else
                {
                    //GetComponent<Animator>().Play("Idle");
                }
    }
}
