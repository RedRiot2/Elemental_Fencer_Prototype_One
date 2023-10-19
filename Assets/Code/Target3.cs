using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target3 : MonoBehaviour
{
    //public GameControl SpawnTargets2(); //what?
    public GameObject game_area;

    public float speed;

    void Start()
    {
        Destroy(gameObject, 5f);
    }


    void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(1))
        {

            //how to make it reflect off of when you parry

        }
    }

}
