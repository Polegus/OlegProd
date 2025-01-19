using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ShopOneCar : MonoBehaviour
{
    [SerializeField] GameObject _windowShop;
    [SerializeField] GameObject _cameraPos;
    [SerializeField] ShopCar _shopCar;
    
    Animator _cameraAnimator;
    GameObject _joystick;
    GameObject _camera;
    GameObject _player;
    Image _buttonBuy;
    Vector3 _cameraStandartPos;
    Quaternion _cameraStandartEuler;
    public bool OpenShop;
    private void Start()
    {
        _buttonBuy = GetComponent<Image>();
        _shopCar.allChoiseState();
    }
    private void Update()
    {
        
    }
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && _buttonBuy.fillAmount < 1)
        {
            _buttonBuy.fillAmount += Time.deltaTime/2f;
        }
        else
        {
            
            _camera = GameObject.Find("Camera");
            _joystick = GameObject.Find("Dynamic Joystick");
            _cameraStandartEuler = _camera.transform.rotation;
            _shopCar.windowShopNow --;
            _shopCar.nextWindowShop();
            //_shopCar.pageNow = PlayerResurs.ColorCarChoise[_shopCar.carNow];
            _joystick.SetActive(false);
            _cameraAnimator = _camera.GetComponent<Animator>();
            _cameraAnimator.SetBool("OpenShop", true);
            _player = other.gameObject;
            _player.SetActive(false);
            _cameraStandartPos = _player.transform.position;
            _player.transform.position = _cameraPos.transform.position;
            _camera.transform.rotation = _cameraPos.transform.rotation;
            _windowShop.SetActive(true);
            _shopCar.StateWindowShop();
            OpenShop = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _buttonBuy.fillAmount = 0;
    }

    public void CloseShop()
    {
        _shopCar.allChoiseState();
        _buttonBuy.fillAmount = 0;
        _camera.transform.rotation = _cameraStandartEuler;
        _cameraAnimator.SetBool("OpenShop", false);
        _joystick.SetActive(true);
        _windowShop.SetActive(false);
        _player.transform.position = _cameraStandartPos;
        _camera.transform.rotation = _cameraStandartEuler;
        _player.SetActive(true);
        OpenShop = false;
        _shopCar._cars.transform.rotation = _shopCar.startPos;
        SaveShopGarage();
    }
    public void SaveShopGarage()
    {
        YandexGame.savesData.Golds = PlayerResurs.Golds;
        YandexGame.savesData.Almaz = PlayerResurs.Almaz;
        YandexGame.savesData.PlayerWheel = PlayerResurs.PlayerWheel;
        YandexGame.savesData.ColorCarChoise = PlayerResurs.ColorCarChoise;
        YandexGame.savesData.ColorsCar = PlayerResurs.ColorsCar;
        YandexGame.savesData.CarLightChoise = PlayerResurs.CarLightChoise;
        YandexGame.savesData.LightCar = PlayerResurs.LightCar;
        YandexGame.savesData.CarWheelChoise = PlayerResurs.CarWheelChoise;
        YandexGame.SaveProgress();
    }

}
