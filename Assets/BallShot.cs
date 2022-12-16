
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour
{
    public GameObject ballPrefab;
    public float speed;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject ball = (GameObject)Instantiate(ballPrefab, transform.position, Quaternion.identity);
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            ballRigidbody.AddForce(transform.forward * speed);
        }
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Tank")
        {
            Debug.Log("衝突");
            // 衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);
        }

    
    }


}
