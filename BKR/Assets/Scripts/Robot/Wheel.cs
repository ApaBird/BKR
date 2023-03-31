using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : RobotComponent
{
    [SerializeField] private List<string> listParams;
    Rigidbody2D rigidbody;

    [SerializeField] private float speed = 0;
    public float Speed { 
        get { return speed; } 
        set
        {
            if (value < 10 && value > -10)
            {
                speed = value;
            }
            else if (value > 0)
            {
                speed = 10;
            }
            else
            {
                speed = -10;
            }
        }
    }

    private void Start()
    {
        foreach(string param in listParams)
        {
            base.dictValues.Add(param, Speed);
        }
        rigidbody = GetComponentInParent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        float radian = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 direct = new Vector2(-Mathf.Sin(radian), Mathf.Cos(radian));
        Debug.DrawLine(transform.position, new Vector3(direct.x, direct.y ,0) + transform.position, Color.red);//Отрисовка линий
        rigidbody.AddForceAtPosition(direct * speed, this.transform.position, ForceMode2D.Force);
    }

    public override List<string> GetListKey()
    {
        return listParams;
    }
}
