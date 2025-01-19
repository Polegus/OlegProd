using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ShopGunScene : MonoBehaviour
{
    ChangeCar changeCar;
    [SerializeField] GameObject[] _shopWindow;
    [SerializeField] GameObject[] _stateProduct;
    [SerializeField] GameObject[] _guns;
    [SerializeField] GameObject[] _environment;
    [SerializeField] GameObject[] _road;
    [SerializeField] GameObject[] _barier;
    [SerializeField] GameObject _goRaceWindow;
    [SerializeField] public GameObject _rewardImage;
    [SerializeField] Material[] _skyBox;
    [SerializeField] Text _priceLvlUp;
    [SerializeField] public Text _playersGold;
    [SerializeField] Text _playersAlmaz;
    [SerializeField] Text _priceProduct;
    [SerializeField] Text _priceProductAlmaz;
    [SerializeField] Shop2 _shop;
    [SerializeField] GameObject _shopNextButton;

    public AudioClip[] _sounds;
    public AudioSource _audioSource;

    public int _priceLvl;
    public int _priceReward;
    int _rewardAds;
    public int ShopWindowNow;

    private void OnEnable()
    {
        CheckStateWindow();
    }

    // Отписываемся от события открытия рекламы в OnDisable
    private void OnDisable()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        //changeCar = GameObject.Find("Cars").GetComponent<ChangeCar>();
        _playersGold.text = PlayerResurs1.Golds.ToString();
        _playersAlmaz.text = PlayerResurs1.Almaz.ToString();
        lvlState();
        StartShopingState();
        CheckStateWindow();
    }



    // Update is called once per frame
    void Update()
    {

    }

    void setStateProduct(List<int> PlayerProducts, int productNow, int productChoise)
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
            if (PlayerProducts == PlayerResurs1.PlayerGuns)
            {
                if (productNow < 2)
                {
                    _priceProduct.text = ((productNow + 1) * 100).ToString();
                    _priceProductAlmaz.text = ((productNow + 1) * 2).ToString();
                }
                else if (productNow >= 2 && productNow < 5)
                {
                    _priceProduct.text = ((productNow - 1) * 500).ToString();
                    _priceProductAlmaz.text = ((productNow) * 3).ToString();
                }

                else
                {
                    _priceProduct.text = ((productNow) * 1000).ToString();
                    _priceProductAlmaz.text = ((productNow) * 3).ToString();
                }

            }
            else
            {
                _priceProduct.text = ((productNow + 1) * 100).ToString();
                _priceProductAlmaz.text = (productNow + 1).ToString();
            }

            _stateProduct[0].SetActive(true);
            _stateProduct[1].SetActive(false);
            _stateProduct[2].SetActive(false);
        }


    }

    void BuyProduct()
    {

        PlayerResurs1.Golds -= int.Parse(_priceProduct.text);
        _playersGold.text = PlayerResurs1.Golds.ToString();
    }
    void BuyProductAlmaz()
    {

        PlayerResurs1.Almaz -= int.Parse(_priceProductAlmaz.text);
        _playersAlmaz.text = PlayerResurs1.Almaz.ToString();
    }

    public void BuyProductNow()
    {
        if (int.Parse(_priceProduct.text) <= PlayerResurs1.Golds)
        {
            if (_shopWindow[ShopWindowNow].name.Contains("Turrel"))
            {
                BuyProduct();
                PlayerResurs1.PlayerGuns.Add(PlayerResurs1.GunNow);
                setStateProduct(PlayerResurs1.PlayerGuns, PlayerResurs1.GunNow, PlayerResurs1.GunChoise);
                if (PlayerResurs1.lvlNow == 1 && PlayerResurs1.Help)
                    GameObject.Find("Help").GetComponent<Help>().Help0();
            }
            if (_shopWindow[ShopWindowNow].name.Contains("Environment"))
            {
                BuyProduct();
                PlayerResurs1.PlayerEnvironment.Add(PlayerResurs1.EnvironmentNow);
                setStateProduct(PlayerResurs1.PlayerEnvironment, PlayerResurs1.EnvironmentNow, PlayerResurs1.EnvironmentChoise);
            }
            if (_shopWindow[ShopWindowNow].name.Contains("Sky"))
            {
                BuyProduct();
                PlayerResurs1.PlayerSky.Add(PlayerResurs1.SkyNow);
                setStateProduct(PlayerResurs1.PlayerSky, PlayerResurs1.SkyNow, PlayerResurs1.SkyChoise);
            }
            if (_shopWindow[ShopWindowNow].name.Contains("Barier"))
            {
                BuyProduct();
                PlayerResurs1.PlayerBarier.Add(PlayerResurs1.BarierNow);
                setStateProduct(PlayerResurs1.PlayerBarier, PlayerResurs1.BarierNow, PlayerResurs1.BarierChoise);
            }
            if (_shopWindow[ShopWindowNow].name.Contains("Road"))
            {
                BuyProduct();
                PlayerResurs1.PlayerRoad.Add(PlayerResurs1.RoadNow);
                setStateProduct(PlayerResurs1.PlayerRoad, PlayerResurs1.RoadNow, PlayerResurs1.RoadChoise);
            }
            Buy();
        }

    }
    public void BuyProductDonat()
    {
        if (int.Parse(_priceProductAlmaz.text) <= PlayerResurs1.Almaz)
        {
            if (_shopWindow[ShopWindowNow].name.Contains("Turrel"))
            {
                BuyProductAlmaz();
                PlayerResurs1.PlayerGuns.Add(PlayerResurs1.GunNow);
                setStateProduct(PlayerResurs1.PlayerGuns, PlayerResurs1.GunNow, PlayerResurs1.GunChoise);
            }
            if (_shopWindow[ShopWindowNow].name.Contains("Environment"))
            {
                BuyProductAlmaz();
                PlayerResurs1.PlayerEnvironment.Add(PlayerResurs1.EnvironmentNow);
                setStateProduct(PlayerResurs1.PlayerEnvironment, PlayerResurs1.EnvironmentNow, PlayerResurs1.EnvironmentChoise);
            }
            if (_shopWindow[ShopWindowNow].name.Contains("Sky"))
            {
                BuyProductAlmaz();
                PlayerResurs1.PlayerSky.Add(PlayerResurs1.SkyNow);
                setStateProduct(PlayerResurs1.PlayerSky, PlayerResurs1.SkyNow, PlayerResurs1.SkyChoise);
            }
            if (_shopWindow[ShopWindowNow].name.Contains("Barier"))
            {
                BuyProductAlmaz();
                PlayerResurs1.PlayerBarier.Add(PlayerResurs1.BarierNow);
                setStateProduct(PlayerResurs1.PlayerBarier, PlayerResurs1.BarierNow, PlayerResurs1.BarierChoise);
            }
            if (_shopWindow[ShopWindowNow].name.Contains("Road"))
            {
                BuyProductAlmaz();
                PlayerResurs1.PlayerRoad.Add(PlayerResurs1.RoadNow);
                setStateProduct(PlayerResurs1.PlayerRoad, PlayerResurs1.RoadNow, PlayerResurs1.RoadChoise);
            }
            Buy();
        }


    }

    public void ChoiseProduct()
    {
        if (_shopWindow[ShopWindowNow].name.Contains("Turrel"))
        {

            PlayerResurs1.GunChoise = PlayerResurs1.GunNow;
            setStateProduct(PlayerResurs1.PlayerGuns, PlayerResurs1.GunNow, PlayerResurs1.GunChoise);
            if (PlayerResurs1.lvlNow == 1 && PlayerResurs1.Help)
                GameObject.Find("Help").GetComponent<Help>().Help0();
        }
        if (_shopWindow[ShopWindowNow].name.Contains("Environment"))
        {
            PlayerResurs1.EnvironmentChoise = PlayerResurs1.EnvironmentNow;
            setStateProduct(PlayerResurs1.PlayerEnvironment, PlayerResurs1.EnvironmentNow, PlayerResurs1.EnvironmentChoise);
        }
        if (_shopWindow[ShopWindowNow].name.Contains("Sky"))
        {
            PlayerResurs1.SkyChoise = PlayerResurs1.SkyNow;
            setStateProduct(PlayerResurs1.PlayerSky, PlayerResurs1.SkyNow, PlayerResurs1.SkyChoise);
        }
        if (_shopWindow[ShopWindowNow].name.Contains("Barier"))
        {
            PlayerResurs1.BarierChoise = PlayerResurs1.BarierNow;
            setStateProduct(PlayerResurs1.PlayerBarier, PlayerResurs1.BarierNow, PlayerResurs1.BarierChoise);
        }
        if (_shopWindow[ShopWindowNow].name.Contains("Road"))
        {
            PlayerResurs1.RoadChoise = PlayerResurs1.RoadNow;
            setStateProduct(PlayerResurs1.PlayerRoad, PlayerResurs1.RoadNow, PlayerResurs1.RoadChoise);
        }

        ChoiseSound();
    }
    void ActiveObject(GameObject[] gameObject, ref int value)
    {
        for (int i = 0; i < gameObject.Length; i++)
        {
            if (value == i)
                gameObject[i].SetActive(true);
            else
                gameObject[i].SetActive(false);
        }
    }

    public void NextGun()
    {
        NextGameObject(_guns, ref PlayerResurs1.GunNow);
        setStateProduct(PlayerResurs1.PlayerGuns, PlayerResurs1.GunNow, PlayerResurs1.GunChoise);
    }

    public void PrevGun()
    {
        PrevGameObject(_guns, ref PlayerResurs1.GunNow);
        setStateProduct(PlayerResurs1.PlayerGuns, PlayerResurs1.GunNow, PlayerResurs1.GunChoise);
    }

    public void NextGameObject(GameObject[] gameObject, ref int value)
    {
        if (value < gameObject.Length - 1)
        {
            value++;
            ActiveObject(gameObject, ref value);
        }
        else
        {
            value = 0;
            ActiveObject(gameObject, ref value);
        }
    }
    public void PrevGameObject(GameObject[] gameObject, ref int value)
    {
        if (value > 0)
        {
            value--;
            ActiveObject(gameObject, ref value);
        }
        else
        {
            value = gameObject.Length - 1;
            ActiveObject(gameObject, ref value);
        }
    }

    public void PrevSky()
    {
        if (PlayerResurs1.SkyNow > 0)
            PlayerResurs1.SkyNow--;
        else
            PlayerResurs1.SkyNow = _skyBox.Length - 1;
        RenderSettings.skybox = _skyBox[PlayerResurs1.SkyNow];
        setStateProduct(PlayerResurs1.PlayerSky, PlayerResurs1.SkyNow, PlayerResurs1.SkyChoise);
    }

    public void NextSky()
    {
        if (PlayerResurs1.SkyNow < _skyBox.Length - 1)
            PlayerResurs1.SkyNow++;
        else
            PlayerResurs1.SkyNow = 0;

        RenderSettings.skybox = _skyBox[PlayerResurs1.SkyNow];
        setStateProduct(PlayerResurs1.PlayerSky, PlayerResurs1.SkyNow, PlayerResurs1.SkyChoise);
    }
    public void NextEnvironment()
    {
        NextGameObject(_environment, ref PlayerResurs1.EnvironmentNow);
        setStateProduct(PlayerResurs1.PlayerEnvironment, PlayerResurs1.EnvironmentNow, PlayerResurs1.EnvironmentChoise);
    }

    public void PrevEnvironment()
    {
        PrevGameObject(_environment, ref PlayerResurs1.EnvironmentNow);
        setStateProduct(PlayerResurs1.PlayerEnvironment, PlayerResurs1.EnvironmentNow, PlayerResurs1.EnvironmentChoise);
    }

    public void NextBarier()
    {
        NextGameObject(_barier, ref PlayerResurs1.BarierNow);
        setStateProduct(PlayerResurs1.PlayerBarier, PlayerResurs1.BarierNow, PlayerResurs1.BarierChoise);
    }

    public void PrevBarier()
    {
        PrevGameObject(_barier, ref PlayerResurs1.BarierNow);
        setStateProduct(PlayerResurs1.PlayerBarier, PlayerResurs1.BarierNow, PlayerResurs1.BarierChoise);
    }
    public void NextRoad()
    {
        NextGameObject(_road, ref PlayerResurs1.RoadNow);
        setStateProduct(PlayerResurs1.PlayerRoad, PlayerResurs1.RoadNow, PlayerResurs1.RoadChoise);
    }

    public void PrevRoad()
    {
        PrevGameObject(_road, ref PlayerResurs1.RoadNow);
        setStateProduct(PlayerResurs1.PlayerRoad, PlayerResurs1.RoadNow, PlayerResurs1.RoadChoise);
    }
    public void NextWindowShop()
    {
        CheckStateWindow();
        NextGameObject(_shopWindow, ref ShopWindowNow);

    }

    public void PrevWindowShop()
    {
        CheckStateWindow();
        PrevGameObject(_shopWindow, ref ShopWindowNow);

    }

    public void lvlState()
    {
        _priceLvl = (_shop.NumObj + 1) * 2  + _shop.NumObj * _shop.NumObj * 3;
        if (PlayerResurs1.Golds < _priceLvl)
        {
            if (PlayerResurs1.lvlNow < 20)
                _priceReward = 50;
            else
                _priceReward = PlayerResurs1.lvlNow * 3;
            _rewardImage.SetActive(true);
            _priceLvlUp.text = "+" + _priceReward;
            _shopNextButton.SetActive(false);
        }
        else
        {
            _shopNextButton.SetActive(true);
            _rewardImage.SetActive(false);
            _priceLvlUp.text = _priceLvl.ToString();
        }

        _playersGold.text = PlayerResurs1.Golds.ToString();

    }
    public void BuyLvl()
    {
        if (PlayerResurs1.Golds >= _priceLvl)
        {
            PlayerResurs1.Golds -= _priceLvl;
            changeCar.SpeedTrigger(20);
            lvlState();
            Buy();
            if (PlayerResurs1.SpeedUp == 24 ||
                PlayerResurs1.SpeedUp == 28 ||
                PlayerResurs1.SpeedUp == 36 ||
                PlayerResurs1.SpeedUp == 44 ||
                PlayerResurs1.SpeedUp == 52 ||
                PlayerResurs1.SpeedUp == 62 ||
                PlayerResurs1.SpeedUp == 72 ||
                PlayerResurs1.SpeedUp == 82)
                _goRaceWindow.SetActive(true);
        }

    }

    public void CloseGoRace()
    {
        _goRaceWindow.SetActive(false);
    }

    void CheckStateWindow()
    {
        if (_shopWindow[ShopWindowNow].name.Contains("Turrel"))
        {
            setStateProduct(PlayerResurs1.PlayerGuns, PlayerResurs1.GunNow, PlayerResurs1.GunChoise);
            PlayerResurs1.GunNow = PlayerResurs1.GunChoise - 1;

            NextGun();
        }
        if (_shopWindow[ShopWindowNow].name.Contains("Environment"))
        {
            setStateProduct(PlayerResurs1.PlayerEnvironment, PlayerResurs1.EnvironmentNow, PlayerResurs1.EnvironmentChoise);
            PlayerResurs1.EnvironmentNow = PlayerResurs1.EnvironmentChoise - 1;
            NextEnvironment();
        }
        if (_shopWindow[ShopWindowNow].name.Contains("Sky"))
        {
            setStateProduct(PlayerResurs1.PlayerSky, PlayerResurs1.SkyNow, PlayerResurs1.SkyChoise);
            PlayerResurs1.SkyNow = PlayerResurs1.SkyChoise - 1;
            NextSky();
        }
        if (_shopWindow[ShopWindowNow].name.Contains("Barier"))
        {
            setStateProduct(PlayerResurs1.PlayerBarier, PlayerResurs1.BarierNow, PlayerResurs1.BarierChoise);
            PlayerResurs1.BarierNow = PlayerResurs1.BarierChoise - 1;
            NextBarier();
        }
        if (_shopWindow[ShopWindowNow].name.Contains("Road"))
        {
            setStateProduct(PlayerResurs1.PlayerRoad, PlayerResurs1.RoadNow, PlayerResurs1.RoadChoise);
            PlayerResurs1.RoadNow = PlayerResurs1.RoadChoise - 1;
            NextRoad();
        }
    }

    void StartShopingState()
    {
        PlayerResurs1.GunNow = PlayerResurs1.GunChoise;
        PlayerResurs1.EnvironmentNow = PlayerResurs1.EnvironmentChoise;
        PlayerResurs1.RoadNow = PlayerResurs1.RoadChoise;
        PlayerResurs1.SkyNow = PlayerResurs1.SkyChoise;
        PlayerResurs1.BarierNow = PlayerResurs1.BarierChoise;
        setStateProduct(PlayerResurs1.PlayerSky, PlayerResurs1.SkyNow, PlayerResurs1.SkyChoise);
        setStateProduct(PlayerResurs1.PlayerEnvironment, PlayerResurs1.EnvironmentNow, PlayerResurs1.EnvironmentChoise);
        setStateProduct(PlayerResurs1.PlayerBarier, PlayerResurs1.BarierNow, PlayerResurs1.BarierChoise);
        setStateProduct(PlayerResurs1.PlayerRoad, PlayerResurs1.RoadNow, PlayerResurs1.RoadChoise);
        setStateProduct(PlayerResurs1.PlayerGuns, PlayerResurs1.GunNow, PlayerResurs1.GunChoise);
        ActiveObject(_environment, ref PlayerResurs1.EnvironmentNow);
        ActiveObject(_road, ref PlayerResurs1.RoadNow);
        ActiveObject(_barier, ref PlayerResurs1.BarierNow);
        RenderSettings.skybox = _skyBox[PlayerResurs1.SkyNow];
    }


    public void CloseShop()
    {
        StartShopingState();
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



    public void GetGoldReward()
    {
        YandexGame.RewVideoShow(1);
    }
}
