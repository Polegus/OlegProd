using UnityEngine;

public class SpawnBonus : MonoBehaviour
{
    [SerializeField] GameObject[] _bonus;
    float _bonusPos;
    GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("Cars");
        ChangeBonus();
        
    }

    private void OnEnable()
    {
        DriveCar.RefreshGates += DestroyGates;
        DriveCar.RefreshGates += ChangeBonus;

    }

    private void OnDisable()
    {
        DriveCar.RefreshGates -= ChangeBonus;
        DriveCar.RefreshGates -= DestroyGates;
    }
    void DestroyGates()
    {
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
    void ChangeBonus()
    {
        if (car.transform.position.z + 10 < gameObject.transform.position.z)
        {
            _bonusPos = Random.Range(-10, 10);
            if (_bonus.Length > 5)
            {
                if (PlayerResurs.lvlNow < 4)
                    Instantiate(_bonus[Random.Range(0, 2)], new Vector3(transform.position.x + _bonusPos / 10, transform.position.y, transform.position.z), Quaternion.identity, transform);
                else if (PlayerResurs.lvlNow >= 4 && PlayerResurs.lvlNow < 7)
                    Instantiate(_bonus[Random.Range(0, 4)], new Vector3(transform.position.x + _bonusPos / 10, transform.position.y, transform.position.z), Quaternion.identity, transform);
                else if (PlayerResurs.lvlNow >= 7 && PlayerResurs.lvlNow < 10)
                    Instantiate(_bonus[Random.Range(0, 6)], new Vector3(transform.position.x + _bonusPos / 10, transform.position.y, transform.position.z), Quaternion.identity, transform);
                else if (PlayerResurs.lvlNow >= 10 && PlayerResurs.lvlNow < 15)
                    Instantiate(_bonus[Random.Range(0, 8)], new Vector3(transform.position.x + _bonusPos / 10, transform.position.y, transform.position.z), Quaternion.identity, transform);
                else
                    Instantiate(_bonus[Random.Range(0, _bonus.Length)], new Vector3(transform.position.x + _bonusPos / 10, transform.position.y, transform.position.z), Quaternion.identity, transform);
            }
            else
                Instantiate(_bonus[Random.Range(0, _bonus.Length)], transform.position, Quaternion.identity, transform);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
