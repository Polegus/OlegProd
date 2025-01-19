using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;
using YG.Utils.LB;

public class RecordLvl : MonoBehaviour
{
    [SerializeField] GameObject _bestRes;
    [SerializeField] Text _numberPlayer;

    // Start is called before the first frame update
    void Start()
    {
        YandexGame.GetLeaderboard(SceneManager.GetActiveScene().name, 100000, 3, 3, "small");
    }
    private void OnEnable()
    {
        
        YandexGame.onGetLeaderboard += OnGetLeaderboard;
    }
    private void OnDisable()
    {
        YandexGame.onGetLeaderboard -= OnGetLeaderboard;
    }

    private void OnGetLeaderboard(LBData lb)
    {
        // Сверяем имя лидерборда

        if (lb.technoName == SceneManager.GetActiveScene().name)
        {
            if (lb.thisPlayer != null)
            {
                _bestRes.SetActive(true);
                _numberPlayer.text = lb.thisPlayer.rank.ToString();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
