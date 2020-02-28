using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseGenerator : MonoBehaviour
{
    public float width;
    public Vector3[] positions;
    public int vertCount;
    public float a;
    public float b;
    public int rotations;
    public GameObject g;
    public GameObject[] gs;
    // Start is called before the first frame update
    void Start()
    {
        //twodrose();
        threedrose();
    }
    void twodrose()
    {
        print("script working");
        LineRenderer lr = GetComponent<LineRenderer>();
        positions = new Vector3[vertCount];

        for (int i = 0; i < vertCount; i++)
        {
            float x = Mathf.Sin(2 * Mathf.PI * ((float)i / (float)vertCount));
            float y = Mathf.Cos(2 * Mathf.PI * ((float)i / (float)vertCount));
            float z = 0;
            float r = a * Mathf.Cos(b * 2 * Mathf.PI * ((float)i / (float)vertCount));
            positions[i] = new Vector3(x, y, z) * r;
        }
        lr.positionCount = vertCount;
        lr.SetPositions(positions);
    }
    void threedrose()
    {
        gs = new GameObject[vertCount*vertCount];
        for (int j = 0; j < vertCount; j++)
        {
            for (int i = 0; i < vertCount; i++)
            {
                float x = Mathf.Sin(2 * Mathf.PI * ((float)i / (float)vertCount))* Mathf.Cos(2 * Mathf.PI * ((float)j / (float)vertCount));
                float y = Mathf.Sin(2 * Mathf.PI * ((float)i / (float)vertCount))* Mathf.Sin(2 * Mathf.PI * ((float)j / (float)vertCount));
                float z = Mathf.Cos(2 * Mathf.PI * ((float)i / (float)vertCount));
                //float r = a * Mathf.Cos(b * 2 * Mathf.PI * ((float)i / (float)vertCount))* Mathf.Sin(b * 2 * Mathf.PI * ((float)j / (float)vertCount));
                float r = 1;
                gs[j*vertCount+i]=Instantiate(g, new Vector3(x, y, z)*r, Quaternion.identity);
                gs[j * vertCount + i].transform.parent = transform;
            }
        }
        //lr.positionCount = vertCount;

    }
        // Update is called once per frame
        void Update()
    {
        for (int j = 0; j < vertCount; j++)
        {
            for (int i = 0; i < vertCount; i++)
            {
                float x = Mathf.Sin(2 * Mathf.PI * ((float)i / (float)vertCount)) * Mathf.Cos(2 * Mathf.PI * ((float)j / (float)vertCount));
                float y = Mathf.Sin(2 * Mathf.PI * ((float)i / (float)vertCount)) * Mathf.Sin(2 * Mathf.PI * ((float)j / (float)vertCount));
                float z = Mathf.Cos(2 * Mathf.PI * ((float)i / (float)vertCount));
                //float r = a * Mathf.Cos(b * 2 * Mathf.PI * ((float)i / (float)vertCount)) * Mathf.Sin(b * 2 * Mathf.PI * ((float)j / (float)vertCount));
                float r = 1;
                gs[j * vertCount + i].transform.localPosition = new Vector3(x, y, z) * r;
            }
        }
    }
}
