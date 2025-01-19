using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenZone : MonoBehaviour
{
    [SerializeField] GameObject _zone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Turrel"))
        {
            _zone.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
