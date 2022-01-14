using TMPro;
using UnityEngine;

namespace GI.UnityToolkit.Events
{
    public class TextEffectSource : VFXSource
    {
        [SerializeField] private TMP_Text text = default;

        public void SetText(string effectText, Color color)
        {
            text.text = effectText;
            text.enableVertexGradient = false;
            text.color = color;
        }

        public void SetText(string effectText, Color topColor, Color bottomColor)
        {
            text.text = effectText;
            text.enableVertexGradient = true;
            text.colorGradient = new VertexGradient(topColor, topColor, bottomColor, bottomColor);
        }
    }
}