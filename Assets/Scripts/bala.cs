using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class bala : MonoBehaviour
{
    public float speed=10f;
    public float maxlifet = 3f;
    public Vector3 targetVector;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,maxlifet);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            IncreaseScore();
        }
    }
    private void IncreaseScore()
    {
        nave.Score++;
        UpdateScore();
    }
    private void UpdateScore()
    {
        GameObject text = GameObject.FindGameObjectWithTag("UI");
        text.GetComponent<Text>().text = "Puntos: " + nave.Score;
    }
}
