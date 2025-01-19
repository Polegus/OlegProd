using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailManager : MonoBehaviour
{
    [SerializeField] TrailRenderer[] _trailRenderers;
    // Start is called before the first frame update

    public void OnTrail()
    {
        for (int i = 0; i < _trailRenderers.Length; i++)
        {
            _trailRenderers[i].emitting = true;
        }
    }

    public void OffTrail()
    {
        for (int i = 0; i < _trailRenderers.Length; i++)
        {
            _trailRenderers[i].emitting = false;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
