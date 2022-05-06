using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace VisualizationPipeline.Assets.Scripts
{
    public class MeshGenerator : MonoBehaviour
    {
        [SerializeField] private List<Vector3> Vertices;
        [SerializeField] private List<int> Triangles;
        [SerializeField] private Mesh CurrentMesh;
        [SerializeField] private TMP_Text VerticesText;
        [SerializeField] private TMP_Text TrianglesText;

        private (float Width, float Height) ValidScreenRange = (0, 0);

        private void Start()
        {
            CurrentMesh = new Mesh();
            GetComponent<MeshFilter>().sharedMesh = CurrentMesh;
            ValidScreenRange.Width = Screen.currentResolution.width / 2;
            ValidScreenRange.Height = Screen.currentResolution.height / 2;
            // VerticesText.SetActive(true);
            // TrianglesText.SetActive(true);
        }

        private void OnDestroy()
        {
            // VerticesText.SetActive(false);
            // TrianglesText.SetActive(false);
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
                return;

            Debug.Log($"Screen: {ValidScreenRange.Width}");
            Debug.Log($"Mouse: {Input.mousePosition.x}");
            // Gambiarra
            if (Input.mousePosition.x > ValidScreenRange.Width)
                return;

            var verticePosition = MousePosInWorldSpace();

            Vertices.Add(verticePosition);
            Triangles.Add(Vertices.Count - 1);

            // VerticesText.text = $"Vertices: {Vertices.Count}";
            // TrianglesText.text =  $"Triangles: {(int)(Triangles.Count / 3)}";

            if ((Triangles.Count % 3) == 0)
                CreateCustomObject();
        }

        private Vector3 MousePosInWorldSpace() =>
            Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)
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