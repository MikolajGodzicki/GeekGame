using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
public class MeshManager : MonoBehaviour
{
    [SerializeField] Vector3 rippleOrgin;

    Mesh mesh;

    Vector3[] verticesArray, newVerticesAarrays;

    private void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;

        verticesArray = mesh.vertices;
        newVerticesAarrays = new Vector3[mesh.vertexCount];
    }

    private void Update()
    {
        for(int i = 0; i < newVerticesAarrays.Length; i++)
        {
            Vector3 orginalVertex = verticesArray[i];
            float distance = Vector3.Distance(orginalVertex, rippleOrgin);
            float rippleAmount = Mathf.Sin(distance - Time.time);
            Vector3 offset = (orginalVertex - rippleOrgin).normalized * rippleAmount;
            Vector3 newPos = orginalVertex + offset;

            newVerticesAarrays[i] = newPos;
        }

        mesh.SetVertices(newVerticesAarrays);
    }
}
