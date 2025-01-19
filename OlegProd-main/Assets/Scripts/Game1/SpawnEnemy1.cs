using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy1 : MonoBehaviour
{
    [SerializeField] GameObject[] _bonus;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerResurs1.lvlNow < 3)
            Instantiate(_bonus[Random.Range(0, 3)], transform.position, Quaternion.identity);
        else if (PlayerResurs1.lvlNow >= 3 && PlayerResurs1.lvlNow < 8)
            Instantiate(_bonus[Random.Range(0, 7)], transform.position, Quaternion.identity);
        else if (PlayerResurs1.lvlNow >= 8 && PlayerResurs1.lvlNow < 12)
            Instantiate(_bonus[Random.Range(0, 10)], transform.position, Quaternion.identity);
        else
            Instantiate(_bonus[Random.Range(0, _bonus.Length)], transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
