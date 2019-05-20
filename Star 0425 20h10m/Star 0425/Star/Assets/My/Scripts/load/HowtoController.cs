﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowtoController : MonoBehaviour
{
    enum direction
    {
        up,
        down,
        right,
        left,
        none
    }

    [SerializeField]
    GameObject UDui;
    [SerializeField]
    GameObject LRui;

    [SerializeField]
    Button LButton;
    [SerializeField]
    Button RButton;

    int imageState;

    int flickDirection;
    Vector3 startTPos;
    Vector3 endTPos;

    float flickRange = 90.0f;

    // Start is called before the first frame update
    void Start()
    {
        imageState = 1;

        LButton.onClick.AddListener(changeImage);
        RButton.onClick.AddListener(changeImage);
    }

    // Update is called once per frame
    void Update()
    {
        Flicker();

        if(flickDirection == (int)direction.right ||
           flickDirection == (int)direction.left)
        {
            imageState *= -1;
            flickDirection = (int)direction.none;
        }

        if(imageState == 1)
        {
            UDui.SetActive(true);
            LRui.SetActive(false);
        }
        else
        {
            UDui.SetActive(false);
            LRui.SetActive(true);
        }
    }

    void changeImage()
    {
        imageState *= -1;
    }

    void Flicker()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTPos = new Vector3(Input.mousePosition.x, 
                                    Input.mousePosition.y,
                                    Input.mousePosition.z);
        }
        if (Input.GetMouseButtonUp(0))
        {
            endTPos = new Vector3(Input.mousePosition.x,
                                  Input.mousePosition.y,
                                  Input.mousePosition.z);
            FlickDirection();
        }
    }

    void FlickDirection()
    {
        float angleX;
        float angleY;

        angleX = endTPos.x - startTPos.x;
        angleY = endTPos.y - startTPos.y;

        if(Mathf.Abs(angleX) >= Mathf.Abs(angleY))
        {
            if(flickRange < angleX)
            {
                flickDirection = (int)direction.right;
            }
            if (-flickRange > angleX)
            {
                flickDirection = (int)direction.left;
            }
        }
        if (Mathf.Abs(angleX) < Mathf.Abs(angleY))
        {
            if (flickRange < angleY)
            {
                flickDirection = (int)direction.up;
            }
            if (-flickRange > angleY)
            {
                flickDirection = (int)direction.down;
            }
        }
    }


}
