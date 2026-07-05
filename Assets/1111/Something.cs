using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Something : MonoBehaviour
{
    public TalkBar talkBar;
    void Start()
    {
        talkBar.Init(true);
    }
}
