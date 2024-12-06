using UnityEngine;
using UnityEngine.UI;
using YG;

public class FinishScript : MonoBehaviour
{
    [SerializeField] Text _record;
    [SerializeField] Text _result;
    [SerializeField] public Text _bonusGold;
    [SerializeField] public GameObject _finishWindow;
    int record;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        Finish();
    }
    public void Finish()
    {
        record = (int)gameObject.transform.position.z - 551;
        _bonusGold.text = PlayerResurs1.GoldForLvl.ToString();
        _result.text = record.ToString();
        if (PlayerResurs1.Record < record)
        {
            YandexGame.NewLeaderboardScores("GunGame", record);
            YandexGame.savesData.Record = record;
            PlayerResurs1.Record = record;
            _record.text = PlayerResurs1.Record.ToString();
        }
        else
        {
            _record.text = PlayerResurs1.Record.ToString();
        }
        _finishWindow.SetActive(true);
        YandexGame.SaveProgress();
    }
}
