using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBonus1 : MonoBehaviour
{
    [SerializeField] GameObject[] _bonus;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerResurs1.lvlNow < 3)
            Instantiate(_bonus[Random.Range(0, 1)], transform.position, Quaternion.identity);
        else if (PlayerResurs1.lvlNow >= 3 && PlayerResurs1.lvlNow < 6)
            Instantiate(_bonus[Random.Range(0, 2)], transform.position, Quaternion.identity);
        else if (PlayerResurs1.lvlNow >= 6 && PlayerResurs1.lvlNow < 10)
            Instantiate(_bonus[Random.Range(0, 4)], transform.position, Quaternion.identity);
        else if (PlayerResurs1.lvlNow >= 10 && PlayerResurs1.lvlNow < 14)
            Instantiate(_bonus[Random.Range(0, 8)], transform.position, Quaternion.identity);
        else if (PlayerResurs1.lvlNow >= 14 && PlayerResurs1.lvlNow < 18)
            Instantiate(_bonus[Random.Range(0, 12)], transform.position, Quaternion.identity);
        else
            Instantiate(_bonus[Random.Range(0, _bonus.Length)], transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
