using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomTheme : MonoBehaviour
{
    [SerializeField]
    GameObject Canvas;

    [SerializeField]
    TMP_Text ThemeText;

    [SerializeField]
    GameObject[] Panels;

    int NumberTimesCalled = 0;

    enum Theme { 
        Unstable,
        Replication,
        MakingConnections,
        Decay,
        Delivery,
        OneTool,
        DelayInevitable,
        KeepYourDistance,
        TheEnvironmentChangesYou,
        LeaveSomethingBehind,
        EverythingChangesAtNight,
        COUNT
    };

    Theme currentTheme;

    public static RandomTheme Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }

    public void ChangeTheme(float Duration)
    {
        if (NumberTimesCalled == 0)
        {
            // 3 Rules
            ThemeText.text = Translate.Instance.Go("3 Rules: 1) Do / 2) Not / 3) Die");
            NumberTimesCalled++;
        } else
        {
            currentTheme = (Theme) Random.Range(0, (int) Theme.COUNT);
            switch (currentTheme)
            {
                case Theme.Unstable:
                    // SHAKE THE CAMERA FOR (Duration)
                    ThemeText.text = Translate.Instance.Go("Unstable");
                    Camera.main.GetComponent<CameraShake>().ShakeDuration = Duration;
                    break;
                case Theme.Replication:
                    // SPAWN ANOTHER PLAYER
                    ThemeText.text = Translate.Instance.Go("Summoning / Replication / Strength in numbers / It follows you");
                    Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
                    break;
                case Theme.MakingConnections:
                    // TURN LIGHT OFF AND ACTIVATES PLUG MINIGAME
                    ThemeText.text = Translate.Instance.Go("Making connections / On and Off");
                    GameObject EletricPlugOld = GameObject.FindGameObjectWithTag("EletricPlug");
                    Destroy(EletricPlugOld);
                    GameObject EletricPlug = Instantiate(Resources.Load<GameObject>("Prefabs/EletricPlug"));
                    EletricPlug.transform.SetParent(Canvas.transform, false);
                    Core.Instance.Plug = false;
                    Core.Instance.Switch = false;
                    Core.Instance.CanAttack = false;
                    break;
                case Theme.Decay:
                    // KILLS A PLAYER
                    if (Core.Instance.PlayerCount() > 1)
                    {
                        ThemeText.text = Translate.Instance.Go("Decay");
                        GameObject player = Core.Instance.GetClosestPlayer(Vector3.zero);
                        player.GetComponent<Player>().DestroyObject();
                    } else {
                        ThemeText.text = Translate.Instance.Go("Summoning / Replication / Strength in numbers / It follows you");
                        Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
                    }
                    break;
                case Theme.Delivery:
                    // DELIVERY GUY ENEMY LOL
                    ThemeText.text = Translate.Instance.Go("Delivery");
                    Core.Instance.Delivery = true;
                    break;
                case Theme.OneTool:
                    // SPAWNS CRAZY HAMMERS LOL
                    ThemeText.text = Translate.Instance.Go("One tool, many uses");
                    Core.Instance.Hammer = true;
                    break;
                case Theme.DelayInevitable:
                    // DISABLE DAMAGE AND INCREASE KNOCK BACK FORCE
                    ThemeText.text = Translate.Instance.Go("Delay the inevitable");
                    Core.Instance.PlayerDamage = 0;
                    Core.Instance.KnockBack = true;
                    break;
                case Theme.KeepYourDistance:
                    // MAKES ENEMIES FASTER
                    ThemeText.text = Translate.Instance.Go("Keep your distance");
                    Core.Instance.EnemySpeed *= 2;
                    break;
                case Theme.TheEnvironmentChangesYou:
                    // CHANGE COLORS ON THE GROUND THAT CHANGE SOMETHING IN THE GAME
                    ThemeText.text = Translate.Instance.Go("The environment changes you");
                    foreach (GameObject Panel in Panels)
                    {
                        Panel.GetComponent<GroundPad>().ChangeColor();
                    }
                    break;
                case Theme.LeaveSomethingBehind:
                    // EVERY SHOOT SPAWNS MINES IN GROUND
                    ThemeText.text = Translate.Instance.Go("Leave something behind");
                    Core.Instance.SpawnMines = true;
                    Core.Instance.EnemySpeed /= 2;
                    break;
                case Theme.EverythingChangesAtNight:
                    // CHANGES THE GAME LANGUAGE
                    ThemeText.text = Translate.Instance.Go("Everything changes at night");
                    Core.Instance.Sun.intensity = 0.25f;
                    Translate.Instance.ChangeLanguage();
                    break;
            }
            Invoke("Cooldown", Duration);
        }
    }

    void Cooldown()
    {
        switch (currentTheme)
        {
            case Theme.Unstable:
            case Theme.Replication:
            case Theme.Decay:
                // DO NOTHING
                break;
            case Theme.OneTool:
                Core.Instance.Hammer = false;
                break;
            case Theme.Delivery:
                Core.Instance.Delivery = false;
                break;
            case Theme.LeaveSomethingBehind:
                Core.Instance.SpawnMines = false;
                Core.Instance.EnemySpeed *= 2;
                break;
            case Theme.MakingConnections:
                Core.Instance.CanAttack = true;
                break;
            case Theme.TheEnvironmentChangesYou:
                // REVERT THE PADS
                RevertPads();
                break;
            case Theme.DelayInevitable:
                // ENABLE DAMAGE AND REVERT THE KNOCK BACK FORCE
                Core.Instance.PlayerDamage = 1;
                Core.Instance.KnockBack = false;
                break;
            case Theme.KeepYourDistance:
                // MAKES ENEMIES FASTER
                Core.Instance.EnemySpeed /= 2;
                break;
            case Theme.EverythingChangesAtNight:
                // MAKE DAY APPEAR
                Core.Instance.Sun.intensity = 1;
                break;
        }
    }

    public void RevertPads()
    {
        foreach (GameObject Panel in Panels)
        {
            Panel.GetComponent<GroundPad>().OriginalColor();
        }
    }

    public void ResetData()
    {
        NumberTimesCalled = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
