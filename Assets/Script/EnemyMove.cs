using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    [SerializeField] private float enemyLifeTime;
    private GameObject data;
    private Data dataCs;
    // Start is called before the first frame update
    void Start()
    { 
        data = GameObject.Find("Data"); //�q�G�����L�[�ɂ���Data��data�ɑ��;
        dataCs = data.GetComponent<Data>(); //data(�q�G�����L�[�ɂ���Data)�̒�����X�N���v�g��Data���擾
    }

    // Update is called once per frame

    void Update()
    {
        transform.Translate(new Vector3(0, 0, enemySpeed) * Time.deltaTime);
        enemyLifeTime = enemyLifeTime - Time.deltaTime;
        if (enemyLifeTime < 0)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            dataCs.score++; //Destroy�̑O�ɂ�������
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
            Destroy(this.gameObject);

    }


}
