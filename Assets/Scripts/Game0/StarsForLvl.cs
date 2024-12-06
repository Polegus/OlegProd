using UnityEngine;
using UnityEngine.UI;
using YG;
using YG.Utils.LB;

public class StarsForLvl : MonoBehaviour
{
    [SerializeField] Image[] Stars;
    [SerializeField] int _numLvl;
    [SerializeField] Text _timePlayer;
    [SerializeField] GameObject _liderBoard;
    // Start is called before the first frame update
    void Start()
    {

        if (PlayerResurs.GradeRace.ContainsKey(_numLvl - 1))
        {
            for (int i = 0; i < Stars.Length; i++)
            {
                if (PlayerResurs.GradeRace[_numLvl - 1] >= i)
                    Stars[i].color = new Color(255, 255, 255, 255);
            }
            _timePlayer.text = PlayerResurs.RaceResults[_numLvl - 1].ToString();
        }

    }

    public void OpenLiderBoard()
    {
        _liderBoard.SetActive(true);
    }

    public void CloseLiderBoard()
    {
        _liderBoard.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
