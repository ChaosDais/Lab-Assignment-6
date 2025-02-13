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
        for(int i = 4; i >= 0; i--)
        {
            Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0f, 1f);
            for (int row = 0; row < i + 1; row++)
            {
                for (int col = 0; col < i + 1; col++)
                {
                    GameObject stone = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    stone.transform.parent = pyramidParent.transform;
                    stone.transform.position = new Vector3(col + 1.8f - (0.45f * i), 4.45f - i, row + 1.8f - (0.45f * i));
                    stone.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                    stone.GetComponent<Renderer>().material.color = color;
                }

            }
        }
    }
}
