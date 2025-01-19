using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class GarageManager : MonoBehaviour
{
    [SerializeField] Text _playerGolds;
    // Start is called before the first frame update
    void Start()
    {
        _playerGolds.text = PlayerResurs.Golds.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void BuyProduct(int price, GarageManager garageManager)
    {
        PlayerResurs.Golds -= price;
        garageManager._playerGolds.text = PlayerResurs.Golds.ToString();
    } 

    public void OpenRace()
    {
        YandexGame.savesData.Golds = PlayerResurs.Golds;
        YandexGame.savesData.GarageObj = PlayerResurs.GarageObj;
        YandexGame.SaveProgress();
        SceneManager.LoadScene(0);
    }
}
