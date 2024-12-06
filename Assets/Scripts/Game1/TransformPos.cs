using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPos : MonoBehaviour
{
    [SerializeField] Transform _dragonsObj;
    [SerializeField] GameObject _effect;
    Vector3 startPos;
    Vector3 newPos;
    bool ReturnStart;
    bool ChoisePos;
    bool StaticPos;
    [SerializeField] GameObject _nextDragon;
    public static int AllUp;

    Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //   gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 20f));
        startPos = transform.position;
        newPos = startPos;
        ReturnStart = false;
        ChoisePos = false;
        _rigidbody = GetComponent<Rigidbody>();
        StaticPos = true;

    }

    // Update is called once per frame
    void Update()
    {
        //   transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z+20));
        // Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z)));
        if (ReturnStart)
        {
            MoveStart();
            if (transform.position == newPos)
            {
                ReturnStart = false;
                startPos = newPos;
                StaticPos = true;
            }

        }

        /*if (ShopTest.StartGame)
            GetComponent<CapsuleCollider>().enabled = false;*/

    }

    public void TouchObj()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z+4.3f));
        StaticPos = false;
        // GetComponent<SphereCollider>().enabled = true;
        GetComponent<BoxCollider>().isTrigger = true;
    }


    public void TouchObjUp()
    {
        ReturnStart = true;
       // GetComponent<SphereCollider>().enabled = false;
        ChoisePos = false;
        GetComponent<BoxCollider>().isTrigger = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == gameObject.name && collision.gameObject.tag == gameObject.tag)
        {
            var NewParent = GameObject.Find("Cells").transform;
            AllUp++;
            Destroy(gameObject);
            if (StaticPos)
            {
                Instantiate(_nextDragon, transform.position, gameObject.transform.rotation, NewParent);
                Instantiate(_effect, transform.position, Quaternion.identity);
                if (PlayerResurs1.lvlNow == 1 && !PlayerResurs1.Help)
                    GameObject.Find("Help").GetComponent<Help>().Help1();
            }

        }
        
        if (collision.gameObject.name != gameObject.name && collision.gameObject.tag == gameObject.tag)
        {
            ChoisePos = true;
            newPos = startPos;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Cell")
        {
            if (!ChoisePos)
                newPos = other.transform.position + new Vector3(0, 0.06f, -0.1f);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cell")
        {
            newPos = startPos;
        }
    }
    public void MoveStart()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * 2f);   
    }
}
