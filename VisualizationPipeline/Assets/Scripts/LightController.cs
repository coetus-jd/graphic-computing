using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VisualizationPipeline.Assets.Scripts.Enums;

namespace VisualizationPipeline.Assets.Scripts
{
    public class LightController : BasePipeline
    {
        [SerializeField] private Light Light;
        [SerializeField] private TMP_InputField HexColor;
        [SerializeField] private TMP_InputField Intensity;

        public void ChangeLightSettings()
        {
            Light.intensity = float.Parse(
                string.IsNullOrEmpty(Intensity.text) ? "1" : Intensity.text
            );

            var color = new Color();
            ColorUtility.TryParseHtmlString(
                string.IsNullOrEmpty(HexColor.text) ? "#f00" : HandleHexColor(HexColor.text),
                out color
            );

            Light.color = color;
        }

        private string HandleHexColor(string hexColor) => 
            hexColor.StartsWith("#")
                ? hexColor
                : $"#{hexColor}";
    }
}