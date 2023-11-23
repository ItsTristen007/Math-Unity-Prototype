using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Blocks : MonoBehaviour
{

    private bool translate, rotate, scale, revSpeed, revRot, shoot, once = false;
    private int dir = 1;
    public void alter(string power)
    {
        switch (power)
        {
            case "cookie":
                translate = !translate;
                break;
            case "gummybear":
                revSpeed = !revSpeed;
                break;
            case "licorice":
                shoot = !shoot;
                break;
            case "donut":
                rotate = !rotate;
                break;
            case "lollipop":
                revRot = !revRot;
                break;
            case "mushroom":
                scale = !scale;
                break;
        }
    }

    private void Update()
    {
        if (translate)
        {
            transform.position = new Vector3(transform.position.x+(dir*.005f),transform.position.y,0);
        }
        if (rotate)
        {
            transform.Rotate(new Vector3(0,0,1));
        }
        if (scale)
        {
            if (gameObject.transform.localScale.x < 2)
            {
                transform.localScale += new Vector3(0.001f,0.001f,0.001f);
            }
        }
        if (revSpeed)
        {
            if (!once)
            {
                dir = dir * -1;
                once = true;
            }
        }
        else if (!revSpeed) once = false;
        if (revRot)
        {
            transform.Rotate(new Vector3(0,0,-2));
        }
        if (shoot)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + .03f, 0);
            transform.position = new Vector3(transform.position.x + .03f, transform.position.y, 0);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        dir = dir * -1;
    }
}
