using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public static TileManager tileManager;
    public Tilemap GroundTilemap;
    public List<TileData> tileDatas;
    public Dictionary<TileBase, TileData> allTiles;


    private void Awake()
    {
        if (tileManager == null)
        {
            tileManager = this;
        }
        else if (tileManager != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetAllTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This function loads all the tile types into a dictionary
    private void GetAllTiles()
    {
        allTiles = new Dictionary<TileBase, TileData>();
        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                allTiles.Add(tile, tileData);
                //tileData.MakeTile();
                if (tileData.Name == "Water")
                {
                    
                    GameObject go = new GameObject();
                    go.AddComponent<BoxCollider2D>();
                    //Debug.Log("Generating box collider");
                    //add here
                }
                //Debug.Log(tile + " + " + tileData);
                //Debug.Log(GroundTilemap.GetTile(new Vector3Int(0,0,0)));
            }
        }

        //foreach (var position in GroundTilemap.cellBounds.allPositionsWithin)
        //{
        //    //Debug.Log("Hey Imma trying new stuffs, the position is: "+ position + "The tile be: " +GroundTilemap.GetTile(position));
        //    GameObject show = new GameObject();
        //    //show.AddComponent<TextMeshProUGUI>();
        //    show.name = position + "";
        //    show.AddComponent<BoxCollider2D>();
        //    show.transform.position = GroundTilemap.WorldToCell(position);
        //    //show.GetComponent<TextMeshProUGUI>().text = "" + position;
        //    //show.GetComponent<TextMeshProUGUI>().fontSize = 2;
        //}
    }

    //This is a function that will give a quick acess to a corresponding tile postion based on the world postion
    //The reason that I didn't return TileBase itself is that it actually didn't have a getpos() in itself
    //Maybe I should add one for the tiledata later

    // 
    public TileBase MatchTile(Vector3Int pos)
    {
        //Debug.Log(GroundTilemap.cellBounds);
        //Debug.Log("A "+GroundTilemap.cellBounds.allPositionsWithin);
        //return GroundTilemap.GetTile(GroundTilemap.WorldToCell(pos));

        var tmp_tile = GroundTilemap.GetTile(GroundTilemap.WorldToCell(pos));
        Debug.Log("Seedable " + allTiles[tmp_tile].Seedable);
        return tmp_tile;

        //return GroundTilemap.WorldToCell(pos);
    }
}
