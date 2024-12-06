using System.Text.RegularExpressions;
using UnityEngine;

public class ChangeWheel : MonoBehaviour
{
    [SerializeField] GameObject[] _wheels;
    [SerializeField] GameObject[] _lights;
    [SerializeField] Material[] _colorsCar;
    MeshRenderer _colorCar;
    public int carNow;
    // Start is called before the first frame update
    void Start()
    {
        StartState();
    }

    public void StartState()
    {
        carNow = (int)((PlayerResurs.SpeedUp - 22) / 2);
        if (carNow >= 35)
            carNow = 35;
        _colorCar = gameObject.transform.Find("AllCars").Find(Regex.Replace(carNow.ToString(), @"[^\d]", "")).Find("Body").GetComponent<MeshRenderer>();
        _colorCar.material = _colorsCar[PlayerResurs.ColorCarChoise[carNow]];
        WheelNow();
        for (int i = 0; i < _lights.Length; i++)
        {
            if (PlayerResurs.CarLightChoise[carNow] == i)
                _lights[i].SetActive(true);
            else
                _lights[i].SetActive(false);
        }


    }
    public void NextWheel()
    {
        if (PlayerResurs.WheelNow < _wheels.Length - 1)
        {
            PlayerResurs.WheelNow++;
        }
        else
            PlayerResurs.WheelNow = 0;
        for (int i = 0; i < _wheels.Length; i++)
        {
            if (PlayerResurs.WheelNow == i)
                _wheels[i].SetActive(true);
            else
                _wheels[i].SetActive(false);
        }
    }

    public void PrevWheel()
    {
        if (PlayerResurs.WheelNow > 0)
        {
            PlayerResurs.WheelNow--;
        }
        else
        {
            PlayerResurs.WheelNow = _wheels.Length - 1;
        }
        for (int i = 0; i < _wheels.Length; i++)
            {
                if (PlayerResurs.WheelNow == i)
                    _wheels[i].SetActive(true);
                else
                    _wheels[i].SetActive(false);
            }
    }

    public void WheelNow()
    {
        for (int i = 0; i < _wheels.Length; i++)
        {
            if (PlayerResurs.CarWheelChoise[carNow] == 0)
            {
                if (PlayerResurs.WheelNow == i)
                    _wheels[i].SetActive(true);
                else
                    _wheels[i].SetActive(false);
            }
            else
            {
                if (PlayerResurs.CarWheelChoise[carNow] == i)
                    _wheels[i].SetActive(true);
                else
                    _wheels[i].SetActive(false);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
