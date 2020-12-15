using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public GameObject GrowingSeedPrefab;
    int count;
    public static PlantManager plantManager;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        if (plantManager == null)
        {
            plantManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GeneratePlant(Vector3 pos)
    {
        var newPlant = Instantiate(GrowingSeedPrefab, pos, Quaternion.identity);
        count++;
        newPlant.name = newPlant.name + count;
    }
}
