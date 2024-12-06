using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text _timer;
    [SerializeField] public bool _hardTimer;
    public float TimeLeft;
    public bool Finish;
    void Start()
    {

    }

    public void CountSecondTime()
    {
        if (!_hardTimer)
            TimeLeft += Time.deltaTime;
        else
            TimeLeft += Time.deltaTime * 100f;

        _timer.text = ((int)TimeLeft).ToString();
    }
    /*public IEnumerator CountSeconds()
    {
        while (!Finish)
        {
            //I am reducing the time left on the counter by 1 second each time.
            TimeLeft++;
            _timer.text = TimeLeft.ToString();
            //   timer.text = timeLeft.ToString("mm\:ss");
            if (!_hardTimer)
                yield return new WaitForSeconds(1f);
            else
                yield return new WaitForSeconds(0.01f);
            

        }
    }*/
}
