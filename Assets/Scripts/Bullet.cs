using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float Speed;

    public int Damage;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("AutoDestroy", 2f);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.forward * Speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (Core.Instance.KnockBack)
            {
                SoundManager.Instance.Play("KnockBack");
                Vector3 contactPoint = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
                other.GetComponent<Rigidbody>().AddForceAtPosition(transform.forward.normalized * 9000f, contactPoint);
            } else
            {
                other.gameObject.GetComponent<Enemy>().DestroyObject();
                Core.Instance.AddScore();
            }
            AutoDestroy();
        }
    }

    void AutoDestroy()
    {
        Destroy(gameObject);
    }
}
