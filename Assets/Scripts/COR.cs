using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class COR : MonoBehaviour
{
    [SerializeField] float time = 3;
    [SerializeField] bool go = false;
    Coroutine timerCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Timer(time));
        timerCoroutine = StartCoroutine(Timer(time));
        StartCoroutine("StoryTime"); // calls StoryTime()
        StartCoroutine("WaitAction"); // calls WaitAction()
    }

    // Update is called once per frame
    void Update()
    {
        //time -= Time.deltaTime;
        //if (time <= 0)
        //{
        //    time = 3;
        //    print("hello");
        //}
    }

    IEnumerator Timer(float time)
    {
        //for (; ;) //infinite loop
        while (true) 
        { 
            yield return new WaitForSeconds(time);
            // check perception
            print("tic");
        }

        //yield return null;
    }

    IEnumerator StoryTime()
    {
        print("Hello");
        yield return new WaitForSeconds(time);
        print("Welcome to the new world");
        yield return new WaitForSeconds(time);
        print("Time to die.");
        yield return new WaitForSeconds(time);
        StopCoroutine(timerCoroutine);


        yield return null;
    }

    IEnumerator WaitAction() 
    {
        yield return new WaitUntil(() => go);
        print("go");
        yield return null;
    }
}
