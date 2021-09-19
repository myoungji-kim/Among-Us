using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class among : MonoBehaviour
{
    public int amongNum;
    public among_director among_director;


   void DisableObj()
    {
        gameObject.SetActive(false);
    }

    void HoleOn()
    {
        among_director.hole[amongNum].SetActive(true);
    }
    void HoleOff()
    {
        among_director.hole[amongNum].SetActive(false);
    }
}
