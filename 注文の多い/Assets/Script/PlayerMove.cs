using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] public float CameraSpeed;
    [SerializeField] private float Dist;
    private Vector3 angle;
    private Vector3 Move;
    private GameObject[] Targets;
    private GameObject NearFood;

    [SerializeField] private float d;

    //Rigidbody型のrbという変数を作る
    private Rigidbody rb;

   
   // [SerializeField] private Foodcs _foodcs;

    //Vector3 targetPosition = new Vector3(0, 0, 0);


    //Rigidbody rd;

    public Vector3 movingVelocity;
    Vector3 movingDirecion;

    // Start is called before the first frame update
    void Start()
    {
        Targets = GameObject.FindGameObjectsWithTag("Food");
        angle = this.gameObject.transform.localEulerAngles;
        rb = GetComponent<Rigidbody>();
        //rbz = GetComponent<Rigidbody>();
        Transform objectTransform = gameObject.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
       angle.y += Input.GetAxis("Mouse X") * CameraSpeed;

        //angle.x -= Input.GetAxis("Mouse Y") * CameraSpeed;

        this.gameObject.transform.localEulerAngles = angle;

        // Move.x += Input.GetKey(KeyCode.W) * MoveSpeed;
        //Move.x -= Input.GetKey(KeyCode.S) * MoveSpeed;
        //Move.z += Input.GetKey(KeyCode.A) * MoveSpeed;
        //Move.z -= Input.GetKey(KeyCode.D) * MoveSpeed;
        //rb.velocity = new vector3();

        //if (Input.GetKey(KeyCode.W))
        //rb.AddForce(transform.forward * MoveSpeed, ForceMode.Acceleration);   
        //transform.Translate(new Vector3(0, 0, MoveSpeed) * Time.deltaTime);



        if (Input.GetKeyDown(KeyCode.Space))
        {
            NearFood = null;
            Dist = 10;

            foreach (GameObject t in Targets)
            {
                // このオブジェクトと食材までの距離を計測
                float tDist = Vector3.Distance(transform.position, t.transform.position);

                // もしも「初期値」よりも「計測した距離」の方が近いならば、
                if (Dist > tDist)
               {    // 「Dist」を「tDist（食材までの距離）」に置き換える。
                    // これを繰り返すことで、一番近い食材を見つけ出すことができる。
                    Dist = tDist;
                    // 一番近い情報をNearFoodという変数に格納する
                    NearFood = t;
                    //NearFood.transform.localPosition = new Vector3(3, 0, 0);

                }


            }
            //rd.useGravity = false;
            //NearFood.rb.useGravity = false;
            NearFood.transform.parent = this.gameObject.transform;
            NearFood.transform.position = transform.position + transform.forward * d + transform.up * 3;

        }


        if (Input.GetKeyUp(KeyCode.Space))
        {


            // GameObject otherGameObject = GameObject.FindWithTag("Food");
       
                Foodcs foodcs = NearFood.GetComponent<Foodcs>();
                foodcs.FoodMove(0f);
                NearFood.transform.parent = null;




        }

        // Wキー（前方移動）
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += MoveSpeed * transform.forward * Time.deltaTime;
        }

        // Sキー（後方移動）
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= MoveSpeed * transform.forward * Time.deltaTime;
        }

        // Dキー（右移動）
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += MoveSpeed * transform.right * Time.deltaTime;
        }

        // Aキー（左移動）
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= MoveSpeed * transform.right * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.L))
        {
   
        }
    }

    void FixedUpdate()
    {

    }


}





