using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour
{
    [SerializeField] int _speed;
    Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(new Vector3(0, 0, _speed*100));
        Destroy(gameObject, ParamGuns.Distance/200f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.name.Contains("Coin") && !other.gameObject.name.Contains("Gun"))
            Destroy(gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
