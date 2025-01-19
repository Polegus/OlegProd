using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCubes : MonoBehaviour
{
    public float HealfCube;
    void Awake()
    {
        HealfCube = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
