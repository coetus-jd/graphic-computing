using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VisualizationPipeline.Assets.Scripts.Enums;

namespace VisualizationPipeline.Assets.Scripts
{
    public class ObjectCreationController : BasePipeline
    {
        [SerializeField] private GameObject CubePrefab;
        [SerializeField] private GameObject SpherePrefab;
        [SerializeField] private Dropdown ObjectSelect;
        [SerializeField] private Transform PositionToCreate;

        public void CreateObject()
        {
            if (ObjectSelect.value == (int)ObjectsTypes.Custom)
                return;

            if (ObjectInPipeline != null)
                Destroy(ObjectInPipeline);

            GameObject objectToCreate = null;

            if (ObjectSelect.value == (int)ObjectsTypes.Cube)
                objectToCreate = CubePrefab;
                
            if (ObjectSelect.value == (int)ObjectsTypes.Sphere)
                objectToCreate = SpherePrefab;
            
            Instantiate(
                objectToCreate,
                PositionToCreate.position,
                Quaternion.identity,
                Objects.transform
            );
        }
    }
}