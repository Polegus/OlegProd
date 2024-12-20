using UnityEngine;
using UnityEngine.UI;

public class Gates2 : MonoBehaviour
{
    [SerializeField] GameObject _effect;
    [SerializeField] GameObject _effectPatron;
    [SerializeField] GameObject _spawnPos;
    [SerializeField] GameObject[] _paramGate;
    [SerializeField] int _bonus;
    [SerializeField] Text _bonusText;
    [SerializeField] Image _bonusSprite;
    [SerializeField] Text _parametr;
    int _changeParam;
    int _touchBonus;
    // Start is called before the first frame update
    void Start()
    {
        BonusForTouch();



        changeParam();

        bonusText();
    }

    void changeParam()
    {
        _changeParam = Random.Range(0, 3);
        for (int i = 0; i < _paramGate.Length; i++)
        {
            if (i == _changeParam)
                _paramGate[i].SetActive(true);
            else
                _paramGate[i].SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Turrel"))
        {
            if (gameObject.name.Contains("Gates0"))
            {
                GetBonus();
                Instantiate(_effect, _spawnPos.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

        }
        if (other.gameObject.name.Contains("Patron"))
        {
            _bonus += int.Parse(_parametr.text);
            Instantiate(_effectPatron, other.transform.position, Quaternion.identity);
            bonusText();
            Destroy(other.gameObject);
        }
    }

    void GetBonus()
    {
        if (_changeParam == 0)
        {
            ParamGuns.Speed += _bonus;
            if (ParamGuns.Speed < 30)
                ParamGuns.Speed = 30;
        }
        else if (_changeParam == 1)
        {
            ParamGuns.Strength += _bonus;
            if (ParamGuns.Strength < 20)
                ParamGuns.Strength = 20;
        }
        else if (_changeParam == 2)
        {
            ParamGuns.Distance += _bonus;
            if (ParamGuns.Distance < 50)
                ParamGuns.Distance = 50;
        }

    }
    void bonusText()
    {
        if (_bonus > 0)
        {
            _bonusSprite.color = new Color(0, 0.75f, 0, 0.86f);
            _bonusText.text = "+" + _bonus;
        }
        else if (_bonus == 0)
            _bonusText.text = "0";
        else
        {
            _bonusText.text = _bonus.ToString();
            _bonusSprite.color = new Color(1, 0, 0, 0.88f);
        }

    }

    void BonusForTouch()
    {
        if (PlayerResurs1.lvlNow < 10)
            _touchBonus = Random.Range(-2, 6);
        else
            _touchBonus = Random.Range(-2, 3);
        if (PlayerResurs1.lvlNow % 5 == 1)
            _touchBonus = Random.Range(-2, 7);
        if (_touchBonus == 0)
            _parametr.text = "+" + (_touchBonus + 1);
        else if (_touchBonus > 0)
            _parametr.text = "+" + _touchBonus;
        else
            _parametr.text = _touchBonus.ToString();

        if (PlayerResurs1.lvlNow < 10)
            _bonus = Random.Range(-10, 20);
        else if (PlayerResurs1.lvlNow >= 10 && PlayerResurs1.lvlNow < 20)
            _bonus = Random.Range(-10, 20);
        else if (PlayerResurs1.lvlNow >= 20 && PlayerResurs1.lvlNow < 30)
            _bonus = Random.Range(-20, 20);
        else if (PlayerResurs1.lvlNow >= 30 && PlayerResurs1.lvlNow < 40)
            _bonus = Random.Range(-25, 10);
        else
            _bonus = Random.Range(-30, 20);

    }
}
