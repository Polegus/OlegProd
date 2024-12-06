using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{

    [SerializeField] GameObject _patron;
    [SerializeField] GameObject[] _spawnPos;
    [SerializeField] GameObject _effectFire;
    [SerializeField] GameObject _canvas;
    [SerializeField] float _kofSpeed;
    [SerializeField] float _kofStrenght;
    [SerializeField] float _kofDistance;
    Animator _animator;
    public static List<int> ParamGun;
    public static event Action StateParamGun;
    bool _startFire = false;
    int _fireBigSpeed = 0;

    void Fire()
    {
        if (ParamGun[2] == 0)
        {
            Instantiate(_patron, _spawnPos[0].transform.position, _spawnPos[0].transform.rotation);
            if (ParamGuns.Speed < 800f)
                Instantiate(_effectFire, _spawnPos[1].transform.position, _spawnPos[0].transform.rotation, gameObject.transform);
            else
            {
                if (_fireBigSpeed % 2 == 0)
                    Instantiate(_effectFire, _spawnPos[1].transform.position, _spawnPos[0].transform.rotation, gameObject.transform);
                _fireBigSpeed++;

            }
        }
        else
        {
            Instantiate(_patron, _spawnPos[1].transform.position, _spawnPos[0].transform.rotation);
            if (ParamGuns.Speed < 800f)
                Instantiate(_effectFire, _spawnPos[1].transform.position, _spawnPos[0].transform.rotation, gameObject.transform);
            else
            {
                if (_fireBigSpeed % 2 == 0)
                    Instantiate(_effectFire, _spawnPos[1].transform.position, _spawnPos[0].transform.rotation, gameObject.transform);
                _fireBigSpeed++;
            }
        }
        if (ParamGuns.Speed < 240f)
            _animator.SetTrigger("Fire");
        else
            _animator.SetTrigger("Fire3");
    }
    // Start is called before the first frame update
    void Start()
    {

        _animator = GetComponent<Animator>();
        StateParamGun?.Invoke();
    }

    public void BonusWeapon()
    {
        if (gameObject.name == "Gun")
            ParamGun = PlayerResurs1.Gun0;
        else if (gameObject.name == "Gun1")
            ParamGun = PlayerResurs1.Gun1;
        else if (gameObject.name == "Gun2")
            ParamGun = PlayerResurs1.Gun2;
        else if (gameObject.name == "Gun3")
            ParamGun = PlayerResurs1.Gun3;
        else if (gameObject.name == "Gun4")
            ParamGun = PlayerResurs1.Gun4;
        else if (gameObject.name == "Gun5")
            ParamGun = PlayerResurs1.Gun5;
        else if (gameObject.name == "Gun6")
            ParamGun = PlayerResurs1.Gun6;

    }

    void paramGun()
    {
        ParamGuns.Speed = ParamGuns.Speed * _kofSpeed + ParamGun[0] * 30;
        ParamGuns.Strength = ParamGuns.Strength * _kofStrenght + ParamGun[1] * 30;
        ParamGuns.Distance = ParamGuns.Distance * _kofDistance + ParamGun[2] * 15;
    }

    private void OnEnable()
    {
        GameManager1.StartAnim += StartGame;
        BonusWeapon();
        StateParamGun?.Invoke();
    }

    private void OnDisable()
    {
        GameManager1.StartAnim -= StartGame;
    }
    // Update is called once per frame
    void Update()
    {

    }

    void SetState(List<int> first, List<int> two)
    {
        for (int i = 0; i < 3; i++)
        {
            first[i] = two[i];
        }
    }
    void StartGame()
    {
        if (gameObject.name == "Gun")
            SetState(PlayerResurs1.Gun0, ParamGun);
        else if (gameObject.name == "Gun1")
            SetState(PlayerResurs1.Gun1, ParamGun);
        else if (gameObject.name == "Gun2")
            SetState(PlayerResurs1.Gun2, ParamGun);
        else if (gameObject.name == "Gun3")
            SetState(PlayerResurs1.Gun3, ParamGun);
        else if (gameObject.name == "Gun4")
            SetState(PlayerResurs1.Gun4, ParamGun);
        else if (gameObject.name == "Gun5")
            SetState(PlayerResurs1.Gun5, ParamGun);
        else if (gameObject.name == "Gun6")
            SetState(PlayerResurs1.Gun6, ParamGun);
        paramGun();
        _canvas.SetActive(false);
        _animator.enabled = true;
        StartCoroutine(DoCheck());
    }

    IEnumerator DoCheck()
    {
        while (ParamGuns.Speed > 0)
        {
            if (!_startFire)
            {
                yield return new WaitForSeconds(1f);
                _startFire = true;
            }

            yield return new WaitForSeconds(60f / ParamGuns.Speed);
            Fire();

        }
    }


}
