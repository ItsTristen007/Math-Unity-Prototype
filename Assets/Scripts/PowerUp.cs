using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PowerUp : MonoBehaviour
{

    private int spot;

    public Sprite cookie, gummybear, licorice, donut, lollipop, mushroom;
    
    public void Activate()
    {
        switch (name)
        {
            case "cookie":
                this.GetComponent<SpriteRenderer>().sprite = cookie;
                break;
            case "gummybear":
                this.GetComponent<SpriteRenderer>().sprite = gummybear;
                break;
            case "licorice":
                this.GetComponent<SpriteRenderer>().sprite = licorice;
                break;
            case "donut":
                this.GetComponent<SpriteRenderer>().sprite = donut;
                break;
            case "lollipop":
                this.GetComponent<SpriteRenderer>().sprite = lollipop;
                break;
            case "mushroom":
                this.GetComponent<SpriteRenderer>().sprite = mushroom;
                break;
        }
    }

    private void Update()
    {
        gameObject.transform.position = new Vector3(GameObject.FindWithTag("Player").transform.position.x,
            GameObject.FindWithTag("Player").transform.position.y+(.25f+spot*3f/4f), -1);
    }

    public void SetSpot(int spot)
    {
        this.spot = spot;
    }
}
