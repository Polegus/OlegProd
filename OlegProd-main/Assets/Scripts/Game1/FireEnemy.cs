using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : MonoBehaviour
{
    [SerializeField] GameObject _patron;
    [SerializeField] GameObject _fireEffect;
    [SerializeField] GameObject _spawnPos;
    [SerializeField] float _coolduwn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireGunEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire()
    {
        Instantiate(_patron, _spawnPos.transform.position, _spawnPos.transform.rotation);
        Instantiate(_fireEffect, _spawnPos.transform.position, _spawnPos.transform.rotation);
    }

    
    IEnumerator FireGunEnemy()
    {
        while (ParamGuns.Speed > 0)
        {
            yield return new WaitForSeconds(_coolduwn);
            Fire();

        }
    }
}
