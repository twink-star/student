using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float xMax;
    [SerializeField] private float zMax;
    [SerializeField] private float HP;
    [SerializeField] private Text HPText;
    private float score;
    private GameObject data;
    private Data dataCs;
    [SerializeField] private Text scoreText;
    double scoresave;

    //private�c���̃X�N���v�g���ł�������������Ȃ�
    //public�c�ǂ�����ł������������
    //[SerializeField] private�cUnity��ł͏���������邯�Ǒ��̃X�N���v�g����͏���������Ȃ�

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Data");
        dataCs = data.GetComponent<Data>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D) && this.transform.position.x < xMax) //D���������炩�I�u�W�F�N�g��x���W��xMax�ȉ��̒l�Ȃ�
        transform.Translate(new Vector3(MoveSpeed, 0, 0) * Time.deltaTime); //�ړ����邽�߂̃v���O����

        if (Input.GetKey(KeyCode.A) && this.transform.position.x > -xMax) //A���������炩�I�u�W�F�N�g��x���W��-xMax�ȏ�̒l�Ȃ�
            transform.Translate(new Vector3(-MoveSpeed, 0, 0) * Time.deltaTime); //�ړ����邽�߂̃v���O����

        if (Input.GetKey(KeyCode.W) && this.transform.position.z < zMax) //W���������炩�I�u�W�F�N�g��z���W��xMax�ȉ��̒l�Ȃ�
        transform.Translate(new Vector3(0, 0, MoveSpeed) * Time.deltaTime); //�ړ����邽�߂̃v���O����

        if (Input.GetKey(KeyCode.S) && this.transform.position.z > -zMax) //S���������炩�I�u�W�F�N�g��z���W��xMax�ȏ�̒l�Ȃ�
            transform.Translate(new Vector3(0, 0, -MoveSpeed) * Time.deltaTime); //�ړ����邽�߂̃v���O����

      if (HP <= 0)
           OnDie();
        
      HPText.text = "HP:" + HP.ToString();
        score = dataCs.score;
        scoreText.text = "Score" + score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        HP--;
    }

    private void OnDie()
    {
        Destroy(this.gameObject);
        Debug.Log("Enemy");
        scoresave = score;
        SceneManager.LoadScene("End");
        scoreText.text = "Score" + score.ToString();
    }
}
