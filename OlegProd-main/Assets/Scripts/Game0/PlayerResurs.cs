using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResurs : MonoBehaviour
{
    public static int Golds = 300;
    public static int Almaz = 100;
    public static int GoldForLvl = 0;
    public static int lvlNow = 15;
    public static List<string> GarageObj = new List<string>();

    public static List<int> PlayerWheel = new List<int>() ;
    public static List<int> PlayerEnvironment = new List<int>() ;
    public static List<int> PlayerRoad = new List<int>() ;
    public static List<int> PlayerBarier = new List<int>() ;
    public static List<int> PlayerSky = new List<int>() ;
    public static Dictionary<int, int> GradeRace = new Dictionary<int, int>();

    public static Dictionary<int, int> RaceResults = new Dictionary<int, int>();

    public static double SpeedUp = 22;
    public static double SpeedUpPlayer = 22;

    public static int WheelNow = 0;
    public static int WheelChoise = 0;

    public static int EnvironmentNow = 0;
    public static int RoadNow = 0;
    public static int SkyNow = 0;
    public static int BarierNow = 0;
    public static int EnvironmentChoise = 0;
    public static int RoadChoise = 0;
    public static int SkyChoise = 0;
    public static int BarierChoise = 0;
    public static int LvlMax = 1;

    public static List<List<int>> ColorsCar = new List<List<int>>();
    public static List<int> ColorCarChoise = new List<int>()
    {
        0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
    };

    
    public static List<int> CarWheelChoise = new List<int>()
    {
        0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
    };

    public static List<List<int>> LightCar = new List<List<int>>();
    public static List<int> CarLightChoise = new List<int>()
    {
        0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
    };
}

