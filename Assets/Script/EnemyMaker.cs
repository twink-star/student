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
        if (waitTime < makeTime) //�G����ʂɌ����܂ł̎��Ԃ𐔂���
        {
            waitTime = waitTime + Time.deltaTime;//waitTime�Ƀt���[���Ԃ̐����𑫂����ݑ����^�C�}�[�I������S�킹��

        }

        else 
        {
            ranX = Random.Range(enemyX * -1, enemyX);//ranX�ɂ�-enemy����enemyX�܂ł̂ǂꂩ�̒l������
            Instantiate(enemyPrefab, new Vector3(ranX, 0, enemyZ), enemyPrefab.transform.rotation);
            //�I�u�W�F�N�g���o��������(enemyPrefab��,vector3�̍��W�ŁAenemyPrefab��rotation��)
            waitTime = 0;//waitTime��0�ɂ��邱�Ƃł���1��
        }
    }
}
