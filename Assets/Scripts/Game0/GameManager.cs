using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _shopScene;
    [SerializeField] GameObject _buttonsLvl;
    [SerializeField] GameObject _refreshButton;
    [SerializeField] GameObject _lvlMenu;
    [SerializeField] GameObject _setting;
    [SerializeField] GameObject _bonusGold;
    [SerializeField] GameObject _review;
    [SerializeField] GameObject _donatWindow;
    [SerializeField] Text _lvlNow;
    Shop _shop;
    public static bool GameStart;
    Animator _carsAnimator;
    SaveProgress _save;
    public static int RewVideoInt;


    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }

    // Отписываемся от события открытия рекламы в OnDisable
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }
    void Rewarded(int id)
    {

        if (id == 2)
        {
            PlayerResurs.GoldForLvl *= 3;
            RewVideoInt *= 3;
            GameObject VideoButton = GameObject.Find("VideoReward");
            VideoButton.SetActive(false);
        }

    }

    private void Start()
    {   
        _save = GetComponent<SaveProgress>();
        GameStart = false;
        _shop = GetComponent<Shop>();
        _carsAnimator = GameObject.Find("Cars").GetComponent<Animator>();
        _lvlNow.text = PlayerResurs.lvlNow.ToString();
        PlayerResurs.SpeedUpPlayer = PlayerResurs.SpeedUp;
        RewVideoInt = PlayerResurs.lvlNow;
        if (PlayerResurs.lvlNow > 4)
            _review.SetActive(true);
    }
    public void StartGame()
    {
        _buttonsLvl.SetActive(false);
        _refreshButton.SetActive(true);
        GameStart = true;
      //  _carsAnimator.enabled = false;
        _bonusGold.SetActive(true);
        PlayerResurs.SpeedUpPlayer = PlayerResurs.SpeedUp;

        YandexGame.savesData.Golds = PlayerResurs.Golds;
        YandexGame.savesData.SpeedUp = PlayerResurs.SpeedUp;
        YandexGame.SaveProgress();
    }
    
    public void VideoReward()
    {
        YandexGame.RewVideoShow(2);
        
    }

    public void NextLvl()
    {
        PlayerResurs.SpeedUp = PlayerResurs.SpeedUpPlayer;
        PlayerResurs.Golds += (RewVideoInt + PlayerResurs.GoldForLvl) * DriveCar.Bonus;
        PlayerResurs.lvlNow++;
       // _save.EndGame();
       /* if (PlayerResurs.lvlNow > PlayerResurs.LvlMax)
            YandexGame.NewLeaderboardScores(SceneManager.GetActiveScene().name, PlayerResurs.lvlNow);*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void GoRace()
    {
        YandexGame.savesData.Golds = PlayerResurs.Golds;
        YandexGame.savesData.SpeedUp = PlayerResurs.SpeedUp;
       // YandexGame.SaveProgress();
        if (PlayerResurs.SpeedUp < 26)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
        if (PlayerResurs.SpeedUp >= 26 && PlayerResurs.SpeedUp < 30)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        if (PlayerResurs.SpeedUp >= 30 && PlayerResurs.SpeedUp < 38)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        if (PlayerResurs.SpeedUp >= 38 && PlayerResurs.SpeedUp < 50)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
        if (PlayerResurs.SpeedUp >= 50 && PlayerResurs.SpeedUp < 60)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
        if (PlayerResurs.SpeedUp >= 60 && PlayerResurs.SpeedUp < 70)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
        if (PlayerResurs.SpeedUp >= 70 && PlayerResurs.SpeedUp < 80)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 8);
        if (PlayerResurs.SpeedUp >= 80)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 9);


    }
    public void OpenGarage()
    {
        YandexGame.savesData.Golds = PlayerResurs.Golds;
        YandexGame.savesData.SpeedUp = PlayerResurs.SpeedUp;
        YandexGame.SaveProgress();
        SceneManager.LoadScene(1);
    }
    public void RefreshLvl()
    {
        PlayerResurs.SpeedUp = PlayerResurs.SpeedUpPlayer;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void ChoiseLvl(int value)
    {
        YandexGame.savesData.Golds = PlayerResurs.Golds;
        YandexGame.savesData.SpeedUp = PlayerResurs.SpeedUp;
        YandexGame.SaveProgress();
        
        SceneManager.LoadScene(2 + value);
    }

    public void OpenLvlMenu()
    {
        _lvlMenu.SetActive(true);
        _buttonsLvl.SetActive(false);
    }

    public void CloselvlMenu()
    {
        _lvlMenu.SetActive(false);
        _buttonsLvl.SetActive(true);
    }

    public void OpenDonatMenu()
    {
        _donatWindow.SetActive(true);
        _buttonsLvl.SetActive(false);
    }

    public void CloseDonatMenu()
    {
        _donatWindow.SetActive(false);
        _buttonsLvl.SetActive(true);
    }
    public void OpenShop()
    {
        _shopScene.SetActive(true);
        _buttonsLvl.SetActive(false);
        _carsAnimator.SetBool("Shop", true);
    }

    public void CloseShop()
    {
        _shop.CloseShop();
        _shopScene.SetActive(false);
        _buttonsLvl.SetActive(true);
        _shop.ShopWindowNow = 0;
        _carsAnimator.SetBool("Shop", false);
        _save.SaveShop();
    }

    public void OpenSetting()
    {
        _setting.SetActive(true);
    }
}
