using UnityEngine;
using UnityEngine.UI;

public class Scaner : MonoBehaviour
{
    [SerializeField] Image _healf;
    [SerializeField] GameObject[] _reward;
    [SerializeField] GameObject _spawnPos;
    [SerializeField] GameObject _destroyEffect;
    [SerializeField] GameObject _effectTouch;

    int _numReward = 0;
    // Start is called before the first frame update
    void Start()
    {
        _destroyEffect.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        _effectTouch.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_healf.fillAmount > 0)
        {
            _healf.fillAmount -= 0.2f * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Patron"))
        {
            _numReward = Random.Range(0, _reward.Length);
            if (_healf.fillAmount < 1)
                _healf.fillAmount += 1 / (float)PlayerResurs1.lvlNow;
            if (_healf.fillAmount >= 1)
            {

                Instantiate(_reward[_numReward], _spawnPos.transform.position, Quaternion.identity);
                Instantiate(_effectTouch, other.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

        }

        if (other.gameObject.name.Contains("Gun"))
        {
            ParamGuns _paramGun = other.GetComponent<ParamGuns>();
            _paramGun.GetDamage(20f);
            Instantiate(_destroyEffect, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3f, gameObject.transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
