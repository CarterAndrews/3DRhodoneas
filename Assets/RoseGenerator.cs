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
    List<Vector3> vertices;
    List<int> faces;
    // Start is called before the first frame update
    void Start()
    {
        //twodrose();
        //threedrose();
        CreateIcosphere();
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
    void CreateIcosphere()
    {
        var t = (1.0f + Mathf.Sqrt(5.0f)) / 2.0f;
        gs = new GameObject[12];
        vertices = new List<Vector3>();
        vertices.Add(new Vector3(-1, t, 0));
        vertices.Add(new Vector3(1, t, 0));
        vertices.Add(new Vector3(-1, -t, 0));
        vertices.Add(new Vector3(1, -t, 0));

        vertices.Add(new Vector3(0, -1, t));
        vertices.Add(new Vector3(0, 1, t));
        vertices.Add(new Vector3(0, -1, -t));
        vertices.Add(new Vector3(0, 1, -t));

        vertices.Add(new Vector3(t, 0, -1));
        vertices.Add(new Vector3(t, 0, 1));
        vertices.Add(new Vector3(-t, 0, -1));
        vertices.Add(new Vector3(-t, 0, 1));
        gs[0] = Instantiate(g,new Vector3(-1, t, 0), Quaternion.identity);
        gs[1] = Instantiate(g, new Vector3(1, t, 0), Quaternion.identity);
        gs[2] = Instantiate(g, new Vector3(-1, -t, 0), Quaternion.identity);
        gs[3] = Instantiate(g, new Vector3(1, -t, 0), Quaternion.identity);


        gs[4] = Instantiate(g, new Vector3(0, -1, t), Quaternion.identity);
        gs[5] = Instantiate(g, new Vector3(0, 1, t), Quaternion.identity);
        gs[6] = Instantiate(g, new Vector3(0, -1, -t), Quaternion.identity);
        gs[7] = Instantiate(g, new Vector3(0, 1, -t), Quaternion.identity);

        gs[8] = Instantiate(g, new Vector3(t, 0, -1), Quaternion.identity);
        gs[9] = Instantiate(g, new Vector3(t, 0, 1), Quaternion.identity);
        gs[10] = Instantiate(g, new Vector3(-t, 0, -1), Quaternion.identity);
        gs[11] = Instantiate(g, new Vector3(-t, 0, 1), Quaternion.identity);

        var faces = new List<int>();

        // 5 faces around point 0

        faces.Add(0);
        faces.Add(11);
        faces.Add(5);

        faces.Add(0);
        faces.Add(5);
        faces.Add(1);

        faces.Add(0);
        faces.Add(1);
        faces.Add(7);

        faces.Add(0);
        faces.Add(7);
        faces.Add(10);

        faces.Add(0);
        faces.Add(10);
        faces.Add(11);
        // 5 adjacent faces 

        faces.Add(1);
        faces.Add(5);
        faces.Add(9);

        faces.Add(5);
        faces.Add(11);
        faces.Add(4);

        faces.Add(11);
        faces.Add(10);
        faces.Add(2);

        faces.Add(10);
        faces.Add(7);
        faces.Add(6);

        faces.Add(7);
        faces.Add(1);
        faces.Add(8);
        // 5 faces around point 3

        faces.Add(3);
        faces.Add(9);
        faces.Add(4);

        faces.Add(3);
        faces.Add(4);
        faces.Add(2);

        faces.Add(3);
        faces.Add(2);
        faces.Add(6);

        faces.Add(3);
        faces.Add(6);
        faces.Add(8);

        faces.Add(3);
        faces.Add(8);
        faces.Add(9);
        // 5 adjacent faces 

        faces.Add(4);
        faces.Add(9);
        faces.Add(5);

        faces.Add(2);
        faces.Add(4);
        faces.Add(11);
        
        faces.Add(6);
        faces.Add(2);
        faces.Add(10);

        faces.Add(8);
        faces.Add(6);
        faces.Add(7);

        faces.Add(9);
        faces.Add(8);
        faces.Add(1);
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = vertices.ToArray() ;
        mesh.triangles = faces.ToArray();
        mesh.RecalculateNormals();
    }
        // Update is called once per frame
        void Update()
    {
        /*for (int j = 0; j < vertCount; j++)
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
        }*/
    }
}
