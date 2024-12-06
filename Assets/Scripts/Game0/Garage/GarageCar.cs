using System.Text.RegularExpressions;
using UnityEngine;

public class GarageCar : MonoBehaviour
{
    [SerializeField] public GameObject[] _wheels;
    [SerializeField] GameObject _upgradeCar;
    GameObject _cars;
    int _numCar;
    CapsuleCollider _capsuleCollider;
    // Start is called before the first frame update
    void Start()
    {
        _numCar = (int)(PlayerResurs.SpeedUp - 22) / 2;
        if (_numCar >= 35)
            _numCar = 35;
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _capsuleCollider.enabled = false;
        for (int i = 0; i <= _numCar; i++)
        {
            if (int.Parse(Regex.Match(gameObject.name, @"\d+").Value) == i)
            {
                _capsuleCollider.enabled = true;
                _cars = transform.Find("Cars").Find(Regex.Replace(gameObject.name, @"[^\d]", "")).gameObject;
                _cars.SetActive(true);
                _upgradeCar.SetActive(true);
                if (PlayerResurs.CarWheelChoise[_numCar] == 0)
                {
                    for (int j = 0; j < _wheels.Length; j++)
                    {
                        if (PlayerResurs.WheelChoise == j)
                            _wheels[j].SetActive(true);
                        else
                            _wheels[j].SetActive(false);
                    }
                }
                else
                {
                    for (int j = 0; j < _wheels.Length; j++)
                    {
                        if (PlayerResurs.CarWheelChoise[_numCar] == j)
                            _wheels[j].SetActive(true);
                        else
                            _wheels[j].SetActive(false);
                    }
                }

            }

        }
    }

    /* void StateCar()
     {
         if (PlayerResurs.GarageCar.ContainsKey(Regex.Match(gameObject.name, @"\d+").Value) == false)
             gameObject.SetActive(false);
         else
             for (int i = 0; i < _wheels.Length; i++)
             {
                 if (int.Parse(PlayerResurs.GarageCar[Regex.Match(gameObject.name, @"\d+").Value]) == i)
                     _wheels[i].SetActive(true);
                 else
                     _wheels[i].SetActive(false);
             }
     }*/
    void StateCar1()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
