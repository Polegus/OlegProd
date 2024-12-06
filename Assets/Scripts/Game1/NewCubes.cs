using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCubes : MonoBehaviour
{
    [SerializeField] GameObject _nextCubes;
    [SerializeField] GameObject _spawnPos;
    bool _isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Gun"))
            if (_isActive)
            {

                Instantiate(_nextCubes, _spawnPos.transform.position, Quaternion.identity);
                _isActive = false;
                Destroy(_spawnPos);
            }
                
    }
}
