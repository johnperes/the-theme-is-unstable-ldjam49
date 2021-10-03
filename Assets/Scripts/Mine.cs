using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    bool Armed = false;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(rb.position + transform.forward, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && Armed)
        {
            other.gameObject.GetComponent<Enemy>().DestroyObject();
            DestroyObject();
        }
        else if (other.tag == "Player" && Armed)
        {
            other.gameObject.GetComponent<Player>().DestroyObject();
            DestroyObject();
        }
        else if (other.tag == "Ground")
        {
            Armed = true;
        }
    }

    void DestroyObject()
    {
        SoundManager.Instance.Play("Explosion");
        GameObject MineExplode = Instantiate(Resources.Load<GameObject>("Prefabs/Particles/MineExplode"));
        MineExplode.transform.position = transform.position;
        Destroy(gameObject);
    }
}
