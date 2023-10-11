using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IObserver
{
    [SerializeField]
    private float speed;

    private Rigidbody rb;

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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(horizontal * speed / 2, rb.velocity.y, vertical * speed / 2);
    }
}
