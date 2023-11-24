using UnityEngine;

[CreateAssetMenu(menuName = "Character_Walk Profile")] 
public class WalkProfile : ScriptableObject
{
    [SerializeField] private int speed = 20;
    public int _speed => speed;

}
