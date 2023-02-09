using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Boom : MonoBehaviour
{
    private float time;
    [SerializeField] private int power;
    [SerializeField] private float timer;
    void Start()
    {
        time = Time.time;
    }

    void Update()
    {
        if (Time.time - this.time > this.timer)
            Destroy(this.gameObject);
        else{
            this.transform.localScale += Vector3.one;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>())
        {
            collision.GetComponent<Rigidbody2D>().AddForce(power*(collision.gameObject.transform.position - this.transform.position).normalized, ForceMode2D.Impulse);
        }
    }
}
