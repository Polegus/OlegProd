using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBonusPos : MonoBehaviour
{
    [SerializeField] GameObject[] _positions;
    int _numBonus;
    // Start is called before the first frame update
    void Start()
    {
        _numBonus = Random.Range(0, 10);
        if (_numBonus < 8)
            for (int i = 0; i < _positions.Length; i++)
            {
                if (i<2)
                    _positions[i].SetActive(true);
                else 
                    _positions[i].SetActive(false);
            }
        else if (_numBonus == 8)
        {
            for (int i = 0; i < _positions.Length; i++)
            {
                if (i ==2)
                    _positions[i].SetActive(true);
                else
                    _positions[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < _positions.Length; i++)
            {
                if (i == 3)
                    _positions[i].SetActive(true);
                else
                    _positions[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
