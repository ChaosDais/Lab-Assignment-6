using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DesertScene : MonoBehaviour
{
    public int sizeOfForest;
    public int stonesRequired;
    public GameObject[] trees;
    public GameObject[] stones;

    void Start()
    {
        
        InitializeVariables();
        CreateGround();
        CreateRandomForest();
        CreatePyramid();
    }

    void InitializeVariables()
    {
        sizeOfForest = Random.Range(5, 20);
        trees = new GameObject[sizeOfForest];
        stonesRequired = 25 + 16 + 9 + 4 + 1;
        stones = new GameObject[stonesRequired];
    }

    void CreateGround()
    {
        //create a plane
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);


        Renderer renderer = plane.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Standard"));
        renderer.material.color = Color.red;
    }

    void CreateRandomForest()
    {
        GameObject forestParent = new GameObject("Forest");

        for (int i = 0; i < trees.Length; i++)
        {

            GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cylinder.transform.parent = forestParent.transform;
            cylinder.transform.localScale = new Vector3(Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f));
            cylinder.transform.position = new Vector3(Random.Range(-4f, -2f), 0, Random.Range(-4, -2f));
            cylinder.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    void CreatePyramid()
    {
        GameObject pyramidParent = new GameObject("Pyramid");
        // First level
        Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        for (int row = 0; row < 5; row++)
        {
            for(int col = 0; col < 5; col++)
            { 
                GameObject stone = GameObject.CreatePrimitive(PrimitiveType.Cube);
                stone.transform.parent = pyramidParent.transform;
                stone.transform.position = new Vector3(col, 0.45f, row);
                stone.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                stone.GetComponent<Renderer>().material.color = color;
            }
            
        }
        color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        // Second level
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                GameObject stone = GameObject.CreatePrimitive(PrimitiveType.Cube);
                stone.transform.parent = pyramidParent.transform;
                stone.transform.position = new Vector3(col + 0.45f, 1.45f, row + 0.45f);
                stone.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                stone.GetComponent<Renderer>().material.color = color;
            }

        }
        color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        // Third level
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                GameObject stone = GameObject.CreatePrimitive(PrimitiveType.Cube);
                stone.transform.parent = pyramidParent.transform;
                stone.transform.position = new Vector3(col + 0.9f, 2.45f, row + 0.9f);
                stone.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                stone.GetComponent<Renderer>().material.color = color;
            }

        }
        color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        // Fourth level
        for (int row = 0; row < 2; row++)
        {
            for (int col = 0; col < 2; col++)
            {
                GameObject stone = GameObject.CreatePrimitive(PrimitiveType.Cube);
                stone.transform.parent = pyramidParent.transform;
                stone.transform.position = new Vector3(col + 1.35f, 3.45f, row + 1.35f);
                stone.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                stone.GetComponent<Renderer>().material.color = color;
            }

        }
        color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        // Last cube
        GameObject topStone = GameObject.CreatePrimitive(PrimitiveType.Cube);
        topStone.transform.parent = pyramidParent.transform;
        topStone.transform.position = new Vector3(1.8f, 4.45f, 1.85f);
        topStone.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        topStone.GetComponent<Renderer>().material.color = color;
    }
}
