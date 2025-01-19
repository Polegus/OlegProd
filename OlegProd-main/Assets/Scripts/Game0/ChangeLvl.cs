using UnityEngine;

public class ChangeLvl : MonoBehaviour
{
    [SerializeField] GameObject[] _lvl;
    [SerializeField] GameObject _rightBtn;
    [SerializeField] GameObject _leftBtn;
    [SerializeField] GameObject[] _changeLvl;

    // Start is called before the first frame update
    int _lvlNow;

    private void Start()
    {
    }

    public void OpenChangeLvl(int lvl)
    {
        _lvlNow = lvl;
        for (int i = 0; i < _changeLvl.Length; i++)
        {
            _changeLvl[i].SetActive(false);
        }
        for (int i = 0; i < _lvl.Length; i++)
        {

            if (_lvlNow == i)
                _lvl[i].SetActive(true);
            else
                _lvl[i].SetActive(false);
        }
        _rightBtn.SetActive(true);
        _leftBtn.SetActive(true);
    }

    /*void StateButtons()
    {
        if (_lvlNow >= PlayerResurs.LvlMax)
            _rightBtn.SetActive(false);
        else
            _rightBtn.SetActive(true);
        if (_lvlNow <= 0)
            _leftBtn.SetActive(false);
        else
            _leftBtn.SetActive(true);
    }*/
    public void NextLvl()
    {
        if (_lvlNow < _lvl.Length - 1)
            _lvlNow++;


        for (int i = 0; i < _lvl.Length; i++)
        {

            if (_lvlNow == i)
                _lvl[i].SetActive(true);
            else
                _lvl[i].SetActive(false);
        }

    }

    public void PrevLvl()
    {

        if (_lvlNow > 0)
            _lvlNow--;
        for (int i = 0; i < _lvl.Length; i++)
        {

            if (_lvlNow == i)
                _lvl[i].SetActive(true);
            else
                _lvl[i].SetActive(false);
        }


    }
}
