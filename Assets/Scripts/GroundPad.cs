using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPad : MonoBehaviour
{
    public bool HasColor = false;
    public int SelectedColor = 0;

    Color Original;

    [SerializeField]
    Color[] ColorList;

    public enum PadColors {
        Green,
        Blue,
        Red,
        Yellow,
        COUNT
    };

    void Start()
    {
        Original = gameObject.GetComponent<Renderer>().material.GetColor("_Color");
    }

    public void OriginalColor()
    {
        HasColor = false;
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Original);
    }

    public void ChangeColor()
    {
        HasColor = true;
        SelectedColor = Random.Range(0, (int) PadColors.COUNT);
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", ColorList[SelectedColor]);
    }
}
