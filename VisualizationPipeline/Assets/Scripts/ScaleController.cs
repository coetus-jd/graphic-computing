using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VisualizationPipeline.Assets.Scripts.Enums;

namespace VisualizationPipeline.Assets.Scripts
{
    public class ScaleController : BasePipeline
    {
        [SerializeField] private Slider Slider;

        private (float Min, float Max) Range = (1, 5);

        public void ChangeObjectScale()
        {
            var scale = Slider.value * Range.Max;

            if (scale == 0)
                scale = Range.Min;

            ObjectInPipeline.transform.localScale = new Vector3(1, 1, 1) * scale;
        }

        public override void Reset()
        {
            Slider.value = 0f;
        }
    }
}