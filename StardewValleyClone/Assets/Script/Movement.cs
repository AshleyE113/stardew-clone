using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    //This function will eventually enter the playermanager script
    void Seed()
    {
        var currentPos = new Vector3Int((int)gameObject.transform.position.x, (int)gameObject.transform.position.y, (int)gameObject.transform.position.z);
        Debug.Log(TileManager.tileManager.MatchTile(currentPos));
        TileBase currentTile = TileManager.tileManager.MatchTile(currentPos);
        TileManager.tileManager.GroundTilemap.SetTileFlags(TileManager.tileManager.GroundTilemap.WorldToCell(currentPos), TileFlags.None);
        TileManager.tileManager.GroundTilemap.SetColor(TileManager.tileManager.GroundTilemap.WorldToCell(currentPos), Color.black);
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
