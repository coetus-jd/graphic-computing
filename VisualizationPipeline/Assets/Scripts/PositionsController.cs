using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VisualizationPipeline.Assets.Scripts
{
    public class PositionsController : BasePipeline
    {
        [SerializeField] private TMP_InputField X;
        [SerializeField] private TMP_InputField Y;
        [SerializeField] private TMP_InputField Z;

        private (float Min, float Max) RangeX = (-4, 4);
        private (float Min, float Max) RangeY = (-4, 5);
        private (float Min, float Max) RangeZ = (-3, 7);

        public void ChangeObjectPosition()
        {
            HandleUserInput();

            var x = float.Parse(string.IsNullOrEmpty(X.text) ? "0" : X.text);
            var y = float.Parse(string.IsNullOrEmpty(Y.text) ? "0" : Y.text);
            var z = float.Parse(string.IsNullOrEmpty(Z.text) ? "0" : Z.text);

            ObjectInPipeline.transform.position = new Vector3(x, y, z);
        }

        public override void Reset()
        {
            X.text = "";
            Y.text = "";
            Z.text = "";
        }

        private void HandleUserInput()
        {
            var x = float.Parse(string.IsNullOrEmpty(X.text) ? "0" : X.text);
            var y = float.Parse(string.IsNullOrEmpty(Y.text) ? "0" : Y.text);
            var z = float.Parse(string.IsNullOrEmpty(Z.text) ? "0" : Z.text);

            if (x < RangeX.Min) 
                X.text = RangeX.Min.ToString();
            
            if (x > RangeX.Max) 
                X.text = RangeX.Max.ToString();

            if (y < RangeY.Min) 
                Y.text = RangeY.Min.ToString();
            
            if (y > RangeY.Max) 
                Y.text = RangeY.Max.ToString();

            if (z < RangeZ.Min) 
                Z.text = RangeZ.Min.ToString();
            
            if (z > RangeZ.Max) 
                Z.text = RangeZ.Max.ToString();
        }
    }
}