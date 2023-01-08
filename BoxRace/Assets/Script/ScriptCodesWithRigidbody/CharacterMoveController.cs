﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveController : MonoBehaviour
{
    float horizontal = 0;
    float placeWidth = 2;
    public float speed;
    //float placeLenght = 40;
    bool speedStop;

    //public GameObject place;
    void Start()
    {
        Time.timeScale = 1;
        //placeWidth = place.GetComponent<Collider>().bounds.size.x / 2;
        //placeLenght = place.GetComponent<Collider>().bounds.size.z / 2;
    }
    private void OnEnable()
    {
        EventManager.SpeedRegulation += SpeedRegulation;
    }
    private void OnDisable()
    {
        EventManager.SpeedRegulation -= SpeedRegulation;
    }
    void SpeedRegulation()
    {
        speedStop = true;
    }
    float SpeedStop()
    {
        if (speedStop==true)
        {
            return speed = 0;
        }
        else
        {
            return speed = 1.5f;
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MouseControl();
        }
    }
    private void LateUpdate()
    {
        MoveControl();
    }
    void MoveControl()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, (-placeWidth), placeWidth);
        //viewPos.z = Mathf.Clamp(viewPos.z, (-placeLenght), placeLenght);
        //viewPos.y = Mathf.Clamp(viewPos.y, 0, 50);
        transform.position = viewPos;
    }

    void MouseControl()
    {
        horizontal = Input.GetAxis("Mouse X");
        Vector3 vec = new Vector3(horizontal, 0, SpeedStop());
        vec = transform.TransformDirection(vec);
        vec.Normalize();
        transform.position += vec * Time.deltaTime * 5f;
    }
    
}
