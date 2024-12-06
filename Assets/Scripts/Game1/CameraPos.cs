using UnityEngine;

public class CameraPos : MonoBehaviour
{
    [SerializeField] GameObject _gun;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(_gun.transform.position.x, _gun.transform.position.y, _gun.transform.position.z);
    }
}
