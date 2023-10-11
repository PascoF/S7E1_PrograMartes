using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour, IObserver
{
    [SerializeField]
    public UnityEngine.AI.NavMeshAgent enemigo;
    private float speed;
    private Rigidbody rb;
    public Transform player;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        GameManager.Instance.Attach(this);
    }

    public void Execute(ISubject subject)
    {
        if (subject is GameManager)
        {
            speed = ((GameManager)subject).Progression;
        }
    }


    void Update()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, speed/10);
        enemigo.SetDestination(player.position);
    }
}
