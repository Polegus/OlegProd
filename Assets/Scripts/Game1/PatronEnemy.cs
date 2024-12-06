using UnityEngine;

public class PatronEnemy : MonoBehaviour
{
    [SerializeField] int _speed;
    [SerializeField] float _timeLife;
    [SerializeField] GameObject _effect;
    Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.forward * _speed *100f);
        Destroy(gameObject, _timeLife);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Gun"))
        {
            ParamGuns _paramGun = other.GetComponent<ParamGuns>();
            _paramGun.GetDamage(10f);
            Instantiate(_effect, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (!other.gameObject.name.Contains("Patron"))
        {
            Instantiate(_effect, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }

}
