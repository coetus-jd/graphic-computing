using System.Collections.Generic;
using UnityEngine;
using TMPro;
using VisualizationPipeline.Assets.Scripts.Enums;
using System.Linq;

namespace VisualizationPipeline.Assets.Scripts
{
    public class MeshGenerator : MonoBehaviour
    {
        [SerializeField] private List<Vector3> Vertices;
        [SerializeField] private List<int> Triangles;
        [SerializeField] private Mesh CurrentMesh;
        [SerializeField] private string VerticesElementTag;
        [SerializeField] private string TrianglesElementTag;
        private GameObject VerticesText;
        private GameObject TrianglesText;

        private (float Width, float Height) ValidScreenRange = (0, 0);

        private void Start()
        {
            CurrentMesh = new Mesh();
            GetComponent<MeshFilter>().sharedMesh = CurrentMesh;
            ValidScreenRange.Width = Screen.currentResolution.width / 2;
            ValidScreenRange.Height = Screen.currentResolution.height / 2;

            ConfigureUiElements();
        }

        private void OnDestroy()
        {
            VerticesText?.SetActive(false);
            TrianglesText?.SetActive(false);
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown((int)MouseButtons.Left))
                return;
            
            // Limit click area
            if (Input.mousePosition.x > ValidScreenRange.Width)
                return;

            var verticePosition = MousePosInWorldSpace();

            Vertices.Add(verticePosition);
            Triangles.Add(Vertices.Count - 1);

            VerticesText.GetComponent<TMP_Text>().text = $"Vertices: {Vertices.Count}";
            TrianglesText.GetComponent<TMP_Text>().text =  $"Triangles: {(int)(Triangles.Count / 3)}";

            if ((Triangles.Count % 3) == 0)
                CreateCustomObject();
        }

        public void CreateCustomObject()
        {
            CurrentMesh.Clear();
            CurrentMesh.vertices = Vertices.ToArray();
            CurrentMesh.triangles = Triangles.ToArray();
            CurrentMesh.RecalculateNormals();
        }

        private Vector3 MousePosInWorldSpace() =>
            // The Z axis is 10 because the camera is -10 in Z
            Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)
            );

        private void ConfigureUiElements()
        {
            var allTexts = Resources.FindObjectsOfTypeAll<TMP_Text>();

            VerticesText = allTexts.FirstOrDefault(x => x.tag == VerticesElementTag).gameObject;
            TrianglesText = allTexts.FirstOrDefault(x => x.tag == TrianglesElementTag).gameObject;
            
            VerticesText?.SetActive(true);
            TrianglesText?.SetActive(true);
        }
    }
}