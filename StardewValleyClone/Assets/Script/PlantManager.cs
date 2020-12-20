using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public GameObject GrowingSeedPrefab;
    int count;
    public static PlantManager plantManager;
    public Dictionary<Vector3,GameObject> plantList;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        if (plantManager == null)
        {
            plantManager = this;
        }

        plantList = new Dictionary<Vector3, GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GeneratePlant(Vector3 pos)
    {
        var tmp = plantList.ContainsKey(pos);
        Debug.Log(tmp);
        if (!tmp)
        {
            var newPlant = Instantiate(GrowingSeedPrefab, pos, Quaternion.identity);
            count++;
            newPlant.name = newPlant.name + count;
            plantList.Add(pos, newPlant);
        }
    }

    public void DeleteFromList(Vector3 pos)
    {
        plantList.Remove(pos);
    }
}
