using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResurs1 : MonoBehaviour
{
    public static float Record = 0;
    public static int Golds = 120;
    public static bool Help = true;
    
    public static int Almaz = 300;
    public static int GoldForLvl = 0;
    public static int lvlNow = 1;




    public static List<string> GarageObj = new List<string>();

    public static List<int> Gun0 = new List<int>() {0,0,0};
    public static List<int> Gun1 = new List<int>() {0,0,0};
    public static List<int> Gun2 = new List<int>() {0,0,0};
    public static List<int> Gun3 = new List<int>() {0,0,0};
    public static List<int> Gun4 = new List<int>() {0,0,0};
    public static List<int> Gun5 = new List<int>() {0,0,0};
    public static List<int> Gun6 = new List<int>() {0,0,0};

    public static List<int> PlayerGuns = new List<int>() ;
    public static List<int> PlayerEnvironment = new List<int>() ;
    public static List<int> PlayerRoad = new List<int>() ;
    public static List<int> PlayerBarier = new List<int>() ;
    public static List<int> PlayerSky = new List<int>() ;
    public static Dictionary<int, int> GradeRace = new Dictionary<int, int>();

    public static Dictionary<int, int> RaceResults = new Dictionary<int, int>();

    public static double SpeedUp = 22;
    public static double SpeedUpPlayer = 22;

    public static int GunNow = 0;
    public static int GunChoise = -1;

    public static int EnvironmentNow = 0;
    public static int RoadNow = 0;
    public static int SkyNow = 0;
    public static int BarierNow = 0;
    public static int EnvironmentChoise = 0;
    public static int RoadChoise = 0;
    public static int SkyChoise = 0;
    public static int BarierChoise = 0;
    public static int LvlMax = 1;
    public static float MaxDistance = 30;

    public static List<int> SceneFruits = new List<int>();
    public static List<float> SceneFruitsPositions = new List<float>();
}

