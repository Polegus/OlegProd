using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject[] _bonus;
    // Start is called before the first frame update
    void Start()
    {
        /*if (PlayerResurs.lvlNow < 5)
            Instantiate(_bonus[Random.Range(0, 4)], transform.position, Quaternion.identity);
        else if (PlayerResurs.lvlNow >= 5 && PlayerResurs.lvlNow < 10)
            Instantiate(_bonus[Random.Range(0, 8)], transform.position, Quaternion.identity);
        else if (PlayerResurs.lvlNow >= 10 && PlayerResurs.lvlNow < 15)
            Instantiate(_bonus[Random.Range(0, 11)], transform.position, Quaternion.identity);
        else if (PlayerResurs.lvlNow >= 15 && PlayerResurs.lvlNow < 20)
            Instantiate(_bonus[Random.Range(0, 19)], transform.position, Quaternion.identity);
        else*/
        Instantiate(_bonus[Random.Range(0, _bonus.Length)], transform.position, Quaternion.identity);

    }
}
