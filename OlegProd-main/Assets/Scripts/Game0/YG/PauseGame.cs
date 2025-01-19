using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject _menu;
    [SerializeField] GameObject[] _lvlMusic;
    [SerializeField] GameObject[] _volume;
    [SerializeField] GameObject _refreshWindow;

    public static bool volumeState = true;
    public static bool musicState = true;

    

    private void Start()
    {
        
        stateIcons();
    }
    public void OpenMenu()
    {
        _menu.SetActive(true);
    }

    public void CloseMenu()
    {
        YandexGame.savesData.volumeState = volumeState;
        YandexGame.savesData.musicState = musicState;
        YandexGame.SaveProgress();
        _menu.SetActive(false);
    }

    void stateIcons()
    {

        /*if (!musicState)
        {
            _lvlMusic[1].SetActive(true);
            _lvlMusic[0].SetActive(false);
         //   _lvlMusic[2].SetActive(false);
        }
        else
        {
            _lvlMusic[0].SetActive(true);
            _lvlMusic[1].SetActive(false);
     //       _lvlMusic[2].SetActive(true);
        }*/

        if (!volumeState)
        {
            _volume[1].SetActive(true);
            _volume[0].SetActive(false);
            AudioListener.volume = 0;

        }
        else
        {
            _volume[0].SetActive(true);
            _volume[1].SetActive(false);
            AudioListener.volume = 1f;
        }
    }

    public void MusicManager()
    {
        if (musicState)
        {
            musicState = false;
            _lvlMusic[1].SetActive(true);
            _lvlMusic[0].SetActive(false);
         //   _lvlMusic[2].SetActive(false);
        }
        else
        {
            musicState = true;
            _lvlMusic[0].SetActive(true);
            _lvlMusic[1].SetActive(false);
        //    _lvlMusic[2].SetActive(true);
        }
    }

    public void VolumeManager()
    {

        if (volumeState)
        {
            volumeState = false;
            _volume[1].SetActive(true);
            _volume[0].SetActive(false);
            AudioListener.volume = 0;
        }
        else
        {
            volumeState = true;
            _volume[0].SetActive(true);
            _volume[1].SetActive(false);
            AudioListener.volume = 1;
        }

    }

  

    public void Refresh()
    {
        YandexGame.savesData.volumeState = volumeState;
        YandexGame.savesData.musicState = musicState;
        YandexGame.SaveProgress();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /*public void NextLvl()
    {
        YandexGame.savesData.PlayerGold = PlayerResurs.PlayerGold;
        YandexGame.savesData.MaxLvl = PlayerResurs.MaxLvl;
        YandexGame.savesData.BestRes = PlayerResurs.BestRes;
        YandexGame.SaveProgress();
        if (PlayerResurs.BestRes == 2)
            SceneManager.LoadScene("1");
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }*/

    public void OpenAdd()
    {
        YandexGame.RewVideoShow(0);
    }

    public void OpenRefreshWindow()
    {
        _refreshWindow.SetActive(true);
    }

    public void CloseRefreshWindow()
    {
        _refreshWindow.SetActive(false);
    }

    public void RefreshGame()
    {
        YandexGame.savesData.Golds = 0;
        YandexGame.savesData.lvlNow = 1;

        YandexGame.savesData.GarageObj.Clear();
        //YandexGame.savesData.GarageCar = PlayerResurs.GarageCar;

        YandexGame.savesData.PlayerWheel.Clear();
        YandexGame.savesData.PlayerEnvironment.Clear();
        YandexGame.savesData.PlayerRoad.Clear();
        YandexGame.savesData.PlayerBarier.Clear();
        YandexGame.savesData.PlayerSky.Clear();

        YandexGame.savesData.GradeRace.Clear();
        YandexGame.savesData.RaceResults.Clear();

        YandexGame.savesData.SpeedUp = 22;

        YandexGame.savesData.WheelNow = 0;
        YandexGame.savesData.WheelChoise = 0;
        YandexGame.savesData.EnvironmentNow = 0;
        YandexGame.savesData.RoadNow = 0;
        YandexGame.savesData.SkyNow = 0;
        YandexGame.savesData.BarierNow = 0;
        YandexGame.savesData.EnvironmentChoise = 0;
        YandexGame.savesData.RoadChoise = 0;
        YandexGame.savesData.SkyChoise = 0;
        YandexGame.savesData.BarierChoise = 0;
        YandexGame.savesData.ColorsCar.Clear();
        YandexGame.savesData.ColorCarChoise.Clear();
        YandexGame.savesData.CarWheelChoise.Clear();
        YandexGame.savesData.LightCar.Clear();
        YandexGame.savesData.CarLightChoise.Clear();
        YandexGame.SaveProgress();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
