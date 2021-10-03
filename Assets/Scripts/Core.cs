using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Core : MonoBehaviour
{
    [SerializeField]
    public Light Sun;

    [SerializeField]
    TMP_Text Score;

    [SerializeField]
    GameObject GameOverMessage;

    float Delay;

    [SerializeField]
    Image EventClock;

    [SerializeField]
    GameObject[] SpawnPoints;

    bool GameOver = false;

    [SerializeField]
    float EventClockDelay;
    float EventClockCurrentTime = 0;

    public float EnemySpeed = 3f;
    public int PlayerDamage = 1;
    public bool Plug = false;
    public bool Switch = false;
    public bool KnockBack = false;
    public bool CanAttack = true;
    public bool SpawnMines = false;
    public bool Hammer = false;
    public bool Delivery = false;
    public int Language = 5;
    int ScoreValue = 0;

    public static Core Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Restart(true);
    }

    public void AddScore()
    {
        ScoreValue++;
        Score.text = ScoreValue.ToString();
    }

    public void Restart(bool FirstTime)
    {
        Delay = 1.5f;
        EnemySpeed = 3f;
        PlayerDamage = 1;
        Plug = false;
        Switch = false;
        KnockBack = false;
        CanAttack = true;
        SpawnMines = false;
        Hammer = false;
        Delivery = false;
        ScoreValue = 0;
        Score.text = ScoreValue.ToString();
        Language = 5;
        EventClockCurrentTime = EventClockDelay;
        Sun.intensity = 1;
        GameOver = false;
        Invoke("SummonEnemy", Delay);
        Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        GameObject[] mines = GameObject.FindGameObjectsWithTag("Mine");
        foreach (GameObject mine in mines)
        {
            Destroy(mine);
        }
        GameOverMessage.SetActive(false);
        if (!FirstTime)
        {
            RandomTheme.Instance.RevertPads();
        }
    }

    public GameObject GetClosestPlayer(Vector3 position)
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject result = null;
        if (players.Length > 0)
        {
            result = players[0];
            float distance = Vector3.Distance(players[0].transform.position, position);
            foreach (GameObject player in players)
            {
                float currentDistance = Vector3.Distance(player.transform.position, position);
                if (currentDistance < distance)
                {
                    result = player;
                }
            }
        }
        return result;
    }

    public int PlayerCount()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        return players.Length;
    }

    void SummonEnemy()
    {
        if (!GameOver)
        {
            int RandomSpawnPoint = Random.Range(0, SpawnPoints.Length);
            if (Delivery)
            {
                GameObject DeliveryGuyEnemy = Instantiate(Resources.Load<GameObject>("Prefabs/DeliveryGuyEnemy"));
                DeliveryGuyEnemy.transform.position = SpawnPoints[RandomSpawnPoint].transform.position;
            } else
            {
                GameObject Enemy = Instantiate(Resources.Load<GameObject>("Prefabs/Enemy"));
                Enemy.transform.position = SpawnPoints[RandomSpawnPoint].transform.position;
            }
            Invoke("SummonEnemy", Delay);
        }
    }

    void Update()
    {
        if (ScoreValue > 200)
        {
            Delay = 0.75f;
        }
        if (PlayerCount() == 0)
        {
            GameOver = true;
            GameOverMessage.SetActive(true);
        }
        if (!GameOver)
        {
            EventClockCurrentTime += Time.deltaTime;
            EventClock.fillAmount = EventClockCurrentTime / EventClockDelay;
            if (EventClockCurrentTime >= EventClockDelay)
            {
                EventClockCurrentTime = 0;
                TriggerEvent();
            }
        }
    }

    void TriggerEvent()
    {
        SoundManager.Instance.Play("ChangeTheme");
        RandomTheme.Instance.ChangeTheme(EventClockDelay - .1f);
    }
}
