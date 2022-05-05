using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VisualizationPipeline.Assets.Scripts.Enums;

namespace VisualizationPipeline.Assets.Scripts
{
    public class ObjectCreationController : BasePipeline
    {
        [Header("Prefabs")]
        [SerializeField] private GameObject CubePrefab;
        [SerializeField] private GameObject CapsulePrefab;
        [SerializeField] private GameObject CustomObjectPrefab;

        [Header("Inputs")]
        [SerializeField] private Dropdown ObjectSelect;
        [SerializeField] private Transform PositionToCreate;

        [Header("UI")]
        [SerializeField] private Button CreateButton;
        [SerializeField] private List<GameObject> ObjectsToDesactive;
        [SerializeField] private List<GameObject> ObjectsToReset;

        private void Start()
        {
            CheckObjectsToDesactive();
        }

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

            CheckObjectsToReset();
            CheckObjectsToDesactive();
        }


        public void HandleSelectedValue()
        {
            CheckObjectsToDesactive();
        }

        public void DeleteObjectInPipeline()
        {
            if (ObjectInPipeline != null)
            {
                Destroy(ObjectInPipeline);
                ObjectsToDesactive.ForEach(x => x.SetActive(false));
                CheckObjectsToReset();
            }
        }

        private void CheckObjectsToDesactive() =>
            ObjectsToDesactive.ForEach(obj => obj.SetActive(ObjectInPipeline != null));

        private void CheckObjectsToReset()
        {
            ObjectsToReset.ForEach(obj  => 
            {
                var pipelineController = obj.GetComponent<BasePipeline>();

                if (pipelineController is null)
                    return;
                
                pipelineController.Reset();
            });
        }

        public override void Reset()
        {
        }
    }
}