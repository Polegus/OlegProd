using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class GunLvlUp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text _lvl;
    [SerializeField] Image _levelPanel;
    [SerializeField] GameObject _upGun;

    public AudioClip[] _sounds;
    AudioSource _audioSource;
    int _lvlNow;
    int _gunNow;
    private void Start()
    {
        CheckGun();
        CheckLvl();
        _audioSource = GetComponent<AudioSource>();
    }
    void OnEnable()
    {
        CheckGun();
        FireGun.StateParamGun += CheckLvl;
    }

    private void OnDisable()
    {
        FireGun.StateParamGun -= CheckLvl;
    }
    // Update is called once per frame
    void Update()
    {

    }

    void CheckGun()
    {
        if (gameObject.name.Contains("Speed"))
        {
            _gunNow = 0;
        }
        else if (gameObject.name.Contains("Power"))
        {
            _gunNow = 1;
        }
        else
        {
            _gunNow = 2;
        }
    }

    void CheckLvl()
    {

        _lvlNow = FireGun.ParamGun[_gunNow];
        _lvl.text = _lvlNow.ToString();
        _levelPanel.fillAmount = (float)_lvlNow / 10;
        if (_lvlNow > 0)
            _upGun.SetActive(true);
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        var _lvlOther = int.Parse(Regex.Match(collision.gameObject.name, @"\d+").Value)+1;
        if (_lvlNow < _lvlOther)
        {
            Destroy(collision.gameObject);
            _lvl.text = _lvlOther.ToString();
            _lvlNow = _lvlOther;
            FireGun.ParamGun[_gunNow] = _lvlNow;
            CheckLvl();
            if (PlayerResurs1.lvlNow == 1 && !PlayerResurs1.Help)
                GameObject.Find("Help").GetComponent<Help>().Help1();
            Buy();
            
        }

    }
    public void Buy()
    {
        _audioSource.clip = _sounds[0];
        _audioSource.Play();
    }

}
