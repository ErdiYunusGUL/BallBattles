using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
   
    public EnemyT  enemyType;
    public enum EnemyT
    {
        Normal,
        Fast,
        Mini,
        MiniFast,
        Boss
    }
}



