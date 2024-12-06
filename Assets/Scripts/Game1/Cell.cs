using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] _objects;
    bool Contact = false;
    bool StateBuy;
    int NumGun;
    public bool EmptyCell = true;
    float TimeContact;
    [SerializeField] public AudioClip[] sound;
    public AudioSource a;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && Contact && EmptyCell)
        {
            /*var NewParent = GameObject.Find("Dragons").transform;
            Instantiate(_objects[NumGun], gameObject.transform.position, Quaternion.identity, NewParent);
            GetComponent<BoxCollider>().enabled = false;*/
          //  PlayerResurs.PlayerGold -= 10;
           // BuySound();
        }
    }
    private void OnTriggerStay(Collider collision)
    {
      //  ShopGun(collision.gameObject.name);

        Contact = true;

        if (collision.gameObject.tag == "Stack")
        {

            Contact = false;
            EmptyCell = false;
            TimeContact += Time.deltaTime;
        }

    }


    private void OnTriggerExit(Collider other)
    {
        TimeContact = 0;
        GetComponent<BoxCollider>().enabled = true;
        Contact = false;
        if (other.gameObject.tag == "Stack")
            EmptyCell = true;
    }

    /* private void OnCollisionStay(Collision collision)
     {
         if (collision.gameObject.tag == "Stack")
         {
             gameObject.SetActive(false);
         }
     }
     private void OnCollisionExit(Collision collision)
     {
         if (collision.gameObject.tag == "Stack")
         {
             gameObject.SetActive(true);
         }
     }*/


    void ShopGun(string ObjectName)
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            if (ObjectName == "SGun" + i)
            {
                StateBuy = true;
                NumGun = i;
                break;
            }
            if (ObjectName != "SGun" + i) StateBuy = false;
        }
    }

    public void BuySound()
    {
        a.clip = sound[0];
        a.Play();
    }
}
