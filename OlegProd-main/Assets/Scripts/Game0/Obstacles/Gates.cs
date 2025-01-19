using UnityEngine;
using UnityEngine.UI;

public class Gates : MonoBehaviour
{
    [SerializeField] GameObject _effect;
    [SerializeField] GameObject _spawnPos;
    [SerializeField] int _bonus;
    [SerializeField] Text _bonusText;
    [SerializeField] SpriteRenderer _bonusSprite;
    private void OnTriggerEnter(Collider other)
    {
        ChangeCar changeCar = other.GetComponent<ChangeCar>();
        changeCar.SpeedTrigger(_bonus);

        Instantiate(_effect, _spawnPos.transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        while (_bonus == 0)
        {
            _bonus = Random.Range(-100, 100);
        }



        if (_bonus > 0)
        {
            _bonusSprite.color = Color.green;
            _bonusText.text = "+" + (_bonus + 1);
        }
        else
            _bonusText.text = (_bonus - 1).ToString();
    }

}
