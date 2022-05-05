using System.Collections.Generic;
using UnityEngine;

namespace VisualizationPipeline.Assets.Scripts
{
    public class MeshGenerator : MonoBehaviour
    {
        [SerializeField] private List<Vector3> Vertices;
        [SerializeField] private List<int> Triangles;
        [SerializeField] private Mesh CurrentMesh;

        private void Start()
        {
            CurrentMesh = new Mesh();
            GetComponent<MeshFilter>().sharedMesh = CurrentMesh;
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
                return;

            var verticePosition = MousePosInWorldSpace();

            Vertices.Add(verticePosition);
            Triangles.Add(Vertices.Count - 1);

            if ((Triangles.Count % 3) == 0)
                CreateCustomObject();
        }

        private Vector3 MousePosInWorldSpace() =>
            Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)
            );

        public void CreateCustomObject()
        {
            CurrentMesh.Clear();
            CurrentMesh.vertices = Vertices.ToArray();
            CurrentMesh.triangles = Triangles.ToArray();
            CurrentMesh.RecalculateNormals();
        }
    }
}