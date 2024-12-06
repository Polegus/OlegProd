using UnityEngine;
using UnityEngine.UI;
using YG;

public class Shop2 : MonoBehaviour
{
    
    [SerializeField] Cell[] _cell;
    [SerializeField] Sprite[] _images;
    [SerializeField] GameObject[] _buyObj;
    [SerializeField] Image _obj;
    ShopGunScene _shopGunScene;
    public AudioClip[] _sounds;
    public AudioSource _audioSource;
    public int NumObj;
    // Start is called before the first frame update
    void Start()
    {
        _shopGunScene = GetComponent<ShopGunScene>();
        _shopGunScene.lvlState();
    }
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }

    // Отписываемся от события открытия рекламы в OnDisable
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }
    void Rewarded(int id)
    {

        if (id == 1)
        {
            PlayerResurs1.Golds += _shopGunScene._priceReward;
            _shopGunScene._playersGold.text = PlayerResurs1.Golds.ToString();
            _shopGunScene.lvlState();
        }


    }
    // Update is called once per frame
    void Update()
    {

    }

    public void BuyObj()
    {

        if (_shopGunScene._priceLvl <= PlayerResurs1.Golds)
        {
            for (int i = 0; i < _cell.Length; i++)
            {
                if (_cell[i].EmptyCell)
                {

                    Instantiate(_buyObj[NumObj], _cell[i].transform.position + new Vector3(0, 0.06f, -0.1f), _cell[i].transform.localRotation, _cell[i].transform);

                    break;
                }
            }
            PlayerResurs1.Golds -= _shopGunScene._priceLvl;
            _shopGunScene.lvlState();
            Buy();
        }
        else
            YandexGame.RewVideoShow(1);
        
    }
    public void Buy()
    {
        _audioSource.clip = _sounds[0];
        _audioSource.Play();
    }
    

    public void NextObj()
    {
        if (NumObj < _images.Length - 1)
            NumObj++;
        _obj.sprite = _images[NumObj];
        _shopGunScene.lvlState();
    }

    public void PrevObj()
    {
        if (NumObj > 0) 
            NumObj--;
        _obj.sprite = _images[NumObj];
        _shopGunScene.lvlState();
    }
}
