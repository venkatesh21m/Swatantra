using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Swatantra.Helpers
{
    public class DebugHelper
    {
        public static TextMesh CreateWorldText(string text, Color color, 
            Vector3 localpos = default(Vector3), 
            int fontsize = 4, 
            TextAnchor textAnchor = TextAnchor.MiddleCenter, 
            TextAlignment textAlignment = TextAlignment.Center)
        {
            if (color == null) color = Color.white;

            GameObject gameObject = new GameObject("World_text", typeof(TextMesh));
            gameObject.transform.localPosition = localpos;

            TextMesh textMesh = gameObject.GetComponent<TextMesh>();
            textMesh.anchor = textAnchor;
            textMesh.alignment = textAlignment;
            textMesh.text = text;
            textMesh.fontSize = fontsize;
            textMesh.color = color;
            return textMesh;
        }

    }
}
