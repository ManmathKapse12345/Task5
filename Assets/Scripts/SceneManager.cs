using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SceneManager : MonoBehaviour
{
    public int numberOfCubes = 5;
    public List<GameObject> cubes = new List<GameObject>();
    public int previousSpawnIndex = -1;
    public int currentSpawnIndex;
    public TMP_Text scoreText;
    public float timeSlot = 2.0f;
    public int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score :- " + score;
        StartCoroutine(MakeCubeGlow());
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score :- " + score;
    }

    private IEnumerator MakeCubeGlow()
    {
        while(true)
        {
            do
            {
                currentSpawnIndex = Random.Range(0, numberOfCubes);
            }
            while (currentSpawnIndex == previousSpawnIndex);
            CubeEvent selectedCube = cubes[currentSpawnIndex].GetComponent<CubeEvent>();
            CubeEvent notSelectedCube;
            var rend = cubes[currentSpawnIndex].GetComponent<Renderer>();
            var mat = rend.material;
            mat.EnableKeyword("_EMISSION");
            var emissionColor = new Color(0.0f, 10.0f, 0.0f, 1.0f);
            mat.SetColor("_EmissionColor", emissionColor);
            float timer = 0.0f;
            while(timer < timeSlot && !selectedCube.isClicked)
            {
                for(int i = 0; i < numberOfCubes; i++)
                {
                    if (i != currentSpawnIndex)
                    {
                        notSelectedCube = cubes[i].GetComponent<CubeEvent>();
                        if (notSelectedCube.isClicked)
                        {
                            Debug.Log("Non Glown Cube is Clicked !");
                            score = score - 1;
                            notSelectedCube.isClicked = false;
                        }
                    }
                }
                timer += Time.deltaTime;
                yield return null;
            }
            if (selectedCube.isClicked)
            {
                Debug.Log("Glown Cube is Clicked !");
                score = score + 1; 
                selectedCube.isClicked = false; 
            }
            if(score >= 40)
            {
                timeSlot = 0.4f;
            }
            else if(score >= 30)
            {
                timeSlot = 0.8f;
            }
            else if(score >= 20)
            {
                timeSlot = 1.2f;
            }
            else if(score >= 10)
            {
                timeSlot = 1.6f;
            }
            else
            { 
                timeSlot = 2.0f;
            }
            mat.DisableKeyword("_EMISSION");
            previousSpawnIndex = currentSpawnIndex;
        }
    }
}
