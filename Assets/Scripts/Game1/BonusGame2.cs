using UnityEngine;

public class BonusGame2 : MonoBehaviour
{
    [SerializeField] GameObject _effectTouch;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Gun"))
        {
            Instantiate(_effectTouch, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }


}
