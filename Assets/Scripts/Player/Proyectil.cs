using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour, IObserver
{
    public float rate;
    [SerializeField]
    public float velocidad;
    private float FireTime = 0f;
    public Transform posGun;
    public float force;
    public float defaultDistance;
    public GameObject bala;

    void Start()
    {
        GameManager.Instance.Attach(this);
    }
    public void Execute(ISubject subject)
    {
        if (subject is GameManager)
        {
            velocidad = ((GameManager)subject).Progression * 2;
        }
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Vector3 targetPoint;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, rate))
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "Player")
                {
                    return;
                }
                else
                {
                    targetPoint = hit.point;
                }

            }
            else
            {
                targetPoint = ray.GetPoint(defaultDistance);
            }

            GameObject bullet = Instantiate(bala, posGun.position, posGun.rotation) as GameObject;
            Rigidbody bulletrb = bullet.GetComponent<Rigidbody>();
            Destroy(bullet, 0.5f);

            if (bulletrb != null)
            {
                Vector3 direction = (targetPoint - posGun.position).normalized;
                bulletrb.velocity = direction * velocidad;
            }

            FireTime = Time.time + rate;

        }

    }
}