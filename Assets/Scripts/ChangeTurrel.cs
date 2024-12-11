using UnityEngine;

public class ChangeTurrel : MonoBehaviour
{
    [SerializeField] GameObject[] _turrels;
    int _turrelNow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextTurrel()
    {
        if (_turrelNow < _turrels.Length - 1)
            _turrelNow++;
        for (int i = 0; i < _turrels.Length; i++)
        {

            if (i == _turrelNow)
                _turrels[i].SetActive(true);
            else
                _turrels[i].SetActive(false);
        }
    }

    public void PrevTurrel()
    {
        if (_turrelNow > 0)
            _turrelNow--;
        for (int i = 0; i < _turrels.Length; i++)
        {
            if (i == _turrelNow)
                _turrels[i].SetActive(true);
            else
                _turrels[i].SetActive(false);
        }
    }
}
