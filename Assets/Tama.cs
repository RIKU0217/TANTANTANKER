using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tama : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Tank")
        {
            // 衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);
            Debug.Log("衝突");
        }

        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log(tag);
            Destroy(this.gameObject);
        }
    }
}
