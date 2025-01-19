using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunColliderManager : MonoBehaviour
{
    
    [SerializeField] Text _goldForLevelText;
    private void Start()
    {
        _goldForLevelText.text = PlayerResurs1.GoldForLvl.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Coin"))
        {
            PlayerResurs1.GoldForLvl++;
            _goldForLevelText.text = PlayerResurs1.GoldForLvl.ToString();
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Finish")
            ParamGuns.StateFinish = true;
    }

}
