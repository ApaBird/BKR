using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelZone : MonoBehaviour
{
    private GameObject target;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Component>())
            target = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        target = null;
    }


    private void Update()
    {
        if (target != null && target.GetComponent<Control>().GetSelect())
        {
            Destroy(target);
            target = null;
        }
    }
}
