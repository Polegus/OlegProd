using UnityEngine;
using UnityEngine.UI;

public class GarageShop : MonoBehaviour
{
    [SerializeField] GameObject _gameObject;
    [SerializeField] Text _priceText;
    [SerializeField] GameObject _paySound;
    Image _buttonBuy;
    GarageManager _garageManager;
    private void Start()
    {
        if (PlayerResurs.GarageObj.Contains(_gameObject.name))
        {
            Destroy(gameObject);
            _gameObject.SetActive(true);
        }
        _buttonBuy = GetComponent<Image>();
        _garageManager = GameObject.Find("CanvasButton").GetComponent<GarageManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && _buttonBuy.fillAmount < 1)
        {
            if (PlayerResurs.Golds >= int.Parse(_priceText.text))
            {
                _buttonBuy.fillAmount += Time.deltaTime/2;
            }

        }
        else
        {
            Instantiate(_paySound, gameObject.transform.position, Quaternion.identity);
            _gameObject.SetActive(true);
            GarageManager.BuyProduct(int.Parse(_priceText.text), _garageManager);
            PlayerResurs.GarageObj.Add(_gameObject.name);
            Destroy(gameObject);
        }
    }
}
