using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class GameManager1 : MonoBehaviour
{
    [SerializeField] GameObject _upgradeBoard;
    [SerializeField] GameObject _goldForLvl;
    [SerializeField] GameObject _sceneGun;
    [SerializeField] GameObject _shopGun;
    [SerializeField] GameObject _shopScene;
    [SerializeField] GameObject _buttonsLvl;
    [SerializeField] GameObject _numLvlButton;
    [SerializeField] GameObject _setting;
    [SerializeField] GameObject _bonusGold;
    [SerializeField] GameObject _review;
    [SerializeField] MoveGun _moveGun;
    [SerializeField] FinishScript _finish;
    [SerializeField] GameObject _donatWindow;
    [SerializeField] Text _lvlNow;
    ShopGunScene _shop;
    public static bool GameStart;
    SaveProgress1 _save;
    public static event Action StartAnim;
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
            PlayerResurs1.GoldForLvl *= 3;
            _finish._bonusGold.text = PlayerResurs1.GoldForLvl.ToString();
            GameObject VideoButton = GameObject.Find("VideoReward");
            VideoButton.SetActive(false);
        }

    }

    private void Start()
    {   
        _save = GetComponent<SaveProgress1>();
        GameStart = false;
        _shop = GetComponent<ShopGunScene>();
        //_carsAnimator = GameObject.Find("Cars").GetComponent<Animator>();
        _lvlNow.text = PlayerResurs1.lvlNow.ToString();
        PlayerResurs1.SpeedUpPlayer = PlayerResurs1.SpeedUp;
        if (PlayerResurs1.lvlNow > 4)
            _review.SetActive(true);
    }
    public void StartGame()
    {
        _buttonsLvl.SetActive(false);
        _numLvlButton.SetActive(false);
        GameStart = true;
        _moveGun.enabled = true;
       // _carsAnimator.enabled = false;
        _bonusGold.SetActive(true);
        _goldForLvl.SetActive(true);
        StartAnim?.Invoke();

        YandexGame.savesData.Golds = PlayerResurs1.Golds;
        SaveParamGuns();
        YandexGame.SaveProgress();
        Debug.Log(PlayerResurs1.Gun0[0]);
    }

    

    public void VideoReward()
    {
        YandexGame.RewVideoShow(2);
        
    }

    public void NextLvl()
    {
        PlayerResurs1.Golds += PlayerResurs1.GoldForLvl;
        PlayerResurs1.lvlNow++;
        _save.EndGame();
        YandexGame.NewLeaderboardScores(SceneManager.GetActiveScene().name, PlayerResurs1.lvlNow);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

  
    public void OpenGarage()
    {
        YandexGame.savesData.Golds = PlayerResurs1.Golds;
        YandexGame.savesData.SpeedUp = PlayerResurs1.SpeedUp;
        YandexGame.SaveProgress();
        SceneManager.LoadScene(1);
    }
    public void RefreshLvl()
    {
        PlayerResurs1.SpeedUp = PlayerResurs1.SpeedUpPlayer;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void ChoiseLvl(int value)
    {
        YandexGame.savesData.Golds = PlayerResurs1.Golds;
        YandexGame.savesData.SpeedUp = PlayerResurs1.SpeedUp;
        YandexGame.SaveProgress();
        
        SceneManager.LoadScene(2 + value);
    }

    

    public void OpenShop()
    {
        _shopGun.SetActive(true);
        _shopScene.SetActive(true);
        _upgradeBoard.SetActive(false);
        _sceneGun.SetActive(false);
        _buttonsLvl.SetActive(false);
    }

    public void CloseShop()
    {
        _shopGun.SetActive(false);
        _shop.CloseShop();
        _upgradeBoard.SetActive(true);
        _sceneGun.SetActive(true);
        _shopScene.SetActive(false);
        _buttonsLvl.SetActive(true);
        _shop.ShopWindowNow = 0;
        _shop.lvlState();
        if (PlayerResurs1.lvlNow == 1 && PlayerResurs1.Help)
        {
            GameObject.Find("Help").GetComponent<Help>().Help0();
            PlayerResurs1.Help = false;
            YandexGame.savesData.Help = false;
        }
        _save.SaveShop();
    }

    public void OpenSetting()
    {
        _setting.SetActive(true);
    }

    public void OpenDonatMenu()
    {
        _donatWindow.SetActive(true);
        _buttonsLvl.SetActive(false);
    }

    public void CloseDonatMenu()
    {
        _donatWindow.SetActive(false);
    }
    
    void SaveParamGuns()
    {
        for (int i = 0; i < 3; i++)
        {
            YandexGame.savesData.Gun0[i] = PlayerResurs1.Gun0[i];
            YandexGame.savesData.Gun1[i] = PlayerResurs1.Gun1[i];
            YandexGame.savesData.Gun2[i] = PlayerResurs1.Gun2[i];
            YandexGame.savesData.Gun3[i] = PlayerResurs1.Gun3[i];
            YandexGame.savesData.Gun4[i] = PlayerResurs1.Gun4[i];
            YandexGame.savesData.Gun5[i] = PlayerResurs1.Gun5[i];
            YandexGame.savesData.Gun6[i] = PlayerResurs1.Gun6[i];
        }
        
    }
}
