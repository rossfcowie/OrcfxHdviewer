using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newBlock = Instantiate(prefab, this.gameObject.transform);
        DrawMesh prefabScript = newBlock.GetComponent<DrawMesh>();
        if (prefabScript != null)
        {
            // Assign your object to the prefab's script property
            prefabScript.pipepart = new PipePart(4,4,4,1,1,1);
        }
        newBlock.name = "MyBlockInstance";
    }

    // Update is called once per frame
    void Update()
    {

    }
}


public class PipePart
{
    public Vector3 pointA;
    public Vector3 pointB;
    public Mesh mesh;
    public PipePart(int a, int b, int c, int d, int e, int f)
    {
        pointA = new Vector3(a, b, c);
        pointB = new Vector3(d, e, f);
        ProcCylinder pc = new ProcCylinder();
        pc.m_Height = Vector3.Distance(pointA,pointB);
        mesh = pc.BuildMesh();
    }

    public Quaternion GetRotation()
    {
        return Quaternion.LookRotation(Direction(), Vector3.up);
    }

    public Vector3 Direction()
    {
        return pointB - pointA;
    }
}