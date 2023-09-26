using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class nave : MonoBehaviour
{
    public static int Score = 0;
    public float thrustspeed = 5f;
    public float rotspeed = 10f;
    private Rigidbody rigid;
    public GameObject gun, bulletprefab;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float rot = Input.GetAxis("Horizontal") * Time.deltaTime;
        float thrust = Input.GetAxis("Vertical")*Time.deltaTime;
        Vector3 thrustdire = transform.right;
        rigid.AddForce(thrustdire*thrust*thrustspeed);
        transform.Rotate(Vector3.forward, -rot * rotspeed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletprefab, gun.transform.position, Quaternion.identity);
            bala balascript = bullet.GetComponent<bala>();
            balascript.targetVector = transform.right;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            Score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
