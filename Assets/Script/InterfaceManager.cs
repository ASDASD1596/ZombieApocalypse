using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : Singleton<InterfaceManager>
{
    [SerializeField] private Image[] heart;

    private void Start()
    {
        PlayerController.Instance.MapHeart(heart);
    }
}
