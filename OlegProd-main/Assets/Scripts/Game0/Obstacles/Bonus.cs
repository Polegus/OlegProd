using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] GameObject _effectTouch;
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(_effectTouch, gameObject.transform.position, Quaternion.identity);
        
        Destroy(gameObject);
    }
}
