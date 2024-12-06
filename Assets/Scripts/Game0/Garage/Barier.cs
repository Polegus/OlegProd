using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barier : MonoBehaviour
{
    [SerializeField] int _lvlBlock;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerResurs.lvlNow >= _lvlBlock)
        {
            Destroy(gameObject);    
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
