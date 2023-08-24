using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foodcs : MonoBehaviour
{
    float dai = 0f;
    private GameObject data;
    private Data dataCs;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Data"); //ヒエラルキーにあるDataをdataに代入;
        dataCs = data.GetComponent<Data>(); //data(ヒエラルキーにあるData)の中からスクリプトのDataを取得

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
         Destroy(this.gameObject);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Rigidbody rd;
            rd = this.GetComponent<Rigidbody>();
            rd.useGravity = true;
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody rd;
            rd = this.GetComponent<Rigidbody>();
            rd.useGravity = false;
        }


    }


    public void FoodMove(float guzai)
    {
        if (-13f < this.transform.position.x && this.transform.position.x < -8f && 3f < this.transform.position.z && this.transform.position.z < 8f)
        {
               this.transform.position = new Vector3(-10f, 0.3f * dataCs.layer, 5f);
                dataCs.layer++;
                dai = 1f;






        }

          
    }

}
