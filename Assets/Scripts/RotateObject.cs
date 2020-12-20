using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float RotationStep;
    float rotation_speed = 0;

    private WebConnection _states;
    // Start is called before the first frame update
    void Start()
    {
        _states = GameObject.FindGameObjectWithTag("States").GetComponent<WebConnection>();

        _states.ConnectToDelegate("Add rotation speed", () => { rotation_speed += RotationStep; Debug.Log("Added to " + rotation_speed); });
        _states.ConnectToDelegate("Sub rotation speed", () => { rotation_speed -= RotationStep; Debug.Log("Added to " + rotation_speed); });
        _states.ConnectToDelegate("Stop rotation", () => { rotation_speed = 0; Debug.Log("Canceled rotation"); });
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.y = rotation.y < 360 ? rotation.y + rotation_speed : 0;
        Quaternion quaternion = new Quaternion();
        quaternion.eulerAngles = rotation;
        transform.rotation = quaternion;
    }
}
