using UnityEngine;

public class DriveTank : MonoBehaviour
{
    [SerializeField] Transform _turrel;
    [SerializeField] float _speedForward = 10f;
    Rigidbody _rb;

    float _oldMousePositionX;
    float _eulerY;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Drive();
    }
    void FixedUpdate()
    {
        _rb.AddForce(transform.forward * _speedForward);
    }



    void Drive()
    {


        if (Input.GetMouseButtonDown(0))
            _oldMousePositionX = Input.mousePosition.x;

        if (Input.GetMouseButton(0))
        {
            float deltaX = Input.mousePosition.x - _oldMousePositionX;
            _oldMousePositionX = Input.mousePosition.x;

            _eulerY += deltaX * 0.15f;
            _eulerY = Mathf.Clamp(_eulerY, -38, 38);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, _eulerY, transform.eulerAngles.z);
            _turrel.eulerAngles = new Vector3(_turrel.eulerAngles.x, 0f, _turrel.eulerAngles.z);
        }


    }


}
