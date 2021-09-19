using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class among_director : MonoBehaviour
{
    public GameObject[] among_A;
    public GameObject[] among_B;
    public GameObject[] hole;
    public GameObject hammer;

    public TextMeshPro timeText;
    public TextMeshPro scoreText;
    public float time;
    public int score;
    float interval;
    float amongSpeed;

    public GameObject gameOverText;

    public bool startTimer = false;
    private void Awake() { gameOverText.SetActive(false); }

    private void Start()
    {
        interval = 1;
        amongSpeed = 0.8f;
        score = 0;
        scoreText.text = score.ToString();
        gameOverText.SetActive(false);
        time = 30f;
        //time -= Time.deltaTime;
    }


    public void StartBtn()
    {
        interval = 1;
        amongSpeed = 0.8f;
        score = 0;
        scoreText.text = score.ToString();
        time = 30f;
        GameObject.Find("re_start_btn").GetComponent<AudioSource>().Play();
        gameOverText.SetActive(false);
        StartCoroutine("AmongUp");
        startTimer = true;
    }

    private void Update()
    {
        if (startTimer == true)
        {
            time -= Time.deltaTime;
        }

        timeText.text = string.Format("{0:0}", time);

        if (20 < time && time <= 30)
        {
            interval = 0.8f;
            //amongSpeed = 1.5f;
        }
        if (10 < time && time <= 20)
        {
            interval = 0.5f;
            //amongSpeed = 1.8f;
        }
        if (10 < time && time <= 20)
        {
            interval = 0.3f;
            //amongSpeed = 2;
        }

        if (time <= 0)
        {
            StopAllCoroutines();
            gameOverText.SetActive(true);
            time = 0;
            hammer.SetActive(false);
        }
        
    }

    IEnumerator AmongUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            int m = Random.Range(0, among_A.Length);
            if (!among_A[m].activeSelf && !among_B[m].activeSelf)
            {
                among_A[m].GetComponent<Animator>().speed = amongSpeed;
                among_A[m].SetActive(true);
            }

            if (time <= 0)
            {
                among_A[m].SetActive(false);
            }
        }
    }


    public void ReStart()
    {
        StopAllCoroutines();
        gameOverText.SetActive(true);
        time = 0;
        hammer.SetActive(false);
        GameObject.Find("re_start_btn").GetComponent<AudioSource>().Play();
    }

}