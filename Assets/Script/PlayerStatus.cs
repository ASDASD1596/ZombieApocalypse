using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerStatus")]
public class PlayerStatus : ScriptableObject
{
    //Player Stats
    [SerializeField] private float atk;
    [SerializeField] private float moveSpeed;
    
    //Gun Status
    [SerializeField] private float reloadSpeed;
    [SerializeField] private float fireRate;
    [SerializeField] private int maxMagazine;
}
