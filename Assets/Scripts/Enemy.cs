using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player = null;

    void Start()
    {
        InvokeRepeating("GetTarget", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * Core.Instance.EnemySpeed * Time.deltaTime;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().DestroyObject();
        }
    }

    void GetTarget()
    {
        player = Core.Instance.GetClosestPlayer(transform.position);
    }

    public void DestroyObject()
    {
        SoundManager.Instance.Play("Enemy");
        GameObject EnemyExplode = Instantiate(Resources.Load<GameObject>("Prefabs/Particles/EnemyExplode"));
        EnemyExplode.transform.position = transform.position;
        Destroy(gameObject);
    }
}
