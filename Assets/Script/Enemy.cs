using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _radius;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x - Time.deltaTime * _speed,
            transform.position.y + _radius * Mathf.Cos(Time.realtimeSinceStartup * _speed),
            transform.position.z);

        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.ToString());
        if (collision.collider.GetComponent<FireBall>() != null)
        {
            Destroy(gameObject);
        }
    }
}
