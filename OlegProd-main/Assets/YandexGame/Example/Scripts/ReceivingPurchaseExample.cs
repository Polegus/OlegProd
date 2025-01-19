using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace YG.Example
{
    [HelpURL("https://www.notion.so/PluginYG-d457b23eee604b7aa6076116aab647ed#10e7dfffefdc42ec93b39be0c78e77cb")]
    public class ReceivingPurchaseExample : MonoBehaviour
    {
        [SerializeField] UnityEvent successPurchased;
        [SerializeField] UnityEvent failedPurchased;
        [SerializeField] Text _gold;
        [SerializeField] Text _almaz;
        [SerializeField] Text[] _price;

        private void Start()
        {
            for (int i = 0; i < _price.Length; i++)
            {
                _price[i].text = YandexGame.purchases[i].price;
            }
        }
        private void OnEnable()
        {
            YandexGame.PurchaseSuccessEvent += SuccessPurchased;
            YandexGame.PurchaseFailedEvent += FailedPurchased;
            
        }

        private void OnDisable()
        {
            YandexGame.PurchaseSuccessEvent -= SuccessPurchased;
            YandexGame.PurchaseFailedEvent -= FailedPurchased;
        }

        void SuccessPurchased(string id)
        {
            successPurchased?.Invoke();

            // Ваш код для обработки покупки. Например:
            if (id == "1")
            {
                YandexGame.savesData.Golds += 1000;
                PlayerResurs1.Golds += 1000;
                _gold.text = YandexGame.savesData.Golds.ToString();
            }

            else if (id == "2")
            {
                YandexGame.savesData.Almaz += 10;
                PlayerResurs1.Almaz += 10;
                _almaz.text = YandexGame.savesData.Almaz.ToString();
            }
            else if (id == "3")
            {
                YandexGame.savesData.Golds += 6000;
                PlayerResurs1.Golds += 6000;
                _gold.text = YandexGame.savesData.Golds.ToString();
            }
            else if (id == "4")
            {
                YandexGame.savesData.Almaz += 60;
                PlayerResurs1.Almaz += 60;
                _almaz.text = YandexGame.savesData.Almaz.ToString();
            }
            //else if (id == "1500")
            //    YandexGame.savesData.money += 1500;
            YandexGame.SaveProgress();
        }



        void FailedPurchased(string id)
        {
            failedPurchased?.Invoke();
        }
    }
}