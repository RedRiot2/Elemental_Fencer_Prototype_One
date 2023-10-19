using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SocialPlatforms.Impl;

public class Target2 : MonoBehaviour
{

    public static int hitpoints = 4;
    public static int currentHitPoints;
    void Start()
    {
        currentHitPoints = hitpoints;
        Destroy(gameObject, 8f);
    }

    public void RushDelete()
    {

        if (currentHitPoints <= 0)
        {

            GameControl.targetsHit += 3;
            Destroy(gameObject);

        }
        else
        {
            Debug.Log(currentHitPoints);
            return;
        }


    }

}
