using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    [SerializeField]
    GameObject EletricPanel;

    [SerializeField]
    Sprite SwitchOn;

    [SerializeField]
    Image SwitchImage;

    public void Toogle()
    {
        SoundManager.Instance.Play("Switch");
        SwitchImage.sprite = SwitchOn;
        Core.Instance.Switch = true;
        if (Core.Instance.Switch && Core.Instance.Plug)
        {
            Core.Instance.CanAttack = true;
            Destroy(EletricPanel);
        }
    }
}
