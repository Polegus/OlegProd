
using UnityEngine;

public class Golds : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        
        Destroy(gameObject);
    }
   
}
