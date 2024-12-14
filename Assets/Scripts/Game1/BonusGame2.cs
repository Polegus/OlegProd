using UnityEngine;

public class BonusGame2 : MonoBehaviour
{
    [SerializeField] GameObject _effectTouch;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Tank"))
        {
            Instantiate(_effectTouch, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }


}
