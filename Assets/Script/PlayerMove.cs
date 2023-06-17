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

    //private…このスクリプト内でしか書きかえれない
    //public…どこからでも書きかえれる
    //[SerializeField] private…Unity上では書きかえれるけど他のスクリプトからは書きかえれない

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Data");
        dataCs = data.GetComponent<Data>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D) && this.transform.position.x < xMax) //Dを押したらかつオブジェクトのx座標がxMax以下の値なら
        transform.Translate(new Vector3(MoveSpeed, 0, 0) * Time.deltaTime); //移動するためのプログラム

        if (Input.GetKey(KeyCode.A) && this.transform.position.x > -xMax) //Aを押したらかつオブジェクトのx座標が-xMax以上の値なら
            transform.Translate(new Vector3(-MoveSpeed, 0, 0) * Time.deltaTime); //移動するためのプログラム

        if (Input.GetKey(KeyCode.W) && this.transform.position.z < zMax) //Wを押したらかつオブジェクトのz座標がxMax以下の値なら
        transform.Translate(new Vector3(0, 0, MoveSpeed) * Time.deltaTime); //移動するためのプログラム

        if (Input.GetKey(KeyCode.S) && this.transform.position.z > -zMax) //Sを押したらかつオブジェクトのz座標がxMax以上の値なら
            transform.Translate(new Vector3(0, 0, -MoveSpeed) * Time.deltaTime); //移動するためのプログラム

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
