using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _force = 500;
    [SerializeField]
    private GameObject _fireball;
    private Rigidbody2D _rigidBody;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.AddForce(new Vector2(0, _force));
            Instantiate(_fireball, new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z), _fireball.transform.rotation);
        }
        if (transform.position.y > 4.3 || transform.position.y < -4.3)
        {
            Lost();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Stump>() != null || collision.collider.GetComponent<Enemy>() != null)
        {
            Lost();
        }
    }
    private void Lost()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }

}
