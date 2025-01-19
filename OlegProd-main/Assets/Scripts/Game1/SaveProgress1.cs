using System.Collections.Generic;
using UnityEngine;
using YG;

public class SaveProgress1 : MonoBehaviour
{
    [SerializeField] GameObject _bascet;
    [SerializeField] GameObject[] _savesFruitsPref;
    [SerializeField] List<string> listOfChildren;
    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;


    bool SaveDragons = false;
    private void Awake()
    {
        PlayerResurs1.GoldForLvl = 0;
        CFXGame1.QuantityEffect = 0;
        CFXGame1.AllEffect = 0;
        CFXGame1.destroyEffect = 0;
        if (YandexGame.SDKEnabled)
            GetLoad();



    }

    private void Update()
    {
        if (GameManager1.GameStart)
        {
            if (!SaveDragons)
            {
                GetChildRecursive(_bascet);
                YandexGame.SaveProgress();
                SaveDragons = true;
            }


        }

    }
    public void Save()
    {
        YandexGame.savesData.Golds = PlayerResurs1.Golds;
        PlayerResurs1.Almaz = YandexGame.savesData.Almaz;
        YandexGame.savesData.lvlNow = PlayerResurs1.lvlNow;

        YandexGame.savesData.GarageObj = PlayerResurs1.GarageObj;
        //YandexGame.savesData.GarageCar = PlayerResurs1.GarageCar;

        YandexGame.savesData.PlayerGuns = PlayerResurs1.PlayerGuns;
        YandexGame.savesData.PlayerEnvironment = PlayerResurs1.PlayerEnvironment;
        YandexGame.savesData.PlayerRoad = PlayerResurs1.PlayerRoad;
        YandexGame.savesData.PlayerBarier = PlayerResurs1.PlayerBarier;
        YandexGame.savesData.PlayerSky = PlayerResurs1.PlayerSky;

        YandexGame.savesData.GradeRace = PlayerResurs1.GradeRace;
        YandexGame.savesData.RaceResults = PlayerResurs1.RaceResults;

        YandexGame.savesData.SpeedUp = PlayerResurs1.SpeedUp;

        YandexGame.savesData.GunNow = PlayerResurs1.GunNow;
        YandexGame.savesData.GunChoise = PlayerResurs1.GunChoise;
        YandexGame.savesData.EnvironmentNow = PlayerResurs1.EnvironmentNow;
        YandexGame.savesData.RoadNow = PlayerResurs1.RoadNow;
        YandexGame.savesData.SkyNow = PlayerResurs1.SkyNow;
        YandexGame.savesData.BarierNow = PlayerResurs1.BarierNow;
        YandexGame.savesData.EnvironmentChoise = PlayerResurs1.EnvironmentChoise;
        YandexGame.savesData.RoadChoise = PlayerResurs1.RoadChoise;
        YandexGame.savesData.SkyChoise = PlayerResurs1.SkyChoise;
        YandexGame.savesData.BarierChoise = PlayerResurs1.BarierChoise;
        YandexGame.savesData.LvlMax = PlayerResurs1.LvlMax;

        YandexGame.savesData.volumeState = PauseGame.volumeState;
        YandexGame.savesData.musicState = PauseGame.musicState;
        YandexGame.SaveProgress();
    }

    public void SaveShop()
    {
        YandexGame.savesData.Golds = PlayerResurs1.Golds;
        YandexGame.savesData.Almaz = PlayerResurs1.Almaz;
        YandexGame.savesData.PlayerGuns = PlayerResurs1.PlayerGuns;
        YandexGame.savesData.PlayerEnvironment = PlayerResurs1.PlayerEnvironment;
        YandexGame.savesData.PlayerRoad = PlayerResurs1.PlayerRoad;
        YandexGame.savesData.PlayerBarier = PlayerResurs1.PlayerBarier;
        YandexGame.savesData.PlayerSky = PlayerResurs1.PlayerSky;
        YandexGame.savesData.GunNow = PlayerResurs1.GunNow;
        YandexGame.savesData.GunChoise = PlayerResurs1.GunChoise;
        YandexGame.savesData.EnvironmentNow = PlayerResurs1.EnvironmentNow;
        YandexGame.savesData.RoadNow = PlayerResurs1.RoadNow;
        YandexGame.savesData.SkyNow = PlayerResurs1.SkyNow;
        YandexGame.savesData.BarierNow = PlayerResurs1.BarierNow;
        YandexGame.savesData.EnvironmentChoise = PlayerResurs1.EnvironmentChoise;
        YandexGame.savesData.RoadChoise = PlayerResurs1.RoadChoise;
        YandexGame.savesData.SkyChoise = PlayerResurs1.SkyChoise;
        YandexGame.savesData.BarierChoise = PlayerResurs1.BarierChoise;
        YandexGame.savesData.SpeedUp = PlayerResurs1.SpeedUp;
        YandexGame.SaveProgress();
    }

    public void EndGame()
    {
        YandexGame.savesData.Golds = PlayerResurs1.Golds;
        YandexGame.savesData.lvlNow = PlayerResurs1.lvlNow;
        YandexGame.SaveProgress();
    }


