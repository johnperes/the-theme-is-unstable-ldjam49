using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    GameObject Intro1;
    [SerializeField]
    GameObject Intro2;
    [SerializeField]
    GameObject Intro3;
    [SerializeField]
    GameObject IntroThemeLeft;
    [SerializeField]
    GameObject IntroThemeRight;

    int Step = 0;

    string[] Themes = {
        "3 Rules",
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
        "It follows you"
       };

    // Start is called before the first frame update
    void Start()
    {
        Manager();
    }

    void Manager()
    {
        if (Step == 0)
        {
            Instantiate(Intro1);
            Step++;
            Invoke("Manager", 3.5f);
        }
        else if (Step == 1)
        {
            Step++;
            InvokeRepeating("ThemesLeft", 0f, 2f);
            InvokeRepeating("ThemesRight", 1f, 2f);
            Invoke("Manager", 3.5f);
        }
        else if (Step == 2)
        {
            Instantiate(Intro2);
            Step++;
            Invoke("Manager", 3.5f);
        } else
        {
            Instantiate(Intro3);
            Step++;
            Invoke("Manager", 3.5f);
        }
    }

    void ThemesLeft()
    {
        IntroThemeLeft.GetComponentInChildren<TMP_Text>().text = Themes[Random.Range(0, Themes.Length)];
        Instantiate(IntroThemeLeft);
    }
    void ThemesRight()
    {
        IntroThemeRight.GetComponentInChildren<TMP_Text>().text = Themes[Random.Range(0, Themes.Length)];
        Instantiate(IntroThemeRight);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
