﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 rotateAngle = default;

    void Update()
    {
        transform.Rotate(rotateAngle * Time.deltaTime);
    }
}
