using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFood", menuName = "Food/NewFood")]
public class FoodData : ScriptableObject
{
    public Sprite ImageData;
    public List<Vector2> PolygonPointList;
}
