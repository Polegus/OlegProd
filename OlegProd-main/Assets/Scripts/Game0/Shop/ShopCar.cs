using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ShopCar : MonoBehaviour
{
    [SerializeField] GameObject[] _windowShop;
    [SerializeField] GameObject[] _stateProduct;
    [SerializeField] Text _priceProduct;
    [SerializeField] Text _priceProductAlmaz;
    [SerializeField] GameObject[] _lights;
    [SerializeField] Material[] _colorsCar;
    [SerializeField] ShopOneCar _openShop;
    [SerializeField] public GameObject _cars;
    [SerializeField] Text _playersAlmaz;

    public AudioClip[] _sounds;
    public AudioSource _audioSource;

    GarageManager _garageManager;
    GarageCar _car;
    MeshRenderer _garageCar;
    public int windowShopNow;
    public int pageNow;
    float _oldMousePositionX;
    float _eulerY;
    public Quaternion startPos;
    public int carNow;

    // Start is called before the first frame update
    void Start()
    {
        _garageManager = GameObject.Find("CanvasButton").GetComponent<GarageManager>();
        startPos = gameObject.transform.rotation;
        _eulerY = gameObject.transform.eulerAngles.y;
        _car = GetComponent<GarageCar>();
        carNow = int.Parse(Regex.Replace(gameObject.name, @"[^\d]", ""));
       // StartState(_car._wheels, PlayerResurs.CarWheelChoise[carNow]);
        _garageCar.material = _colorsCar[PlayerResurs.ColorCarChoise[carNow]];
        StartState(_lights, PlayerResurs.CarLightChoise[carNow]);
        _playersAlmaz.text = PlayerResurs.Almaz.ToString();
    }

    void StartState(GameObject[] objects, int choiseObj)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (choiseObj == i)
                objects[i].SetActive(true);
            else
                objects[i].SetActive(false);
        }
    }
    private void OnEnable()
    {
        _garageCar = gameObject.transform.Find("Cars").Find(Regex.Replace(gameObject.name, @"[^\d]", "")).Find("Body").GetComponent<MeshRenderer>();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (_openShop.OpenShop)
        {

            if (Input.GetMouseButtonDown(0))
            {
                _oldMousePositionX = Input.mousePosition.x;
            }

            if (Input.GetMouseButton(0))
            {
                float deltaX = Input.mousePosition.x - _oldMousePositionX;
                _oldMousePositionX = Input.mousePosition.x;
                _eulerY += deltaX * 0.1f;
                _cars.transform.eulerAngles = new Vector3(transform.eulerAngles.x, _eulerY, transform.eulerAngles.z);
            }
        }
            
    }
    void setStateProduct(List<int> PlayerProducts, int productNow, int productChoise, int price)
    {

        if (PlayerProducts.Contains(productNow))
        {
            if (productChoise == productNow)
            {
                _stateProduct[0].SetActive(false);
                _stateProduct[1].SetActive(false);
                _stateProduct[2].SetActive(true);
            }
            else
            {
                _stateProduct[0].SetActive(false);
                _stateProduct[1].SetActive(true);
                _stateProduct[2].SetActive(false);
            }
        }
        else
        {
            _priceProduct.text = ((price+1) * productNow).ToString();
            _priceProductAlmaz.text = productNow.ToString();
            _stateProduct[0].SetActive(true);
            _stateProduct[1].SetActive(false);
            _stateProduct[2].SetActive(false);
        }

    }

    void BuyProduct()
    {
        GarageManager.BuyProduct(int.Parse(_priceProduct.text), _garageManager);
    }
    void BuyProductDonat()
    {
        PlayerResurs.Almaz -= int.Parse(_priceProductAlmaz.text);
        _playersAlmaz.text = PlayerResurs.Almaz.ToString();
    }
    public void BuyProductNow()
    {
        if (int.Parse(_priceProduct.text) <= PlayerResurs.Golds)
        {
            if (_windowShop[windowShopNow].name.Contains("Color"))
            {
                BuyProduct();
                PlayerResurs.ColorsCar[carNow].Add(pageNow);
                setStateProduct(PlayerResurs.ColorsCar[carNow], pageNow, PlayerResurs.ColorCarChoise[carNow], carNow + 2);
            }
            if (_windowShop[windowShopNow].name.Contains("Light"))
            {
                BuyProduct();
                PlayerResurs.LightCar[carNow].Add(pageNow);
                 setStateProduct(PlayerResurs.LightCar[carNow], pageNow, PlayerResurs.CarLightChoise[carNow], carNow + 2);
            }
            if (_windowShop[windowShopNow].name.Contains("Wheel"))
            {
                BuyProduct();
                PlayerResurs.PlayerWheel.Add(pageNow);
                setStateProduct(PlayerResurs.PlayerWheel, pageNow, PlayerResurs.WheelChoise, 99);
            }
             Buy();
        }
    }

    public void BuyProductAlmaz()
    {
        if (int.Parse(_priceProductAlmaz.text) <= PlayerResurs.Almaz)
        {
            if (_windowShop[windowShopNow].name.Contains("Color"))
            {
                BuyProductDonat();
                PlayerResurs.ColorsCar[carNow].Add(pageNow);
                setStateProduct(PlayerResurs.ColorsCar[carNow], pageNow, PlayerResurs.ColorCarChoise[carNow], carNow + 2);
            }
            if (_windowShop[windowShopNow].name.Contains("Light"))
            {
                BuyProductDonat();
                PlayerResurs.LightCar[carNow].Add(pageNow);
                setStateProduct(PlayerResurs.LightCar[carNow], pageNow, PlayerResurs.CarLightChoise[carNow], carNow + 2);
            }
            if (_windowShop[windowShopNow].name.Contains("Wheel"))
            {
                BuyProductDonat();
                PlayerResurs.PlayerWheel.Add(pageNow);
                setStateProduct(PlayerResurs.PlayerWheel, pageNow, PlayerResurs.WheelChoise, 99);
            }
             Buy();
        }
    }

    public void ChoiseProduct()
    {
        if (_windowShop[windowShopNow].name.Contains("Color"))
        {

            PlayerResurs.ColorCarChoise[carNow] = pageNow;
            setStateProduct(PlayerResurs.ColorsCar[carNow], pageNow, PlayerResurs.ColorCarChoise[carNow], carNow + 2);
        }
        if (_windowShop[windowShopNow].name.Contains("Light"))
        {
            PlayerResurs.CarLightChoise[carNow] = pageNow;
            setStateProduct(PlayerResurs.LightCar[carNow], pageNow, PlayerResurs.CarLightChoise[carNow], carNow + 2);
        }
        if (_windowShop[windowShopNow].name.Contains("Wheel"))
        {
            PlayerResurs.CarWheelChoise[carNow] = pageNow;
                setStateProduct(PlayerResurs.PlayerWheel, pageNow, PlayerResurs.CarWheelChoise[carNow], 99);
        }
        ChoiseSound();
    }
    void ActiveObject(GameObject[] gameObject)
    {
        for (int i = 0; i < gameObject.Length; i++)
        {
            if (pageNow == i)
                gameObject[i].SetActive(true);
            else
                gameObject[i].SetActive(false);
        }
    }



    public void NextGameObject(GameObject[] gameObject, ref int value)
    {
        if (value < gameObject.Length - 1)
        {
            value++;
            ActiveObject(gameObject);
        }
        else
        {
            value = 0;
            ActiveObject(gameObject);
        }
    }
    public void PrevGameObject(GameObject[] gameObject, ref int value)
    {
        if (value > 0)
        {
            value--;
            ActiveObject(gameObject);
        }
        else
        {
            value = gameObject.Length - 1;
            ActiveObject(gameObject);
        }
    }

    public void NextWheel()
    {
        nextPage(_car._wheels);
        ActiveObject(_car._wheels);
        if (PlayerResurs.CarWheelChoise[carNow] == 0)
            setStateProduct(PlayerResurs.PlayerWheel, pageNow, PlayerResurs.WheelChoise, 99);
        else
            setStateProduct(PlayerResurs.PlayerWheel, pageNow, PlayerResurs.CarWheelChoise[carNow], 99);
    }

    public void PrevWheel()
    {
        prevPage(_car._wheels);
        ActiveObject(_car._wheels);
        if (PlayerResurs.CarWheelChoise[carNow] == 0)
            setStateProduct(PlayerResurs.PlayerWheel, pageNow, PlayerResurs.WheelChoise, 99);
        else
            setStateProduct(PlayerResurs.PlayerWheel, pageNow, PlayerResurs.CarWheelChoise[carNow], 99);
    }

    public void NextColor()
    {
        nextPage(_colorsCar);
        _garageCar.material = _colorsCar[pageNow];
        setStateProduct(PlayerResurs.ColorsCar[carNow], pageNow, PlayerResurs.ColorCarChoise[carNow], carNow+2);
    }

    public void PrevColor()
    {
        prevPage(_colorsCar);
        _garageCar.material = _colorsCar[pageNow];
        setStateProduct(PlayerResurs.ColorsCar[carNow], pageNow, PlayerResurs.ColorCarChoise[carNow], carNow+2);
    }

    public void NextLight()
    {
        nextPage(_lights);
        ActiveObject(_lights);
        setStateProduct(PlayerResurs.LightCar[carNow], pageNow, PlayerResurs.CarLightChoise[carNow], carNow+2);
    }

    public void PrevLight()
    {
        prevPage(_lights);
        ActiveObject(_lights);
        setStateProduct(PlayerResurs.LightCar[carNow], pageNow, PlayerResurs.CarLightChoise[carNow], carNow+2);
    }

    public void StateWindowShop()
    {
        if (_windowShop[windowShopNow].name.Contains("Color"))
        {
            _garageCar.material = _colorsCar[PlayerResurs.ColorCarChoise[carNow]];
            pageNow = PlayerResurs.ColorCarChoise[carNow] - 1;
            NextColor();
        }
        else if (_windowShop[windowShopNow].name.Contains("Light"))
        {

            _lights[PlayerResurs.CarLightChoise[carNow]].SetActive(true);
            pageNow = PlayerResurs.CarLightChoise[carNow] - 1;
            NextLight();
        }
        else if (_windowShop[windowShopNow].name.Contains("Wheel"))
        {
            if (PlayerResurs.CarWheelChoise[carNow] == 0)
            {
                pageNow = PlayerResurs.WheelChoise - 1;
                _car._wheels[PlayerResurs.WheelChoise].SetActive(true);
            }
            else
            {
                pageNow = PlayerResurs.CarWheelChoise[carNow]-1;
                _car._wheels[PlayerResurs.CarWheelChoise[carNow]].SetActive(true);
            }
            NextWheel();   
        }
    }
    void ChoiseState(GameObject[] obj, int choiseObj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            if (choiseObj == i)
                obj[i].SetActive(true);
            else
                obj[i].SetActive(false);
        }
    }
    public void allChoiseState()
    {
        if (PlayerResurs.CarWheelChoise[carNow] != 0)
            ChoiseState(_car._wheels, PlayerResurs.CarWheelChoise[carNow]);
        else
            ChoiseState(_car._wheels, PlayerResurs.WheelChoise);
        ChoiseState(_lights, PlayerResurs.CarLightChoise[carNow]);
        _garageCar.material = _colorsCar[PlayerResurs.ColorCarChoise[carNow]];

    }
    public void nextWindowShop()
    {


        if (windowShopNow < _windowShop.Length - 1)
            windowShopNow++;
        else
            windowShopNow = 0;
        for (int i = 0; i < _windowShop.Length; i++)
        {
            if (windowShopNow == i)
                _windowShop[i].SetActive(true);
            else
                _windowShop[i].SetActive(false);
        }
        StateWindowShop();
        allChoiseState();
    }

    public void prevWindowShop()
    {

        if (windowShopNow > 0)
            windowShopNow--;
        else
            windowShopNow = _windowShop.Length - 1;
        for (int i = 0; i < _windowShop.Length; i++)
        {
            if (windowShopNow == i)
                _windowShop[i].SetActive(true);
            else
                _windowShop[i].SetActive(false);
        }
        StateWindowShop();
        allChoiseState();
    }

    void nextPage<T>(T[] Object)
    {
        if (pageNow < Object.Length - 1)
            pageNow++;
        else
            pageNow = 0;
    }

    void prevPage<T>(T[] Object)
    {
        if (pageNow > 0)
            pageNow--;
        else
            pageNow = Object.Length - 1;
    }

    public void Buy()
    {
        _audioSource.clip = _sounds[0];
        _audioSource.Play();
    }



    public void ChoiseSound()
    {
        _audioSource.clip = _sounds[1];
        _audioSource.Play();
    }
}
