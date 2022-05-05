using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VisualizationPipeline.Assets.Scripts.Enums;

namespace VisualizationPipeline.Assets.Scripts
{
    public class RotationController : BasePipeline
    {
        [SerializeField] private Slider Slider;
        [SerializeField] private TMP_Dropdown SpaceSelect;

        private (float Min, float Max) Range = (0, 360);

        public void ChangeObjectRotation()
        {
            var rotation = Slider.value * Range.Max;

            var relativeTo = SpaceSelect.value == (int)Spaces.Self
                ? Space.Self
                : Space.World;

            ObjectInPipeline.transform.Rotate(
                new Vector3(0, rotation, 0) * Time.deltaTime,
                relativeTo
            );
        }
    }
}