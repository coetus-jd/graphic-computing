using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VisualizationPipeline.Assets.Scripts.Enums;

namespace VisualizationPipeline.Assets.Scripts
{
    public class ObjectCreationController : BasePipeline
    {
        [SerializeField] private GameObject CubePrefab;
        [SerializeField] private GameObject CapsulePrefab;
        [SerializeField] private GameObject CustomObjectPrefab;
        [SerializeField] private Dropdown ObjectSelect;
        [SerializeField] private Transform PositionToCreate;
        [SerializeField] private Button CreateButton;

        public void CreateObject()
        {
            if (ObjectInPipeline != null)
                Destroy(ObjectInPipeline);

            GameObject objectToCreate = null;

            if (ObjectSelect.value == (int)ObjectsTypes.Custom)
                objectToCreate = CustomObjectPrefab;

            if (ObjectSelect.value == (int)ObjectsTypes.Cube)
                objectToCreate = CubePrefab;
                
            if (ObjectSelect.value == (int)ObjectsTypes.Capsule)
                objectToCreate = CapsulePrefab;
            
            Instantiate(
                objectToCreate,
                // When is a custom object, using PositionToCreate.position
                // is putting the object out of camera's range
                ObjectSelect.value == (int)ObjectsTypes.Custom
                    ? new Vector3(0, 0, 0)
                    : PositionToCreate.position,
                objectToCreate.transform.rotation,
                Objects.transform
            );
        }


        public void HandleSelectedValue()
        {
            // if (ObjectSelect.value != (int)ObjectsTypes.Custom)
            // {
            //     CreateButton.interactable = true;
            //     return;
            // }

            // CreateButton.interactable = false;
        }

        public void DeleteObjectInPipeline()
        {
            if (ObjectInPipeline != null)
                Destroy(ObjectInPipeline);
        }
    }
}