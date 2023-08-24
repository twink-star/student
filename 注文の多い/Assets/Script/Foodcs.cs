using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
            Destroy(this.gameObject);

    }


    public void FoodMove()
    {
      
        if (-13f < this.transform.position.x && this.transform.position.x < -8f && 3f < this.transform.position.z  && this.transform.position.z < 8f)
            Debug.Log("Stand by ready");
        //this.transform.position = new Vector3(-10f, 0.2f, 5f);

    }

}
