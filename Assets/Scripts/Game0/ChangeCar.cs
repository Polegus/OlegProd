using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCar : MonoBehaviour
{
    
    
    [SerializeField] GameObject[] _cars;
    
    private void Start()
    {
        
        ActiveCar();
    }
    public void SpeedTrigger(int value)
    {
        PlayerResurs.SpeedUp += value / 80d;
        if (PlayerResurs.SpeedUp < 22)
        {
            PlayerResurs.SpeedUp = 22;
        }
        ActiveCar();
    }

    void ActiveCar()
    {
        for (int i = 0; i < _cars.Length; i++)
        {
            if (Math.Truncate(PlayerResurs.SpeedUp/2) - 11 < _cars.Length)
            {
                if (Math.Truncate(PlayerResurs.SpeedUp/2) - 11 == i)
                    _cars[i].SetActive(true);
                else
                    _cars[i].SetActive(false);
            }
            else
            {
                if (i == _cars.Length - 1)
                    _cars[i].SetActive(true);
                else
                    _cars[i].SetActive(false);
            }

        }
    }
}
