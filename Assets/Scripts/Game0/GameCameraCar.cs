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
        if (_car.name == "Cars")
            transform.position = new Vector3(_car.transform.position.x, _car.transform.position.y, _car.transform.position.z);
        if (_car.name == "Player")
            transform.position = new Vector3(_car.transform.position.x, transform.position.y, _car.transform.position.z);
    }
}
