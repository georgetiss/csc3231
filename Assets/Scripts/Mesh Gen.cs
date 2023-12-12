using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MeshGen : MonoBehaviour
{
    Mesh myMesh;
    MeshFilter meshFilter;

    [SerializeField] Vector2 planeSize = new Vector2(1, 1);
    [SerializeField] int planeRes = 1;

    List<Vector3> vertices;
    List<int> triangles;

    //initialise mesh
    void Awake()
    {
        myMesh = new Mesh();
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = myMesh;
    }

    void Update()
    {

        planeRes = Mathf.Clamp(planeRes, 1, 50);

        GeneratePlane(planeSize, planeRes);
        Ripple(Time.timeSinceLevelLoad);
        AssignMesh();

        
    }

    void GeneratePlane(Vector2 size, int res)
    {
        //creates vertices
        vertices = new List<Vector3>();
        float xPerStep = size.x / res;
        float yPerStep = size.y / res;
        for (int y = 0; y < res + 1; y++)
        {
            for (int x = 0; x < res + 1; x++)
            {
                vertices.Add(new Vector3(x * xPerStep, 0, y * yPerStep));
            }    


        }

        // creates triangles

        triangles = new List<int>();
        for (int row = 0; row < res; row++)
        {
            for (int column = 0; column < res; column++)
            {
                int i = (row * res) + row + column;

                triangles.Add(i);
                triangles.Add(i + (res) + 1);
                triangles.Add(i + (res) + 2);

                triangles.Add(i);
                triangles.Add(i + res + 2);
                triangles.Add(i + 1);
            }
        }

    }

    void AssignMesh()
    {
        myMesh.Clear();
        myMesh.vertices = vertices.ToArray();
        myMesh.triangles = triangles.ToArray();
    }

    void Ripple(float time)
    {

        Vector3 origin = new Vector3(planeSize.x / 2, 0, planeSize.y / 2);

        for (int i = 0; i < vertices.Count; i++)
        {
            Vector3 vertex = vertices[i];
            float distance = (vertex - origin).magnitude;
            vertex.y = Mathf.Sin(time + distance);
            vertices[i] = vertex;
        }
    }


}
