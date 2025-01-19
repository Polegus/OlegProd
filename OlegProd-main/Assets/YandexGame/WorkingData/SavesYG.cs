
using System.Collections.Generic;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];



        // Ваши сохранения
        public bool Help = true;
        public float Record = 0;
        public int Golds = 120;
        public int Almaz = 0;
        public int lvlNow = 1;
        public List<string> GarageObj = new List<string>();

        public List<int> PlayerWheel = new List<int>() ;
        public List<int> PlayerGuns = new List<int>() ;
        public List<int> PlayerEnvironment = new List<int>() ;
        public List<int> PlayerRoad = new List<int>();
        public List<int> PlayerBarier = new List<int>();
        public List<int> PlayerSky = new List<int>();
        public List<int> Gun0 = new List<int>();
        public List<int> Gun1 = new List<int>();
        public List<int> Gun2 = new List<int>();
        public List<int> Gun3 = new List<int>();
        public List<int> Gun4 = new List<int>();
        public List<int> Gun5 = new List<int>();
        public List<int> Gun6 = new List<int>();
        public Dictionary<int, int> GradeRace = new Dictionary<int, int>();

        public Dictionary<int, int> RaceResults = new Dictionary<int, int>();

        public double SpeedUp = 22;

        public int WheelNow = 0;
        public int WheelChoise = 0;
        public int GunNow = 0;
        public int GunChoise = -1;
        public int EnvironmentNow = 0;
        public int RoadNow = 0;
        public int SkyNow = 0;
        public int BarierNow = 0;
        public int EnvironmentChoise = 0;
        public int RoadChoise = 0;
        public int SkyChoise = 0;
        public int BarierChoise = 0;
        public int LvlMax = 1;

        public bool volumeState = true;
        public bool musicState = true;

        public List<List<int>> ColorsCar = new List<List<int>>();
        public List<int> ColorCarChoise = new List<int>();


        public List<int> CarWheelChoise = new List<int>();

        public List<List<int>> LightCar = new List<List<int>>();
        public List<int> CarLightChoise = new List<int>();

        public List<int> SceneFruits = new List<int>();
        public List<float> SceneFruitsPositions = new List<float>();
        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            openLevels[1] = true;
        }
    }
}
