using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : Singleton<InterfaceManager>
{
    [SerializeField] private Image[] heart;

    [SerializeField] private CanvasGroup hudPanel;
    [SerializeField] private CanvasGroup shopPanel;

    [SerializeField] private float transitionTime;

    private bool _isOnShop = false;
    
    private void Start()
    {
        PlayerController.Instance.MapHeart(heart);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleShop();
        }
    }

    public void CheckPocket()
    {
        if (MoneyCounter.Instance.totalCoins < 5)
            shopPanel.interactable = false;
        else
            shopPanel.interactable = true;
    }

    private void ToggleShop()
    {
        if (_isOnShop)
        {
            Time.timeScale = 0f;
            
            hudPanel.DOFade(0f, transitionTime).SetUpdate(true);
            shopPanel.DOFade(1f, transitionTime).SetUpdate(true);
            
            shopPanel.blocksRaycasts = true;
            CheckPocket();
            
            hudPanel.interactable = false;
            hudPanel.blocksRaycasts = false;
        }
        else
        {
            hudPanel.DOFade(1f, transitionTime).SetUpdate(true).OnComplete(()=> Time.timeScale = 1f);
            shopPanel.DOFade(0f, transitionTime).SetUpdate(true);
            
            shopPanel.interactable = false;
            shopPanel.blocksRaycasts = false;
            
            hudPanel.interactable = true;
            hudPanel.blocksRaycasts = true;
        }
        
        _isOnShop = !_isOnShop;
    }
}
