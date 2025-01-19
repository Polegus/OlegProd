using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DriveCar : MonoBehaviour
{
    ChangeCar changeCar;
    [SerializeField] float _maxSpeed;
    [SerializeField] GameObject _finishWindow;
    [SerializeField] Text _bonusFinish;
    [SerializeField] Text _finishGold;
    [SerializeField] Text _goldForLvl;
    [SerializeField] float _dragFly = 1f;

    public AudioClip[] _sounds;
    public AudioSource _audioSource;
    Animator animator;
    Vector3 moveVector;
    Rigidbody rb;
    float _oldMousePositionX;
    float _eulerY;
    bool _finish;
    bool _fly = false;
    bool _oil = false;
    public static int Bonus = 0;
    bool onceFinish;
    bool reverse = false;
    RaceManager raceManager;
    float drag = 0.7f;
    float speed = 22f;
    public float absoluteSpeed;
    float timeOil;
    float nitro = 1f;
    float reverseCount = 1f;

    public static event Action RefreshGates;
    // Start is called before the first frame update
    void Start()
    {
        PlayerResurs.GoldForLvl = 0;
        changeCar = GetComponent<ChangeCar>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        /*if (!SceneManager.GetActiveScene().name.Contains("G"))
            raceManager = GameObject.Find("CanvasRace").GetComponent<RaceManager>();*/
        moveVector = new Vector3(0, 0, 1);
        Bonus = 1;
        Stay();
        AudioEngine();
        if (SceneManager.GetActiveScene().name.Contains("Game"))
            _goldForLvl.text = (PlayerResurs.lvlNow + PlayerResurs.GoldForLvl).ToString();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.GameStart || RaceManager.GameStart)
        {
            MoveForward();
        }


        if (rb.velocity.z < 0.2f && _finish)
        {
            _finishWindow.SetActive(true);
            _bonusFinish.text = Bonus.ToString();
            _audioSource.enabled = false;
            _finishGold.text = (GameManager.RewVideoInt + PlayerResurs.GoldForLvl) + " * " + Bonus + " = " + (GameManager.RewVideoInt + PlayerResurs.GoldForLvl) * Bonus;
        }



    }

    void AudioEngine()
    {
        if (_audioSource.pitch >= 1.2)
            _audioSource.pitch = 1.2f;
        else
        {
            if (_audioSource.pitch <= (float)PlayerResurs.SpeedUp / 100f + 0.1f)
                _audioSource.pitch += Time.deltaTime / 10;
            else if (_audioSource.pitch > (float)PlayerResurs.SpeedUp / 100f + 0.16f)
                _audioSource.pitch -= Time.deltaTime / 8;
        }

    }
    private void Update()
    {
        if (GameManager.GameStart || RaceManager.GameStart)
        {

            Drive();
            AudioEngine();
            if (!_finish)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    DriveSound();
                    rb.drag = drag;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    Stay();
                    if (!_oil)
                        speed = 22f;
                    rb.drag = drag * 2;
                }

            }

        }
        if (_fly)
        {
            rb.drag = 0.5f * _dragFly;
        }
        else
        {
            rb.drag = drag;
        }

        if (nitro > 1)
            nitro -= 0.5f * Time.deltaTime;
    }


    void MoveForward()
    {
        if (!_finish)
        {
            if (!_fly)
            {
                if (Input.GetMouseButton(0) && gameObject.transform.rotation.z < 0.47 && gameObject.transform.rotation.z > -0.47)
                {

                    absoluteSpeed = speed * reverseCount * nitro;
                    if (!_oil)
                    {
                        if (speed < PlayerResurs.SpeedUp)
                            speed += (float)PlayerResurs.SpeedUp / 100;

                        rb.AddForce(transform.forward * absoluteSpeed);
                    }
                }
                if (_oil)
                    rb.AddForce(new Vector3(0, 0, absoluteSpeed));
            }
        }
        else
        {

            if (!_fly)
                rb.AddForce(moveVector * 100 * (float)PlayerResurs.SpeedUp * Time.fixedDeltaTime);
            
        }
    }
    void Drive()
    {
        if (!_finish)
        {
            if (!_fly)
            {
                if (Input.GetMouseButtonDown(0) && gameObject.transform.rotation.z < 0.47 && gameObject.transform.rotation.z > -0.47)
                    _oldMousePositionX = Input.mousePosition.x;

                if (Input.GetMouseButton(0) && gameObject.transform.rotation.z < 0.47 && gameObject.transform.rotation.z > -0.47)
                {
                    if (!_oil)
                        if (transform.eulerAngles.y > 180 && transform.eulerAngles.y < 320)
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 10f, transform.eulerAngles.z);
                        else if (transform.eulerAngles.y > 40 && transform.eulerAngles.y <= 180)
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 10f, transform.eulerAngles.z);
                        else
                        {
                            float deltaX = Input.mousePosition.x - _oldMousePositionX;
                            _oldMousePositionX = Input.mousePosition.x;
                            if (reverse)
                                _eulerY -= deltaX * 0.15f;
                            else
                                _eulerY += deltaX * 0.15f;
                            _eulerY = Mathf.Clamp(_eulerY, -38, 38);
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, _eulerY, transform.eulerAngles.z);
                        }

                }
            }
        }

        else
        {

            if (_eulerY > 2)
                _eulerY -= transform.eulerAngles.y * 0.6f * Time.fixedDeltaTime;
            else if (_eulerY < -2)
                _eulerY += transform.eulerAngles.y * 0.6f * Time.fixedDeltaTime;
            transform.eulerAngles = new Vector3(0, _eulerY, 0);

        }



    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Finish")
        {
            DriveSound();
            _finish = true;
        }


        if (other.gameObject.name == "Lose")
            raceManager.Lose();
        if (other.gameObject.name == "FinishRace")
        {
            RaceManager.GameStart = false;
            if (!onceFinish)
            {
                raceManager.Finish();
                onceFinish = true;
            }

        }
        if (other.gameObject.name.Contains("Reverse"))
        {
            if (reverse == false)
            {
                reverse = true;
                animator.SetBool("Reverse", true);
                reverseCount = 0.7f;
            }
            else
            {
                reverse = false;
                animator.SetBool("Reverse", false);
                reverseCount = 1f;
            }
            other.gameObject.name = "contact";
        }
        if (other.gameObject.name.Contains("Nitro"))
        {
            nitro += 1f;
            other.gameObject.name = "contact";
        }
        if (other.gameObject.name.Contains("Refresh"))
        {
            RefreshGates?.Invoke();
            other.gameObject.name = "contact";
        }
        if (other.gameObject.name.Contains("Engine"))
        {
            changeCar.SpeedTrigger(161);
            other.gameObject.name = "contact";
        }
        if (other.gameObject.name.Contains("Bottom"))
        {
            changeCar.SpeedTrigger(-161);
            other.gameObject.name = "contact";
        }
        if (other.gameObject.name.Contains("Wheel"))
        {
            drag = 0.6f;
            rb.drag = drag;
        }
        if (other.gameObject.name.Contains("Coin"))
        {
            PlayerResurs.GoldForLvl++;
            _goldForLvl.text = (PlayerResurs.lvlNow + PlayerResurs.GoldForLvl).ToString();
        }

        if (other.gameObject.name.Contains("Ships"))
        {
            drag = 2;
            rb.drag = drag;
        }

        if (other.gameObject.name.Contains("Oil"))
        {
            timeOil = 0;
            if (!_oil)
            {
                _oil = true;
                StartCoroutine(OilSeconds());
            }
            
        }
        
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Cube"))
        {
            Bonus = int.Parse(Regex.Match(collision.gameObject.name, @"\d+").Value);
        }

        if (collision.gameObject.name.Contains("Road") || collision.gameObject.name.Contains("Tramplin"))
        {
            _oldMousePositionX = Input.mousePosition.x;

        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name.Contains("Road") || collision.gameObject.name.Contains("Tramplin"))
        {
            _fly = false;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Contains("Road") || collision.gameObject.name.Contains("Tramplin"))
            _fly = true;
    }


    public void Stay()
    {
        _audioSource.clip = _sounds[0];
        _audioSource.Play();
        _audioSource.volume = 0.8f;
        if (PlayerResurs.SpeedUp < 80)
            _audioSource.pitch = (float)PlayerResurs.SpeedUp / 100f + 0.35f;

    }

    public void DriveSound()
    {
        _audioSource.clip = _sounds[1];
        _audioSource.Play();
        _audioSource.volume = 0.35f;
        _audioSource.pitch = (float)PlayerResurs.SpeedUp / 100f - 0.15f;
    }

    public IEnumerator OilSeconds()
    {
        while (_oil)
        {
            //I am reducing the time left on the counter by 1 second each time.
            timeOil++;
            if (timeOil >= 2)
            {
                _oldMousePositionX = Input.mousePosition.x;
                _oil = false;
            }



            //   timer.text = timeLeft.ToString("mm\:ss");
            yield return new WaitForSeconds(0.6f);

        }
    }
}
