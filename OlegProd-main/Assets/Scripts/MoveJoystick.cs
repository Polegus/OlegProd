using UnityEngine;

public class MoveJoystick : MonoBehaviour
{

    [SerializeField] FixedJoystick _joystickFire;
    [SerializeField] float _rotateSpeed;
    [SerializeField] float _maxSpeed;
    [SerializeField] float _speedDelta;
    Rigidbody2D _rigidbody;
    private Vector2 moveVector;
    Vector3 targetDirection;
    float _speed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (_speed < _maxSpeed)
                _speed += _speedDelta * Time.deltaTime;

        }
        if (Input.GetMouseButtonUp(0))
        {
            _speed = _maxSpeed / 10f;
        }
        AnimationScript();
        AimHero();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            _rigidbody.AddForce(transform.up * _speed);
        }




    }

    

    void AnimationScript()
    {
        float AngleForce = Mathf.Atan2(moveVector.y, moveVector.x) * Mathf.Rad2Deg;
        float AngleMove = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        float SumTest = AngleForce - AngleMove;
        if (SumTest < 0) SumTest += 360;


        SumTest = SumTest / 360;

    }

    void AimHero()
    {

        if (_joystickFire.Horizontal != 0 || _joystickFire.Vertical != 0)
        {
            targetDirection = new Vector3(_joystickFire.Horizontal, _joystickFire.Vertical, 0f);
            float AngleMove = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
            if (AngleMove < 0)
                AngleMove += 360f;
            if (transform.eulerAngles.z < 90f && AngleMove > 270)
                transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z - _rotateSpeed * Time.deltaTime);
            else
            {
                if (transform.eulerAngles.z - AngleMove <= 180f)
                {

                    if (transform.eulerAngles.z + 1f < AngleMove)
                        transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + _rotateSpeed * Time.deltaTime);
                    else if (transform.eulerAngles.z - 1f > AngleMove)
                        transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z - _rotateSpeed * Time.deltaTime);


                }
                else
                {
                    if (transform.eulerAngles.z + 1f < AngleMove)
                        transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z - _rotateSpeed * Time.deltaTime);
                    else if (transform.eulerAngles.z - 1f > AngleMove)
                        transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + _rotateSpeed * Time.deltaTime);
                }
            }


        }




    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //     Vector3 targetDirection1 = new Vector3(other.transform.position.x - _spawnFire.transform.position.x, other.transform.position.y - _spawnFire.transform.position.y, other.transform.position.z - _spawnFire.transform.position.z);
            //     Quaternion rotation1 = Quaternion.LookRotation(targetDirection1);
            //     _spawnFire.transform.rotation = Quaternion.Lerp(_spawnFire.transform.rotation, rotation1, _moveSpeed * Time.deltaTime);




            /* if (_aimPlayer)
             {
                 targetDirection = new Vector3(other.transform.position.x - transform.position.x, 0f, other.transform.position.z - transform.position.z);
                 Quaternion rotation = Quaternion.LookRotation(targetDirection);
                 transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _moveSpeed * Time.deltaTime * 100f);
             //    _animator.SetBool("Fire", true);
             }*/

        }
    }
}