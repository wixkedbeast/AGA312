using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{ 
    protected static Score _S { get { return Score.instance; } }
    protected static AIManager _AIM { get { return AIManager.instance; } }

    protected static FlyingController _P { get { return FlyingController.instance; } }

}
