using System.Collections.Generic;
using UnityEngine;
using YG;

public class SaveProgress : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;


    bool SaveDragons = false;
    private void Awake()
    {
        if (YandexGame.SDKEnabled)

            GetLoad();



    }

    private void Update()
    {

    }
    public void Save()
    {
        YandexGame.savesData.Golds = PlayerResurs.Golds;
        PlayerResurs.Almaz = YandexGame.savesData.Almaz;
        YandexGame.savesData.lvlNow = PlayerResurs.lvlNow;

        YandexGame.savesData.GarageObj = PlayerResurs.GarageObj;
        //YandexGame.savesData.GarageCar = PlayerResurs.GarageCar;

        YandexGame.savesData.PlayerWheel = PlayerResurs.PlayerWheel;
        YandexGame.savesData.PlayerEnvironment = PlayerResurs.PlayerEnvironment;
        YandexGame.savesData.PlayerRoad = PlayerResurs.PlayerRoad;
        YandexGame.savesData.PlayerBarier = PlayerResurs.PlayerBarier;
        YandexGame.savesData.PlayerSky = PlayerResurs.PlayerSky;

        YandexGame.savesData.GradeRace = PlayerResurs.GradeRace;
        YandexGame.savesData.RaceResults = PlayerResurs.RaceResults;

        YandexGame.savesData.SpeedUp = PlayerResurs.SpeedUp;

        YandexGame.savesData.WheelNow = PlayerResurs.WheelNow;
        YandexGame.savesData.WheelChoise = PlayerResurs.WheelChoise;
        YandexGame.savesData.EnvironmentNow = PlayerResurs.EnvironmentNow;
        YandexGame.savesData.RoadNow = PlayerResurs.RoadNow;
        YandexGame.savesData.SkyNow = PlayerResurs.SkyNow;
        YandexGame.savesData.BarierNow = PlayerResurs.BarierNow;
        YandexGame.savesData.EnvironmentChoise = PlayerResurs.EnvironmentChoise;
        YandexGame.savesData.RoadChoise = PlayerResurs.RoadChoise;
        YandexGame.savesData.SkyChoise = PlayerResurs.SkyChoise;
        YandexGame.savesData.BarierChoise = PlayerResurs.BarierChoise;
        YandexGame.savesData.LvlMax = PlayerResurs.LvlMax;

        YandexGame.savesData.volumeState = PauseGame.volumeState;
        YandexGame.savesData.musicState = PauseGame.musicState;
        YandexGame.SaveProgress();
    }

    public void SaveShop()
    {
        YandexGame.savesData.Golds = PlayerResurs.Golds;
        YandexGame.savesData.Almaz = PlayerResurs.Almaz;
        YandexGame.savesData.PlayerWheel = PlayerResurs.PlayerWheel;
        YandexGame.savesData.PlayerEnvironment = PlayerResurs.PlayerEnvironment;
        YandexGame.savesData.PlayerRoad = PlayerResurs.PlayerRoad;
        YandexGame.savesData.PlayerBarier = PlayerResurs.PlayerBarier;
        YandexGame.savesData.PlayerSky = PlayerResurs.PlayerSky;
        YandexGame.savesData.WheelNow = PlayerResurs.WheelNow;
        YandexGame.savesData.WheelChoise = PlayerResurs.WheelChoise;
        YandexGame.savesData.EnvironmentNow = PlayerResurs.EnvironmentNow;
        YandexGame.savesData.RoadNow = PlayerResurs.RoadNow;
        YandexGame.savesData.SkyNow = PlayerResurs.SkyNow;
        YandexGame.savesData.BarierNow = PlayerResurs.BarierNow;
        YandexGame.savesData.EnvironmentChoise = PlayerResurs.EnvironmentChoise;
        YandexGame.savesData.RoadChoise = PlayerResurs.RoadChoise;
        YandexGame.savesData.SkyChoise = PlayerResurs.SkyChoise;
        YandexGame.savesData.BarierChoise = PlayerResurs.BarierChoise;
        YandexGame.savesData.SpeedUp = PlayerResurs.SpeedUp;
        YandexGame.SaveProgress();
    }
    
    public void EndGame()
    {
        YandexGame.savesData.Golds = PlayerResurs.Golds;
        YandexGame.savesData.lvlNow = PlayerResurs.lvlNow;
        YandexGame.SaveProgress();
    }


    public void Load() => YandexGame.LoadProgress();
    public void GetLoad()
    {

        PlayerResurs.Golds = YandexGame.savesData.Golds;
        PlayerResurs.Almaz = YandexGame.savesData.Almaz;
        PlayerResurs.lvlNow = YandexGame.savesData.lvlNow;

        PlayerResurs.GarageObj = YandexGame.savesData.GarageObj;

        PlayerResurs.PlayerWheel = YandexGame.savesData.PlayerWheel;
        PlayerResurs.PlayerEnvironment = YandexGame.savesData.PlayerEnvironment;
        PlayerResurs.PlayerRoad = YandexGame.savesData.PlayerRoad;
        PlayerResurs.PlayerBarier = YandexGame.savesData.PlayerBarier;
        PlayerResurs.PlayerSky = YandexGame.savesData.PlayerSky;

        PlayerResurs.GradeRace = YandexGame.savesData.GradeRace;
        PlayerResurs.RaceResults = YandexGame.savesData.RaceResults;

        PlayerResurs.SpeedUp = YandexGame.savesData.SpeedUp;

        PlayerResurs.WheelNow = YandexGame.savesData.WheelNow;
        PlayerResurs.WheelChoise = YandexGame.savesData.WheelChoise;
        PlayerResurs.EnvironmentNow = YandexGame.savesData.EnvironmentNow;
        PlayerResurs.RoadNow = YandexGame.savesData.RoadNow;
        PlayerResurs.SkyNow = YandexGame.savesData.SkyNow;
        PlayerResurs.BarierNow = YandexGame.savesData.BarierNow;
        PlayerResurs.EnvironmentChoise = YandexGame.savesData.EnvironmentChoise;
        PlayerResurs.RoadChoise = YandexGame.savesData.RoadChoise;
        PlayerResurs.SkyChoise = YandexGame.savesData.SkyChoise;
        PlayerResurs.BarierChoise = YandexGame.savesData.BarierChoise;
        PlayerResurs.LvlMax = YandexGame.savesData.LvlMax;

        PauseGame.volumeState = YandexGame.savesData.volumeState;
        PauseGame.musicState = YandexGame.savesData.musicState;

        if (PlayerResurs.PlayerWheel.Count < 1)
        {
            PlayerResurs.PlayerWheel = new List<int>() { 0 };
            PlayerResurs.PlayerEnvironment = new List<int>() { 0 };
            PlayerResurs.PlayerRoad = new List<int>() { 0 };
            PlayerResurs.PlayerBarier = new List<int>() { 0 };
            PlayerResurs.PlayerSky = new List<int>() { 0 };
        }

        StateShopObj(PlayerResurs.ColorsCar, YandexGame.savesData.ColorsCar);
        StateShopObj(PlayerResurs.LightCar, YandexGame.savesData.LightCar);
        StateChoiseObj(PlayerResurs.ColorCarChoise, YandexGame.savesData.ColorCarChoise);
        StateChoiseObj(PlayerResurs.CarLightChoise, YandexGame.savesData.CarLightChoise);
        StateChoiseObj(PlayerResurs.CarWheelChoise, YandexGame.savesData.CarWheelChoise);

    }

    void StateShopObj(List<List<int>> ObjPlayer, List<List<int>> ObjYandexSave)
    {
        if (ObjYandexSave.Count < 36)
            for (int i = 0; i < 36; i++)
            {
                ObjYandexSave.Add(new List<int>() { 0 });
            }
        if (ObjPlayer.Count < 36)
            for (int i = 0; i < 36; i++)
            {
                ObjPlayer.Add(new List<int>() { 0 });
            }
        else
            for (int i = 0; i < 36; i++)
            {
                ObjPlayer[i] = ObjYandexSave[i];
            }
    }
    void StateChoiseObj(List<int> ObjPlayer, List<int> ObjYandexSave)
    {
        if (ObjYandexSave.Count >= 36)
            for (int i = 0; i < 36; i++)
            {
                ObjPlayer[i] = ObjYandexSave[i];
            }
        else
            for (int i = 0; i < 36; i++)
            {
                ObjYandexSave.Add( 0 );
            }
    }

    /*private void GetChildRecursive(GameObject obj)
    {
        if (null == obj)
            return;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
                continue;
            if (child.gameObject.name.Contains("(Clone)"))
                //child.gameobject contains the current child you can do whatever you want like add it to an array\
                for (int i = 0; i < 44; i++)
                {
                    if (child.gameObject.name == "Gun" + i + "(Clone)")
                    {
                        YandexGame.savesData.SceneFruits.Add(i);
                        YandexGame.savesData.SceneFruitsPositions.Add(child.gameObject.transform.position.x);
                        YandexGame.savesData.SceneFruitsPositions.Add(child.gameObject.transform.position.y);
                        YandexGame.savesData.SceneFruitsPositions.Add(child.gameObject.transform.position.z);
                    }

                }

            GetChildRecursive(child.gameObject);
        }
    }*/


    /* void LoadScene()
     {
         for (int i = 0; i < YandexGame.savesData.SceneFruits.Count; i++)
         {

             PlayerResurs.SceneFruits.Add(YandexGame.savesData.SceneFruits[i]);

         }
         for (int i = 0; i < YandexGame.savesData.SceneFruitsPositions.Count; i++)
         {

             PlayerResurs.SceneFruitsPositions.Add(YandexGame.savesData.SceneFruitsPositions[i]);

         }
     }*/

    /* void InstantiateObj()
     {
         for (int i = 0; i < PlayerResurs.SceneFruits.Count; i++)
         {

             Instantiate(_savesFruitsPref[PlayerResurs.SceneFruits[i]], new Vector3(PlayerResurs.SceneFruitsPositions[i * 3], PlayerResurs.SceneFruitsPositions[i * 3 + 1], PlayerResurs.SceneFruitsPositions[i * 3 + 2]), Quaternion.identity, _bascet.transform);


         }
     }*/
    void getParamGame(Dictionary<string, float> valueYG, Dictionary<string, float> valueMC)
    {
        for (int i = 0; i < valueMC.Count; i++)
        {
            valueYG["Gun" + i.ToString()] = valueMC["Gun" + i.ToString()];
        }
    }


}
