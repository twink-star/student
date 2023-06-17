using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float makeTime;
    private float waitTime;
    [SerializeField] private float enemyZ;
    [SerializeField] private float enemyX;
    private float ranX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime < makeTime) //敵が画面に現れるまでの時間を数える
        {
            waitTime = waitTime + Time.deltaTime;//waitTimeにフレーム間の数字を足しこみ続けタイマー的役割を担わせる

        }

        else 
        {
            ranX = Random.Range(enemyX * -1, enemyX);//ranXには-enemyからenemyXまでのどれかの値が入る
            Instantiate(enemyPrefab, new Vector3(ranX, 0, enemyZ), enemyPrefab.transform.rotation);
            //オブジェクトを出現させる(enemyPrefabを,vector3の座標で、enemyPrefabのrotationで)
            waitTime = 0;//waitTimeを0にすることでもう1回
        }
    }
}
