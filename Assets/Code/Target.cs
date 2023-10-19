using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }


    public void Delete()
    {

        GameControl.targetsHit += 1;
        Destroy(gameObject);

    }
}
