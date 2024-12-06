using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mishen : MonoBehaviour
{
    [SerializeField] GameObject _reward;
    [SerializeField] GameObject _glavGameObject;
    [SerializeField] GameObject _destroyEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Patron"))
        {
            Instantiate(_reward, _glavGameObject.transform.position, Quaternion.identity);
            Instantiate(_destroyEffect, gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(_glavGameObject);
        }

        if (other.gameObject.name.Contains("Gun"))
        {
            ParamGuns _paramGun = other.GetComponent<ParamGuns>();
            _paramGun.GetDamage(10f);
            Instantiate(_destroyEffect, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
