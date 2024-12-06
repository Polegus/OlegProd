using UnityEngine;
using static UnityEngine.ParticleSystem;

public class FireRocket : MonoBehaviour
{
    [SerializeField] ParticleSystem _smoke;
    ParticleSystem _ps;
    DriveCar _driveCar;
    ParticleSystem.MinMaxCurve minMaxCurve;
    float minCurve;
    float maxCurve;
    // Start is called before the first frame update
    void Start()
    {
        _driveCar = GameObject.Find("Cars").GetComponent<DriveCar>();
        _ps = GetComponent<ParticleSystem>();
        var mainModuleSmoke = _smoke.main;
        minCurve = mainModuleSmoke.startSize.constantMin;
        maxCurve = mainModuleSmoke.startSize.constantMax;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mainModule = _ps.main;
                mainModule.startSize = (_driveCar.absoluteSpeed / 50f) + 0.5f;
            
            var mainModuleSmoke = _smoke.main;
            minMaxCurve = new ParticleSystem.MinMaxCurve(minCurve * 2f, maxCurve * 2f);
            mainModuleSmoke.startSize = minMaxCurve;
            minMaxCurve = new ParticleSystem.MinMaxCurve(minCurve / 2f, maxCurve / 2f); 
        }
        if (Input.GetMouseButton(0))
        {
            var mainModule = _ps.main;
                mainModule.startSize = (_driveCar.absoluteSpeed / 50f) + 0.5f;
        }


        if (Input.GetMouseButtonUp(0))
        {
            var mainModule = _ps.main;
                mainModule.startSize = 0.5f;
            var mainModuleSmoke = _smoke.main;
            minMaxCurve = new ParticleSystem.MinMaxCurve(minCurve / 2f, maxCurve / 2f);
            mainModuleSmoke.startSize = minMaxCurve;
            minMaxCurve = new ParticleSystem.MinMaxCurve(minCurve * 2f, maxCurve * 2f);
        }
    }
}
