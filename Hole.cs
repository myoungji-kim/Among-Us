using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hole : MonoBehaviour, IPointerDownHandler
{
    public int holeNum;
    public among_director among_director;
    public GameObject hammer;
    public ParticleSystem hitEffect;

    private bool clicked;

    public void Start() {
        hammer.SetActive(true);
    }

    public void Update() {
        if (clicked == true) {
            
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        hammer.SetActive(true);
        gameObject.SetActive(false);

        among_director.among_A[holeNum].SetActive(false);
        among_director.among_B[holeNum].SetActive(true);
        
        Vector3 hitPosition;

        switch (holeNum) {
            case 0: hitPosition = new Vector3(9.24f,32.51f,21.52f); break;
            case 1: hitPosition = new Vector3(9.24f,32.51f,11.63f); break;
            case 2: hitPosition = new Vector3(9.24f,32.51f,2.32f); break;
            case 3: hitPosition = new Vector3(17.66f,32.51f,21.52f); break;
            case 4: hitPosition = new Vector3(17.66f,32.51f,11.63f); break;
            case 5: hitPosition = new Vector3(17.66f,32.51f,2.32f); break;
            case 6: hitPosition = new Vector3(26.87f,32.51f,21.52f); break;
            case 7: hitPosition = new Vector3(26.87f,32.51f,11.63f); break;
            case 8: hitPosition = new Vector3(26.87f,32.51f,2.32f); break;
            default : hitPosition = new Vector3(0,0,0); break;
        }

        hammer.transform.position = hitPosition;
        hitEffect.transform.position = hitPosition;

        hitEffect.Play();

        ScoreUp();
    }

    public void OnPointerUp(PointerEventData eventData) {
        
    }

    void ScoreUp()
    {
        GameObject.Find("hammer_audio").GetComponent<AudioSource>().Play();
        GameObject.Find("hit").GetComponent<AudioSource>().Play();
        among_director.score += 10;
        among_director.scoreText.text = among_director.score.ToString();
    }
}