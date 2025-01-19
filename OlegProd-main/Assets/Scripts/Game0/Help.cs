using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Help : MonoBehaviour
{
    [SerializeField] GameObject _shop;
    [SerializeField] GameObject _backgrond;
    [SerializeField] GameObject _buttonLvl;
    [SerializeField] GameObject _buyLvl;
    [SerializeField] GameObject _canvas;
    [SerializeField] GameObject _closeButton;
    [SerializeField] GameObject[] _buttonsOff;
    Animator _animator;
    int _helpNow;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerResurs1.lvlNow != 1 || !PlayerResurs1.Help)
            Destroy(gameObject);
        else
        {
            _animator =GetComponent<Animator>();
            _animator.SetInteger("Step", 0);
            _helpNow++;
            _buyLvl.SetActive(false);
            _buttonLvl.SetActive(false);
            buttonOff();
        }
            
    }


    public void Help0()
    {
        if (_helpNow == 1)
        {
            _canvas.GetComponent<ShopGunScene>().NextGun();
            _shop.SetActive(false);
        }
            
        _animator.SetInteger("Step", _helpNow);
        _helpNow++;
        if (_helpNow == 4)
            _closeButton.SetActive(true);
        if (_helpNow == 5)
            _buyLvl.SetActive(true);
        if (_helpNow == 7)
            _buyLvl.SetActive(false);
        _backgrond.SetActive(false);
    }
    public void Help1() 
    { 
        if (_helpNow >= 7)
        {
            _animator.SetInteger("Step", _helpNow);
            _helpNow++;
        }
        if (_helpNow > 8)
        {
            _buttonLvl.SetActive(true);
            GameObject.Find("Help").SetActive(false);
        }
            
        }

    void buttonOff()
    {
        for (int i = 0; i < _buttonsOff.Length; i++)
        {
            _buttonsOff[i].SetActive(false);
        }
    }
}
