using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float speed;
    [SerializeField]
    float rotateSpeed;
    [SerializeField]
    float attackDelay;

    [SerializeField]
    Transform projectileStart;
    [SerializeField]
    Transform mineStart;

    bool canAttack = true;

    float mineDropDelay = 2f;
    bool canDropMine = true;

    float speedModifier = 0;
    float attackDelayModifier = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!Core.Instance.CanAttack)
        {
            return;
        }

        float xInput = Input.GetAxisRaw("Horizontal") * (speed + speedModifier);
        float yInput = Input.GetAxisRaw("Vertical") * (speed + speedModifier);
        if ((new Vector2(xInput, yInput)).magnitude > 0f)
        {
            Vector3 movement = new Vector3(xInput, 0f, yInput);
            rb.velocity = movement;
        } else
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
        // Direction
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Determine which direction to rotate towards
            Vector3 target = new Vector3(hit.point.x, 1, hit.point.z);
            Vector3 targetDirection = target - transform.position;

            // The step size is equal to speed times frame time.
            float singleStep = rotateSpeed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            // Draw a ray pointing at our target in
            Debug.DrawRay(transform.position, newDirection, Color.red);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
        }

        if (Input.GetMouseButton(0) && canAttack)
        {
            canAttack = false;
            Shoot();
            Invoke("ActivateAttack", attackDelay + attackDelayModifier);
        }
    }

    public void DestroyObject()
    {
        SoundManager.Instance.Play("PlayerDie");
        GameObject PlayerExplode = Instantiate(Resources.Load<GameObject>("Prefabs/Particles/PlayerExplode"));
        PlayerExplode.transform.position = transform.position;
        Destroy(gameObject);
    }

    void Shoot()
    {
        GameObject Projectile;
        if (Core.Instance.Hammer)
        {
            SoundManager.Instance.Play("Hammer");
            Projectile = Instantiate(Resources.Load<GameObject>("Prefabs/Hammer"), projectileStart.position, transform.rotation);
        } else
        {
            SoundManager.Instance.Play("Bullet");
            Projectile = Instantiate(Resources.Load<GameObject>("Prefabs/Bullet"), projectileStart.position, transform.rotation);
        }
        Projectile.GetComponent<Bullet>().Damage = Core.Instance.PlayerDamage;
        if (Core.Instance.SpawnMines && canDropMine)
        {
            SoundManager.Instance.Play("ArmedMine");
            Quaternion rot180degrees = Quaternion.Euler(-transform.rotation.eulerAngles);
            Instantiate(Resources.Load<GameObject>("Prefabs/Mine"), mineStart.position, rot180degrees);
            Invoke("ActivateMine", mineDropDelay);
            canDropMine = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<GroundPad>())
        {
            if (collision.gameObject.GetComponent<GroundPad>().HasColor)
            {
                Renderer colisionRenderer = collision.gameObject.GetComponent<Renderer>();
                Renderer playerRenderer = gameObject.GetComponent<Renderer>();
                playerRenderer.material.SetColor("_Color", colisionRenderer.material.GetColor("_Color"));
                switch ((GroundPad.PadColors) collision.gameObject.GetComponent<GroundPad>().SelectedColor)
                {
                    case GroundPad.PadColors.Green:
                        speedModifier = 4f;
                        break;
                    case GroundPad.PadColors.Blue:
                        attackDelayModifier = -.13f;
                        break;
                    case GroundPad.PadColors.Red:
                        speedModifier = -4f;
                        break;
                    case GroundPad.PadColors.Yellow:
                        attackDelayModifier = .27f;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    void ActivateAttack()
    {
        canAttack = true;
    }
    void ActivateMine()
    {
        canDropMine = true;
    }
}
