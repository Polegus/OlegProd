using UnityEngine;
using UnityEngine.UI;
using YG;

public class ObjectPrefab : MonoBehaviour
{
    [SerializeField] float _healf;
    [SerializeField] GameObject _reward;
    [SerializeField] Image _healfBar;
    [SerializeField] GameObject _object;
    [SerializeField] GameObject _destroyEffect;
    [SerializeField] GameObject _effectTouch;
    [SerializeField] GameObject _destroyGun;
    [SerializeField] BonusCubes _healfBonusCube;
    [SerializeField] bool _destroyBool;
    float _objectDamage = 15;
    float _healfGun;
    // Start is called before the first frame update
    void Start()
    {
        if (_healfBonusCube != null)
            _healf = (_healfBonusCube.HealfCube + transform.position.z) * 500f;
        _healfGun = _healf;
        DamageTouch();
        if (_destroyEffect != null)
            _destroyEffect.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out FinishScript finishScript))
        {
            if (ParamGuns.StateFinish)
            {
                collision.gameObject.GetComponent<FinishScript>().enabled = true;
                collision.gameObject.SetActive(false);
                Instantiate(_destroyGun, new Vector3(collision.transform.position.x, collision.transform.position.y + 2.5f, collision.transform.position.z), Quaternion.identity);
            }
            else
            {
                ParamGuns _paramGun = collision.gameObject.GetComponent<ParamGuns>();
                _paramGun.GetDamage(_objectDamage);
                if (_destroyEffect != null)
                    _destroyEffect.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                Instantiate(_destroyEffect, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.5f, gameObject.transform.position.z), Quaternion.identity);
                Destroy(gameObject);
            }

        }

        if (collision.gameObject.name.Contains("Patron"))
        {

            Destroy(collision.gameObject);
            if (!_destroyBool)
                _healf -= ParamGuns.Strength;
            if (_effectTouch != null)
            {
                Instantiate(_effectTouch, collision.gameObject.transform.position, Quaternion.identity);
                CFXGame1.QuantityEffect++;
            }

            if (_healf <= 0)
            {
                GetComponent<BoxCollider>().enabled = false;
                if (_reward != null)
                    Instantiate(_reward, gameObject.transform.position, Quaternion.identity);
                Instantiate(_destroyEffect, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.5f, gameObject.transform.position.z), Quaternion.identity);
                Destroy(_object);
            }
            else
            {
                if (_healfBar != null)
                    _healfBar.fillAmount = _healf / _healfGun;
            }
        }
    }

    void DamageTouch()
    {
        if (YandexGame.savesData.lvlNow < 5)
            _objectDamage *= 1;
        else if (YandexGame.savesData.lvlNow >= 5 && YandexGame.savesData.lvlNow < 10)
            _objectDamage *= 2;
        else if (YandexGame.savesData.lvlNow >= 10 && YandexGame.savesData.lvlNow < 20)
            _objectDamage *= 3;
        else if (YandexGame.savesData.lvlNow >= 20 && YandexGame.savesData.lvlNow < 30)
            _objectDamage *= 4;
        else
            _objectDamage *= 5;
    }
}
