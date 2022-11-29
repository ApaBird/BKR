using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    [SerializeField] private float borderSize = 0.1f;
    [SerializeField] private GameObject outlineObject;
    private Dictionary<string, Color> colors = new Dictionary<string, Color>();
    private SpriteRenderer render;

    private void Start() {
        render = outlineObject.GetComponent<SpriteRenderer>();
        render.size = this.GetComponent<SpriteRenderer>().size + new Vector2(borderSize, borderSize); 
    }

    public void OutlineOn() => render.enabled = true;

    public void OutlineOff() => render.enabled = false;

    public void SetColor(string name_color) => render.color = colors[name_color];

    public void AddColor(string name_color, Color color)
    {
        colors.Add(name_color, color);
    }
}
