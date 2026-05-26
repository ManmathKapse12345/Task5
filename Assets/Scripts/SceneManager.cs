using UnityEngine;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour
{
    public int numberOfCubes = 5;
    public List<GameObject> cubes = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int spawnIndex = Random.Range(0, numberOfCubes);
        var rend = cubes[spawnIndex].GetComponent<Renderer>();
        rend.material.color = Color.green;
        
    }
}
