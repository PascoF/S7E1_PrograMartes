using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour, IObserver
{
    [SerializeField]
    private float bulletImpulse;
    public Transform player;
    public float range = 100f;
    private bool onRange = false;
    public Rigidbody projectile;

    void Start()
    {
        GameManager.Instance.Attach(this);

        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
    }

    void Shoot()
    {
        if (onRange)
        {

            Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward * bulletImpulse, ForceMode.Impulse);

            Destroy(bullet.gameObject, 2);
        }
    }

    public void Execute(ISubject subject)
    {
        if (subject is GameManager)
        {
            bulletImpulse = ((GameManager)subject).Progression;
        }
    }

    void Update()
    {
        onRange = Vector3.Distance(transform.position, player.position) < range;
        if (onRange)
            transform.LookAt(player);
    }
}