    public void Load() => YandexGame.LoadProgress();
    public void GetLoad()
    {
        LoadParamGuns();
        PlayerResurs1.Help = YandexGame.savesData.Help;
        PlayerResurs1.Record = YandexGame.savesData.Record;
        PlayerResurs1.Golds = YandexGame.savesData.Golds;
        PlayerResurs1.Almaz = YandexGame.savesData.Almaz;
        PlayerResurs1.lvlNow = YandexGame.savesData.lvlNow;

        PlayerResurs1.GarageObj = YandexGame.savesData.GarageObj;

        PlayerResurs1.PlayerGuns = YandexGame.savesData.PlayerGuns;
        PlayerResurs1.PlayerEnvironment = YandexGame.savesData.PlayerEnvironment;
        PlayerResurs1.PlayerRoad = YandexGame.savesData.PlayerRoad;
        PlayerResurs1.PlayerBarier = YandexGame.savesData.PlayerBarier;
        PlayerResurs1.PlayerSky = YandexGame.savesData.PlayerSky;

        PlayerResurs1.GradeRace = YandexGame.savesData.GradeRace;
        PlayerResurs1.RaceResults = YandexGame.savesData.RaceResults;

        PlayerResurs1.SpeedUp = YandexGame.savesData.SpeedUp;

        PlayerResurs1.GunNow = YandexGame.savesData.GunNow;
        PlayerResurs1.GunChoise = YandexGame.savesData.GunChoise;
        PlayerResurs1.EnvironmentNow = YandexGame.savesData.EnvironmentNow;
        PlayerResurs1.RoadNow = YandexGame.savesData.RoadNow;
        PlayerResurs1.SkyNow = YandexGame.savesData.SkyNow;
        PlayerResurs1.BarierNow = YandexGame.savesData.BarierNow;
        PlayerResurs1.EnvironmentChoise = YandexGame.savesData.EnvironmentChoise;
        PlayerResurs1.RoadChoise = YandexGame.savesData.RoadChoise;
        PlayerResurs1.SkyChoise = YandexGame.savesData.SkyChoise;
        PlayerResurs1.BarierChoise = YandexGame.savesData.BarierChoise;
        PlayerResurs1.LvlMax = YandexGame.savesData.LvlMax;

        PauseGame.volumeState = YandexGame.savesData.volumeState;
        PauseGame.musicState = YandexGame.savesData.musicState;

        if (PlayerResurs1.PlayerGuns.Count < 1)
        {
            PlayerResurs1.PlayerGuns = new List<int>();
            PlayerResurs1.PlayerEnvironment = new List<int>() { 0 };
            PlayerResurs1.PlayerRoad = new List<int>() { 0 };
            PlayerResurs1.PlayerBarier = new List<int>() { 0 };
            PlayerResurs1.PlayerSky = new List<int>() { 0 };
        }


        PlayerResurs1.SceneFruits.Clear();
        PlayerResurs1.SceneFruitsPositions.Clear();
        YandexGame.savesData.SceneFruits.Clear();
        YandexGame.savesData.SceneFruitsPositions.Clear();
    }


    private void GetChildRecursive(GameObject obj)
    {
        if (null == obj)
            return;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
                continue;
            if (child.gameObject.name.Contains("(Clone)"))
                //child.gameobject contains the current child you can do whatever you want like add it to an array\
                for (int i = 0; i < 10; i++)
                {
                    if (child.gameObject.name.Contains(i.ToString()))
                    {
                        YandexGame.savesData.SceneFruits.Add(i);
                        YandexGame.savesData.SceneFruitsPositions.Add(child.gameObject.transform.position.x);
                        YandexGame.savesData.SceneFruitsPositions.Add(child.gameObject.transform.position.y);
                        YandexGame.savesData.SceneFruitsPositions.Add(child.gameObject.transform.position.z);
                    }

                }

            GetChildRecursive(child.gameObject);
        }
    }


    

   
    void getParamGame(Dictionary<string, float> valueYG, Dictionary<string, float> valueMC)
    {
        for (int i = 0; i < valueMC.Count; i++)
        {
            valueYG["Turrel" + i.ToString()] = valueMC["Turrel" + i.ToString()];
        }
    }

    void LoadParamGuns()
    {
        if (YandexGame.savesData.Gun0.Count==0)
        {
            YandexGame.savesData.Gun0 = new List<int>() { 0, 0, 0 };
            YandexGame.savesData.Gun1 = new List<int>() { 0, 0, 0 };
            YandexGame.savesData.Gun2 = new List<int>() { 0, 0, 0 };
            YandexGame.savesData.Gun3 = new List<int>() { 0, 0, 0 };
            YandexGame.savesData.Gun4 = new List<int>() { 0, 0, 0 };
            YandexGame.savesData.Gun5 = new List<int>() { 0, 0, 0 };
            YandexGame.savesData.Gun6 = new List<int>() { 0, 0, 0 };
        }/*
        PlayerResurs1.Gun0.Clear();
        PlayerResurs1.Gun1.Clear();
        PlayerResurs1.Gun2.Clear();
        PlayerResurs1.Gun3.Clear();
        PlayerResurs1.Gun4.Clear();
        PlayerResurs1.Gun5.Clear();
        PlayerResurs1.Gun6.Clear();*/
        for (int i = 0; i < 3; i++)
        {
            PlayerResurs1.Gun0[i] = YandexGame.savesData.Gun0[i];
            PlayerResurs1.Gun1[i] = YandexGame.savesData.Gun1[i];
            PlayerResurs1.Gun2[i] = YandexGame.savesData.Gun2[i];
            PlayerResurs1.Gun3[i] = YandexGame.savesData.Gun3[i];
            PlayerResurs1.Gun4[i] = YandexGame.savesData.Gun4[i];
            PlayerResurs1.Gun5[i] = YandexGame.savesData.Gun5[i];
            PlayerResurs1.Gun6[i] = YandexGame.savesData.Gun6[i];
        }
        Debug.Log(PlayerResurs1.Gun0[0]);
    }
}
