using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class RaceManager : MonoBehaviour
{
    ChangeCar _changeCar;
    ChangeWheel _changeWheel;
    [SerializeField] GameObject _buttonsLvl;
    [SerializeField] GameObject _refreshButton;
    [SerializeField] GameObject _finishWindow;
    [SerializeField] GameObject _lvlNow;
    [SerializeField] Text _timePlayer;
    [SerializeField] Text _bestTimePlayer;
    [SerializeField] Text _goldForLvl;
    [SerializeField] float _timeForRace;
    [SerializeField] Animator _starsAnimator;
    [SerializeField] Animator _loseAnimator;
    Timer _timer;
    int _timeNow;
    Shop _shop;
    public static bool GameStart;
    SaveProgress _save;
    int changeReward = 1;
    private void Start()
    {
        _save = GetComponent<SaveProgress>();
        PlayerResurs.GoldForLvl = 0;
        PlayerResurs.SpeedUpPlayer = PlayerResurs.SpeedUp;
        GameStart = false;
        _timer = GameObject.Find("Timer").GetComponent<Timer>();
        _shop = GetComponent<Shop>();
        _changeCar = GameObject.Find("Cars").GetComponent<ChangeCar>();
        _changeWheel = GameObject.Find("Cars").GetComponent<ChangeWheel>();
        _refreshButton.SetActive(false);
        if (int.Parse(Regex.Replace(SceneManager.GetActiveScene().name, @"[^\d]", "")) > 3 && int.Parse(Regex.Replace(SceneManager.GetActiveScene().name, @"[^\d]", "")) < 7)
            changeReward = 2;
        else if (int.Parse(Regex.Replace(SceneManager.GetActiveScene().name, @"[^\d]", "")) >= 7 && int.Parse(Regex.Replace(SceneManager.GetActiveScene().name, @"[^\d]", "")) < 11)
            changeReward = 4;
        else if (int.Parse(Regex.Replace(SceneManager.GetActiveScene().name, @"[^\d]", "")) >= 11 && int.Parse(Regex.Replace(SceneManager.GetActiveScene().name, @"[^\d]", "")) < 16)
            changeReward = 6;
        else if (int.Parse(Regex.Replace(SceneManager.GetActiveScene().name, @"[^\d]", "")) >= 16)
            changeReward = 8;
    }


    private void Update()
    {
        if (_timer.TimeLeft > 5)
            _refreshButton.SetActive(true);
        if (GameStart)
            _timer.CountSecondTime();
    }


    public void StartGameRace()
    {

        _buttonsLvl.SetActive(false);
        GameStart = true;
        _lvlNow.SetActive(false);
    }

    public void NextCar()
    {
        if (PlayerResurs.SpeedUp <= YandexGame.savesData.SpeedUp)
        {
            _changeCar.SpeedTrigger(160);
            if (PlayerResurs.SpeedUp >= 92d)
            {
                PlayerResurs.SpeedUp = YandexGame.savesData.SpeedUp;
            }
        }
        if (PlayerResurs.SpeedUp >= YandexGame.savesData.SpeedUp)
        {
            PlayerResurs.SpeedUp = YandexGame.savesData.SpeedUp;
            _changeCar.SpeedTrigger(0);
        }

        _changeWheel.StartState();
    }
    public void PrevCar()
    {

        if (PlayerResurs.SpeedUp >= 92d)
        {
            PlayerResurs.SpeedUp = 91d;
            _changeCar.SpeedTrigger(0);
        }
        else if (PlayerResurs.SpeedUp <= 22)
        {
            PlayerResurs.SpeedUp = 22;
            _changeCar.SpeedTrigger(0);
        }
        else
            _changeCar.SpeedTrigger(-160);
        _changeWheel.StartState();
    }

    public void RefreshLvl()
    {
        PlayerResurs.Golds += PlayerResurs.GoldForLvl;
        YandexGame.savesData.Golds = PlayerResurs.Golds;
        YandexGame.SaveProgress();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitRace()
    {
        PlayerResurs.SpeedUp = YandexGame.savesData.SpeedUp;
        SceneManager.LoadScene(0);
    }
    public void ExitNextRace()
    {
        PlayerResurs.SpeedUp = YandexGame.savesData.SpeedUp;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Finish()
    {

        /*if (_timer._hardTimer)
        {
            _timeNow = _timer.TimeLeft / 100f;
            _timeForRace = _timeForRace / 100f;
        }
        else*/
        _timeNow = (int)_timer.TimeLeft;

        _finishWindow.SetActive(true);
        _timer.Finish = true;

        if (!PlayerResurs.GradeRace.ContainsKey(SceneManager.GetActiveScene().buildIndex - 2))
        {
            RewardsFinish();
        }
        else
        {
            if (PlayerResurs.RaceResults[SceneManager.GetActiveScene().buildIndex - 2] <= _timer.TimeLeft)
                RewardsFinish(PlayerResurs.GradeRace[SceneManager.GetActiveScene().buildIndex - 2]);
            else
            {
                PlayerResurs.RaceResults[SceneManager.GetActiveScene().buildIndex - 2] = (int)_timer.TimeLeft;
                YandexGame.NewLeaderboardScores(SceneManager.GetActiveScene().name, (int)_timer.TimeLeft);
                RewardsFinish(PlayerResurs.GradeRace[SceneManager.GetActiveScene().buildIndex - 2]);
            }

        }

        _goldForLvl.text = PlayerResurs.GoldForLvl.ToString();
        YandexGame.savesData.GradeRace = PlayerResurs.GradeRace;
        YandexGame.savesData.RaceResults = PlayerResurs.RaceResults;
        YandexGame.SaveProgress();

    }

    void RewardsFinish()
    {
        YandexGame.NewLeaderboardScores(SceneManager.GetActiveScene().name, (int)_timer.TimeLeft);
        if (_timer.TimeLeft / _timeForRace < 0.5f)
        {
            _starsAnimator.SetInteger("End", 2);
            PlayerResurs.GradeRace.Add(SceneManager.GetActiveScene().buildIndex - 2, 2);
            _timePlayer.text = _timeNow.ToString();
            PlayerResurs.GoldForLvl = 250 * changeReward;
        }
        else if (_timer.TimeLeft / _timeForRace >= 0.5f && _timer.TimeLeft / _timeForRace < 0.8f)
        {
            _starsAnimator.SetInteger("End", 1);
            PlayerResurs.GradeRace.Add(SceneManager.GetActiveScene().buildIndex - 2, 1);
            _timePlayer.text = _timeNow.ToString();
            PlayerResurs.GoldForLvl = 100 * changeReward;
        }
        else
        {
            _starsAnimator.SetInteger("End", 0);
            PlayerResurs.GradeRace.Add(SceneManager.GetActiveScene().buildIndex - 2, 0);
            _timePlayer.text = _timeNow.ToString();
            PlayerResurs.GoldForLvl = 50 * changeReward;
        }
        PlayerResurs.RaceResults.Add(SceneManager.GetActiveScene().buildIndex - 2, (int)_timer.TimeLeft);

        _bestTimePlayer.text = PlayerResurs.RaceResults[SceneManager.GetActiveScene().buildIndex - 2].ToString();
    }

    void RewardsFinish(int stars)
    {
        if (stars == 0)
        {
            if (_timer.TimeLeft / _timeForRace < 0.5f)
            {
                _starsAnimator.SetInteger("End", 2);
                PlayerResurs.GradeRace[SceneManager.GetActiveScene().buildIndex - 2] = 2;
                _timePlayer.text = _timeNow.ToString();
                PlayerResurs.GoldForLvl = 250 * changeReward;
            }
            else if (_timer.TimeLeft / _timeForRace >= 0.5f && _timer.TimeLeft / _timeForRace < 0.8f)
            {
                _starsAnimator.SetInteger("End", 1);
                PlayerResurs.GradeRace[SceneManager.GetActiveScene().buildIndex - 2] = 1;
                _timePlayer.text = _timeNow.ToString();
                PlayerResurs.GoldForLvl = 100 * changeReward;
            }
            else
            {
                _starsAnimator.SetInteger("End", 0);
                _timePlayer.text = _timeNow.ToString();
                PlayerResurs.GoldForLvl = 10 * changeReward;
            }
        }
        else if (stars == 1)
        {
            if (_timer.TimeLeft / _timeForRace < 0.5f)
            {
                _starsAnimator.SetInteger("End", 2);
                PlayerResurs.GradeRace[SceneManager.GetActiveScene().buildIndex - 2] = 2;
                _timePlayer.text = _timeNow.ToString();
                PlayerResurs.GoldForLvl = 250 * changeReward;
            }
            else if (_timer.TimeLeft / _timeForRace >= 0.5f && _timer.TimeLeft / _timeForRace < 0.8f)
            {
                _starsAnimator.SetInteger("End", 1);
                _timePlayer.text = _timeNow.ToString();
                PlayerResurs.GoldForLvl = 30 * changeReward;
            }
            else
            {
                _starsAnimator.SetInteger("End", 0);
                _timePlayer.text = _timeNow.ToString();
                PlayerResurs.GoldForLvl = 10 * changeReward;
            }
        }
        else if (stars == 2)
            if (_timer.TimeLeft / _timeForRace < 0.5f)
            {
                _starsAnimator.SetInteger("End", 2);
                _timePlayer.text = _timeNow.ToString();
                PlayerResurs.GoldForLvl = 50 * changeReward;
            }
            else if (_timer.TimeLeft / _timeForRace >= 0.5f && _timer.TimeLeft / _timeForRace < 0.8f)
            {
                _starsAnimator.SetInteger("End", 1);
                _timePlayer.text = _timeNow.ToString();
                PlayerResurs.GoldForLvl = 30 * changeReward;
            }
            else
            {
                _starsAnimator.SetInteger("End", 0);
                _timePlayer.text = _timeNow.ToString();
                PlayerResurs.GoldForLvl = 10 * changeReward;
            }

        _bestTimePlayer.text = PlayerResurs.RaceResults[SceneManager.GetActiveScene().buildIndex - 2].ToString();
    }
    public void VideoReward()
    {
        YandexGame.RewVideoShow(0);
        PlayerResurs.GoldForLvl *= 3;
        GameObject VideoButton = GameObject.Find("VideoReward");
        VideoButton.SetActive(false);
        _goldForLvl.text = PlayerResurs.GoldForLvl.ToString();
        YandexGame.savesData.Golds = PlayerResurs.Golds;
        YandexGame.SaveProgress();
    }

    public void Nextlvl()
    {
        PlayerResurs.Golds += PlayerResurs.GoldForLvl;
        YandexGame.savesData.Golds = PlayerResurs.Golds;
        YandexGame.SaveProgress();
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            ExitRace();
        else
            ExitNextRace();
    }

    public void Lose()
    {
        _loseAnimator.SetBool("Lose", true);
    }
}
