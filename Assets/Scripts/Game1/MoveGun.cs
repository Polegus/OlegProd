using UnityEngine;

public class MoveGun : MonoBehaviour
{
    [SerializeField] Animator _cameraPos;
    [SerializeField] GameObject _board;
    Rigidbody _rb;
    float _oldMousePositionX;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        _cameraPos.enabled = true;
        _board.SetActive(false);
    }
    private void FixedUpdate()
    {
        _rb.AddForce(transform.forward * 12f);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _oldMousePositionX = Input.mousePosition.x;
        if (Input.GetMouseButton(0))
        {
            float deltaX = Input.mousePosition.x - _oldMousePositionX;
            _oldMousePositionX = Input.mousePosition.x;

            if (transform.position.x < 6.5f && transform.position.x > -6.5f)
            {
                transform.position = new Vector3(transform.position.x + deltaX / 10, transform.position.y, transform.position.z);
            }
            if (transform.position.x >= 6.5f)
                transform.position = new Vector3(6.4999f, transform.position.y, transform.position.z);
            else if (transform.position.x <= -6.5f)
                transform.position = new Vector3(-6.4999f, transform.position.y, transform.position.z);
        }

    }
}
