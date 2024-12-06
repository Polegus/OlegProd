using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Shop : MonoBehaviour
{
    ChangeCar changeCar;
    ChangeWheel changeWheel;
    [SerializeField] GameObject[] _shopWindow;
    [SerializeField] GameObject[] _stateProduct;
    [SerializeField] GameObject[] _environment;
    [SerializeField] GameObject[] _road;
    [SerializeField] GameObject[] _barier;
    [SerializeField] GameObject _goRaceWindow;
    [SerializeField] Material[] _skyBox;
    [SerializeField] Text _priceLvlUp;
    [SerializeField] Text _priceVideoShow;
    [SerializeField] Text _playersGold;
    [SerializeField] Text _playersAlmaz;
    [SerializeField] Text _priceProduct;
    [SerializeField] Text _priceProductAlmaz;
    [SerializeField] Image _progressLvlUp;


    public AudioClip[] _sounds;
    public AudioSource _audioSource;

    int _priceLvl;
    int _rewardAds;
    public int ShopWindowNow;

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }

    // Отписываемся от события открытия рекламы в OnDisable
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }

    // Start is called before the first frame update
    void Start()
    {
        changeCar = GameObject.Find("Cars").GetComponent<ChangeCar>();
        changeWheel = GameObject.Find("Cars").GetComponent<ChangeWheel>();

        _playersGold.text = PlayerResurs.Golds.ToString();
      //  _playersAlmaz.text = PlayerResurs.Almaz.ToString();
        lvlState();
        StartShopingState();
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
            _priceProduct.text = ((productNow + 1) * 100).ToString();
         //   _priceProductAlmaz.text = (productNow + 1).ToString();
            _stateProduct[0].SetActive(true);
            _stateProduct[1].SetActive(false);
            _stateProduct[2].SetActive(false);
        }

    }

    void BuyProduct()
    {

        PlayerResurs.Golds -= int.Parse(_priceProduct.text);
        _playersGold.text = PlayerResurs.Golds.ToString();
    }
    void BuyProductAlmaz()
    {

        PlayerResurs.Almaz -= int.Parse(_priceProductAlmaz.text);
        _playersAlmaz.text = PlayerResurs.Almaz.ToString();
    }

    public void BuyProductNow()
    {
        if (int.Parse(_priceProduct.text) <= PlayerResurs.Golds)
        {
            if (_shopWindow[ShopWindowNow].name.Contains("Wheel"))
            {
                BuyProduct();
                PlayerResurs.PlayerWheel.Add(PlayerResurs.WheelNow);
                setStateProduct(PlayerResurs.PlayerWheel, PlayerResurs.WheelNow, PlayerResurs.WheelChoise);
            }
            if (_shopWindow[ShopWindowNow].name.Contains("Environment"))
            {
                BuyProduct();
                PlayerResurs.PlayerEnvironment.Add(PlayerResurs.EnvironmentNow);
                setStateProduct(PlayerResurs.PlayerEnvironment, PlayerResurs.EnvironmentNow, PlayerResurs.EnvironmentChoise);
            }
            if (_shopWindow[ShopWindowNow].name.Contains("Sky"))
            {
                BuyProduct();
                PlayerResurs.PlayerSky.Add(PlayerResurs.SkyNow);
                setStateProduct(PlayerResurs.PlayerSky, PlayerResurs.SkyNow, PlayerResurs.SkyChoise);
            }
            if (_shopWindow[ShopWindowNow].name.Contains("Barier"))
            {
                BuyProduct();
                PlayerResurs.PlayerBarier.Add(PlayerResurs.BarierNow);
                setStateProduct(PlayerResurs.PlayerBarier, PlayerResurs.BarierNow, PlayerResurs.BarierChoise);
            }
            if (_shopWindow[ShopWindowNow].name.Contains("Road"))
            {
                BuyProduct();
                PlayerResurs.PlayerRoad.Add(PlayerResurs.RoadNow);
                setStateProduct(PlayerResurs.PlayerRoad, PlayerResurs.RoadNow, PlayerResurs.RoadChoise);
            }
            Buy();
        }
    }
    public void BuyProductDonat()
    {
        if (int.Parse(_priceProductAlmaz.text) <= PlayerResurs.Almaz)
        {
            if (_shopWindow[ShopWindowNow].name.Contains("Wheel"))
            {
                BuyProductAlmaz();
                PlayerResurs.PlayerWheel.Add(PlayerResurs.WheelNow);
                setStateProduct(PlayerResurs.PlayerWheel, PlayerResurs.WheelNow, PlayerResurs.WheelChoise);
            }
            if (_shopWindow[ShopWindowNow].name.Contains("Environment"))
            {
                BuyProductAlmaz();
                PlayerResurs.PlayerEnvironment.Add(PlayerResurs.EnvironmentNow);
                setStateProduct(PlayerResurs.PlayerEnvironment, PlayerResurs.EnvironmentNow, PlayerResurs.EnvironmentChoise);
            }
            if (_shopWindow[ShopWindowNow].name.Contains("Sky"))
            {
                BuyProductAlmaz();
                PlayerResurs.PlayerSky.Add(PlayerResurs.SkyNow);
                setStateProduct(PlayerResurs.PlayerSky, PlayerResurs.SkyNow, PlayerResurs.SkyChoise);
            }
            if (_shopWindow[ShopWindowNow].name.Contains("Barier"))
            {
                BuyProductAlmaz();
                PlayerResurs.PlayerBarier.Add(PlayerResurs.BarierNow);
                setStateProduct(PlayerResurs.PlayerBarier, PlayerResurs.BarierNow, PlayerResurs.BarierChoise);
            }
            if (_shopWindow[ShopWindowNow].name.Contains("Road"))
            {
                BuyProductAlmaz();
                PlayerResurs.PlayerRoad.Add(PlayerResurs.RoadNow);
                setStateProduct(PlayerResurs.PlayerRoad, PlayerResurs.RoadNow, PlayerResurs.RoadChoise);
            }
            Buy();
        }


    }

    public void ChoiseProduct()
    {
        if (_shopWindow[ShopWindowNow].name.Contains("Wheel"))
        {
            
            PlayerResurs.WheelChoise = PlayerResurs.WheelNow;
            PlayerResurs.CarWheelChoise[changeWheel.carNow] = PlayerResurs.WheelNow;
            setStateProduct(PlayerResurs.PlayerWheel, PlayerResurs.WheelNow, PlayerResurs.WheelChoise);
        }
        if (_shopWindow[ShopWindowNow].name.Contains("Environment"))
        {
            PlayerResurs.EnvironmentChoise = PlayerResurs.EnvironmentNow;
            setStateProduct(PlayerResurs.PlayerEnvironment, PlayerResurs.EnvironmentNow, PlayerResurs.EnvironmentChoise);
        }
        if (_shopWindow[ShopWindowNow].name.Contains("Sky"))
        {
            PlayerResurs.SkyChoise = PlayerResurs.SkyNow;
            setStateProduct(PlayerResurs.PlayerSky, PlayerResurs.SkyNow, PlayerResurs.SkyChoise);
        }
        if (_shopWindow[ShopWindowNow].name.Contains("Barier"))
        {
            PlayerResurs.BarierChoise = PlayerResurs.BarierNow;
            setStateProduct(PlayerResurs.PlayerBarier, PlayerResurs.BarierNow, PlayerResurs.BarierChoise);
        }
        if (_shopWindow[ShopWindowNow].name.Contains("Road"))
        {
            PlayerResurs.RoadChoise = PlayerResurs.RoadNow;
            setStateProduct(PlayerResurs.PlayerRoad, PlayerResurs.RoadNow, PlayerResurs.RoadChoise);
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

    public void NextWheel()
    {
        changeWheel.NextWheel();
        if (PlayerResurs.CarWheelChoise[changeWheel.carNow] == 0)
            setStateProduct(PlayerResurs.PlayerWheel, PlayerResurs.WheelNow, PlayerResurs.WheelChoise);
        else
            setStateProduct(PlayerResurs.PlayerWheel, PlayerResurs.WheelNow, PlayerResurs.CarWheelChoise[changeWheel.carNow]);
    }

    public void PrevWheel()
    {
        changeWheel.PrevWheel();
        setStateProduct(PlayerResurs.PlayerWheel, PlayerResurs.WheelNow, PlayerResurs.WheelChoise);
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
        if (PlayerResurs.SkyNow > 0)
            PlayerResurs.SkyNow--;
        else
            PlayerResurs.SkyNow = _skyBox.Length - 1;
        RenderSettings.skybox = _skyBox[PlayerResurs.SkyNow];
        setStateProduct(PlayerResurs.PlayerSky, PlayerResurs.SkyNow, PlayerResurs.SkyChoise);
    }

    public void NextSky()
    {
        if (PlayerResurs.SkyNow < _skyBox.Length - 1)
            PlayerResurs.SkyNow++;
        else
            PlayerResurs.SkyNow = 0;

        RenderSettings.skybox = _skyBox[PlayerResurs.SkyNow];
        setStateProduct(PlayerResurs.PlayerSky, PlayerResurs.SkyNow, PlayerResurs.SkyChoise);
    }
    public void NextEnvironment()
    {
        NextGameObject(_environment, ref PlayerResurs.EnvironmentNow);
        setStateProduct(PlayerResurs.PlayerEnvironment, PlayerResurs.EnvironmentNow, PlayerResurs.EnvironmentChoise);
    }

    public void PrevEnvironment()
    {
        PrevGameObject(_environment, ref PlayerResurs.EnvironmentNow);
        setStateProduct(PlayerResurs.PlayerEnvironment, PlayerResurs.EnvironmentNow, PlayerResurs.EnvironmentChoise);
    }

    public void NextBarier()
    {
        NextGameObject(_barier, ref PlayerResurs.BarierNow);
        setStateProduct(PlayerResurs.PlayerBarier, PlayerResurs.BarierNow, PlayerResurs.BarierChoise);
    }

    public void PrevBarier()
    {
        PrevGameObject(_barier, ref PlayerResurs.BarierNow);
        setStateProduct(PlayerResurs.PlayerBarier, PlayerResurs.BarierNow, PlayerResurs.BarierChoise);
    }
    public void NextRoad()
    {
        NextGameObject(_road, ref PlayerResurs.RoadNow);
        setStateProduct(PlayerResurs.PlayerRoad, PlayerResurs.RoadNow, PlayerResurs.RoadChoise);
    }

    public void PrevRoad()
    {
        PrevGameObject(_road, ref PlayerResurs.RoadNow);
        setStateProduct(PlayerResurs.PlayerRoad, PlayerResurs.RoadNow, PlayerResurs.RoadChoise);
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

    void lvlState()
    {
        _progressLvlUp.fillAmount = ((float)PlayerResurs.SpeedUp % 2) / 2;
        if (PlayerResurs.SpeedUp < 30)
            _priceLvl = (int)((PlayerResurs.SpeedUp - 21) * 2);
        else if (PlayerResurs.SpeedUp >= 30 && PlayerResurs.SpeedUp < 42)
            _priceLvl = (int)((PlayerResurs.SpeedUp - 21) * 4);
        else if (PlayerResurs.SpeedUp >= 42 && PlayerResurs.SpeedUp < 54)
            _priceLvl = (int)((PlayerResurs.SpeedUp - 21) * 6);
        else if (PlayerResurs.SpeedUp >= 54 && PlayerResurs.SpeedUp < 64)
            _priceLvl = (int)((PlayerResurs.SpeedUp - 21) * 10);
        else
            _priceLvl = (int)((PlayerResurs.SpeedUp - 21) * 12);
        _rewardAds = _priceLvl * 2;
        if (_priceLvl >= 500 && _priceLvl < 1000)
        {
            _priceLvlUp.text = _priceLvl.ToString();
            _priceVideoShow.text = "+" + (_rewardAds / 1000d).ToString("F2") + "k";
        }
        else if (_priceLvl >= 1000 && _priceLvl < 10000)
        {
            _priceLvlUp.text = (_priceLvl / 1000d).ToString("F2") + "k";
            _priceVideoShow.text = "+" + (_rewardAds / 1000d).ToString("F2") + "k";
        }
        else if (_priceLvl >= 10000)
        {
            _priceLvlUp.text = (_priceLvl / 1000).ToString("F1") + "k";
            _priceVideoShow.text = "+" + (_rewardAds / 1000).ToString("F1") + "k";
        }
        else
        {
            _priceLvlUp.text = _priceLvl.ToString();
            _priceVideoShow.text = "+" + _rewardAds;
        }

        _playersGold.text = PlayerResurs.Golds.ToString();

    }
    public void BuyLvl()
    {
        if (PlayerResurs.Golds >= _priceLvl)
        {
            PlayerResurs.Golds -= _priceLvl;
            changeCar.SpeedTrigger(20);
            lvlState();
            Buy();
            if (PlayerResurs.SpeedUp == 24 ||
                PlayerResurs.SpeedUp == 28 ||
                PlayerResurs.SpeedUp == 36 ||
                PlayerResurs.SpeedUp == 44 ||
                PlayerResurs.SpeedUp == 52 ||
                PlayerResurs.SpeedUp == 62 ||
                PlayerResurs.SpeedUp == 72 ||
                PlayerResurs.SpeedUp == 82)
                _goRaceWindow.SetActive(true);
        }

    }

    public void CloseGoRace()
    {
        _goRaceWindow.SetActive(false);
    }

    void CheckStateWindow()
    {
        if (_shopWindow[ShopWindowNow].name.Contains("Wheel"))
        {
            setStateProduct(PlayerResurs.PlayerWheel, PlayerResurs.WheelNow, PlayerResurs.WheelChoise);
            if (PlayerResurs.CarWheelChoise[changeWheel.carNow] == 0)
                PlayerResurs.WheelNow = PlayerResurs.WheelChoise - 1;
            else
                PlayerResurs.WheelNow = PlayerResurs.CarWheelChoise[changeWheel.carNow] - 1;

            NextWheel();
        }
        if (_shopWindow[ShopWindowNow].name.Contains("Environment"))
        {
            setStateProduct(PlayerResurs.PlayerEnvironment, PlayerResurs.EnvironmentNow, PlayerResurs.EnvironmentChoise);
            PlayerResurs.EnvironmentNow = PlayerResurs.EnvironmentChoise - 1;
            NextEnvironment();
        }
        if (_shopWindow[ShopWindowNow].name.Contains("Sky"))
        {
            setStateProduct(PlayerResurs.PlayerSky, PlayerResurs.SkyNow, PlayerResurs.SkyChoise);
            PlayerResurs.SkyNow = PlayerResurs.SkyChoise - 1;
            NextSky();
        }
        if (_shopWindow[ShopWindowNow].name.Contains("Barier"))
        {
            setStateProduct(PlayerResurs.PlayerBarier, PlayerResurs.BarierNow, PlayerResurs.BarierChoise);
            PlayerResurs.BarierNow = PlayerResurs.BarierChoise - 1;
            NextBarier();
        }
        if (_shopWindow[ShopWindowNow].name.Contains("Road"))
        {
            setStateProduct(PlayerResurs.PlayerRoad, PlayerResurs.RoadNow, PlayerResurs.RoadChoise);
            PlayerResurs.RoadNow = PlayerResurs.RoadChoise - 1;
            NextRoad();
        }
    }

    void StartShopingState()
    {
        PlayerResurs.WheelNow = PlayerResurs.WheelChoise;
        PlayerResurs.EnvironmentNow = PlayerResurs.EnvironmentChoise;
        PlayerResurs.RoadNow = PlayerResurs.RoadChoise;
        PlayerResurs.SkyNow = PlayerResurs.SkyChoise;
        PlayerResurs.BarierNow = PlayerResurs.BarierChoise;
        setStateProduct(PlayerResurs.PlayerSky, PlayerResurs.SkyNow, PlayerResurs.SkyChoise);
        setStateProduct(PlayerResurs.PlayerEnvironment, PlayerResurs.EnvironmentNow, PlayerResurs.EnvironmentChoise);
        setStateProduct(PlayerResurs.PlayerBarier, PlayerResurs.BarierNow, PlayerResurs.BarierChoise);
        setStateProduct(PlayerResurs.PlayerRoad, PlayerResurs.RoadNow, PlayerResurs.RoadChoise);
        setStateProduct(PlayerResurs.PlayerWheel, PlayerResurs.WheelNow, PlayerResurs.WheelChoise);
        ActiveObject(_environment, ref PlayerResurs.EnvironmentNow);
        ActiveObject(_road, ref PlayerResurs.RoadNow);
        ActiveObject(_barier, ref PlayerResurs.BarierNow);
        RenderSettings.skybox = _skyBox[PlayerResurs.SkyNow];
        changeWheel.WheelNow();
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

    void Rewarded(int id)
    {

        if (id == 1)
        {
            PlayerResurs.Golds += _rewardAds;
            _playersGold.text = PlayerResurs.Golds.ToString();
        }


    }

    public void GetGoldReward()
    {
        YandexGame.RewVideoShow(1);
    }
}
