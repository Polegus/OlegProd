using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCameraCar : MonoBehaviour
{
    [SerializeField] GameObject _car;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
            transform.position = new Vector3(_car.transform.position.x, _car.transform.position.y, _car.transform.position.z);
        
    }
}
