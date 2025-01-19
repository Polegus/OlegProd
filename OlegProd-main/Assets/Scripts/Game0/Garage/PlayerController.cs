using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject _joystick;
    [SerializeField] GameObject _soundWalk;
    private Rigidbody rb;
    public float Speed = 5f;
    private Vector3 moveVector;
    Vector3 _joysticVector;
    Animator _animator;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (DynamicJoystick.JoyActive)
        {
            _joysticVector = new Vector3(_joystick.transform.localPosition.y, 0, -_joystick.transform.localPosition.x);
            rb.MovePosition(rb.position + _joysticVector / 15 * Time.fixedDeltaTime);
            transform.rotation = Quaternion.LookRotation(_joysticVector);
            _animator.SetBool("Run", true);
            _soundWalk.SetActive(true);
        }
        else
        {
            moveVector.z = -Input.GetAxis("Horizontal");
            moveVector.x = Input.GetAxis("Vertical");
            rb.MovePosition(rb.position + moveVector * Speed * Time.fixedDeltaTime);
            if (moveVector != new Vector3(0, 0, 0))
            {
                transform.rotation = Quaternion.LookRotation(moveVector);
                _animator.SetBool("Run", true);
                _soundWalk.SetActive(true);
            }

        }
        if (!DynamicJoystick.JoyActive && moveVector == new Vector3(0, 0, 0))
        {
            _animator.SetBool("Run", false);
            _soundWalk.SetActive(false);
        }
            
    }
}
