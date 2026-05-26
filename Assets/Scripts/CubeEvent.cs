using UnityEngine;

public class CubeEvent : MonoBehaviour
{
    public bool isClicked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        isClicked = true;
    }
}
