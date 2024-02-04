using UnityEngine;

public class DrawMesh : MonoBehaviour
{
    public Material material; // Assign this in the Inspector

    public PipePart pipepart;
    public int x1,y1,z1,x2,y2,z2;
    void Start()
    {
        UpdateMesh(pipepart);
    }

    void Update()
    {
        // Update the mesh if needed (e.g., if PipePart points change)
        UpdateMesh(pipepart);
    }

    void UpdateMesh(PipePart pp)
    {
        this.gameObject.transform.position = pp.pointA;

        this.gameObject.transform.rotation = pp.GetRotation();

        // Calculate normals and UVs if needed
        // Attach the mesh to the GameObject
        GetComponent<MeshFilter>().mesh = pp.mesh;
        GetComponent<MeshRenderer>().material = material;
    }
}

