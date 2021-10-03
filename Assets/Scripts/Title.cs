using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    int Index = 0;
    [SerializeField]
    TMP_Text ThemeLabel;

    string[] Themes = {
        "Unstable",
        "Making connections",
        "One tool, many uses",
        "Decay",
        "On / Off",
        "Delay the inevitable",
        "Keep your distance",
        "Delivery",
        "The environment changes you",
        "Leave something behind",
        "Everything changes at night",
        "3 rules",
        "Replication",
        "Strength in numbers",
        "Summoning",
        "It follows you",
        "Unstable"
       };
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Animate", 0f);
    }

    // Update is called once per frame
    void Animate()
    {
        if (Index < Themes.Length)
        {
            ThemeLabel.text = Themes[Index];
            Index++;
            Invoke("Animate", 0.15f);
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
}
