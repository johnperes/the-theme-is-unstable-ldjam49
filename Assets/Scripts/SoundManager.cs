using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource aSource;

    [SerializeField]
    AudioClip ArmedMine;
    [SerializeField]
    AudioClip Bullet;
    [SerializeField]
    AudioClip Enemy;
    [SerializeField]
    AudioClip Hammer;
    [SerializeField]
    AudioClip Explosion;
    [SerializeField]
    AudioClip PlayerDie;
    [SerializeField]
    AudioClip ChangeTheme;
    [SerializeField]
    AudioClip Switch;
    [SerializeField]
    AudioClip KnockBack;


    public static SoundManager Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }

    public void Play(string song)
    {
        switch (song)
        {
            case "ArmedMine":
                aSource.PlayOneShot(ArmedMine);
                break;
            case "Bullet":
                aSource.PlayOneShot(Bullet);
                break;
            case "Enemy":
                aSource.PlayOneShot(Enemy);
                break;
            case "Hammer":
                aSource.PlayOneShot(Hammer);
                break;
            case "Explosion":
                aSource.PlayOneShot(Explosion);
                break;
            case "PlayerDie":
                aSource.PlayOneShot(PlayerDie);
                break;
            case "ChangeTheme":
                aSource.PlayOneShot(ChangeTheme);
                break;
            case "Switch":
                aSource.PlayOneShot(Switch);
                break;
            case "KnockBack":
                aSource.PlayOneShot(KnockBack);
                break;
        }
    }
}
