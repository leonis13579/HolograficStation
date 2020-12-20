using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    private WebConnection _states;
    // Start is called before the first frame update
    void Start()
    {
        _states = GameObject.FindGameObjectWithTag("States").GetComponent<WebConnection>();

        _states.ConnectToDelegate("Show: Cube", () => { changeObject("Cube"); });
        _states.ConnectToDelegate("Show: Sphere", () => { changeObject("Sphere"); });
        _states.ConnectToDelegate("Show: Capsule", () => { changeObject("Capsule"); });
        _states.ConnectToDelegate("Show: Cylinder", () => { changeObject("Cylinder"); });
    }

    void changeObject(string gameObjectName)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(transform.GetChild(i).gameObject.name.Equals(gameObjectName));
        }
    }
}
