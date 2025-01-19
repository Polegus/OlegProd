using UnityEngine;

public class ControllerMy : MonoBehaviour
{
    [SerializeField] float _maxSpeed;
    [SerializeField] float _speedRight;
    [SerializeField] float _speedRotate;
    [SerializeField] float _speedDelta;
    Transform camera;
    Rigidbody rb;
    float speed;
    float speedRight;
    float oldMousePositionX;
    float eulerY;
    bool ruleRoket;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera = GameObject.Find("Camera").GetComponent<Transform>();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonUp(0))
        {
            speed = _maxSpeed / 10f;
            ruleRoket = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            oldMousePositionX = Input.mousePosition.x;
            ruleRoket = true;
            if (rb.velocity.z < 0.2f || rb.velocity.z > -0.2f)
                rb.velocity = new Vector3(0,0,0);
            if (transform.eulerAngles.y < 360f && transform.eulerAngles.y > 180f)
                eulerY = transform.eulerAngles.y - 360f;
        }

        if (Input.GetMouseButton(0))
        {
            /* float deltaX = Input.mousePosition.x - _oldMousePositionX;
             _oldMousePositionX = Input.mousePosition.x;
             _eulerY += deltaX * 0.15f;
             _eulerY = Mathf.Clamp(_eulerY, -38, 38);
             transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _eulerY); */
            if (speed < _maxSpeed)
            {
                speed += _speedDelta * Time.deltaTime;
            }
            float deltaX = Input.mousePosition.x - oldMousePositionX;

            eulerY -= deltaX * _speedRotate*0.01f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, eulerY, transform.eulerAngles.z);
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {


        if (Input.GetMouseButton(0))
        {
            rb.AddForce(transform.forward * speed);
        }

    }
}
