﻿using UnityEngine;
using System.Collections.Generic;

public class ProxyObj_Locker : ProxyObj_Interact
{
    public ProxyType Type;

    public enum ProxyType
    {
        Standard = 0,
        Foot,
        Short,
        Wide,

        Pegboard = 100,
    }

    [Tooltip("The MadCards of the items in this locker.")]
    public List<string> Contents = new List<string>();
}

public class ProxyObj_Interact : ProxyObj
{


}

