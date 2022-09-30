using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stump : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - Time.deltaTime * _speed, transform.position.y, transform.position.z);

        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }
}
