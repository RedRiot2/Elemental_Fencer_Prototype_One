using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.8f);
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        GameControl.targetsHit += 1;
        Destroy(gameObject);
    }
}
