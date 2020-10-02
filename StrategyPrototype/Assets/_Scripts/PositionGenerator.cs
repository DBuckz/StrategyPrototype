using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }
    public GenerationTable myGenTable;

    [Range(0,100)]
    public float spawnRate = 2f;

    public int mapSize = 20;
    public float space = 20f;
    [Header("Gen Point Settings")]
    public Vector3 point = new Vector3();
    public Vector3 pointRand = new Vector3();
    public float minimum = 5f;
    public float maximum = 5f;

    private int p = 0;
    void GenerateMap()
    {

        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                for (int k = 0; k < mapSize; k++)
                {
                    Debug.Log("Total Iterations");
                    float chance = Random.Range(0,100);
                    pointRand = new Vector3(Random.Range(minimum,maximum), Random.Range(minimum, maximum), Random.Range(minimum, maximum));
                    if (spawnRate > chance)
                    {
                        Instantiate(myGenTable.objects[Random.Range(0,myGenTable.objects.Length)],point = new Vector3((space*i)+Random.Range(minimum,maximum),(space*j) + Random.Range(minimum, maximum), (space*k) + Random.Range(minimum, maximum)),Quaternion.identity);
                        p++;
                        Debug.Log("Objects Spawned ");
                    }


                }
            }
        }
    }

}
