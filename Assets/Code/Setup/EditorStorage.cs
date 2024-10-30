﻿using UnityEngine;
using System.Collections.Generic;

public class EditorStorage : ScriptableObject
{
    public Mesh Fallback;
    //[Space(20)] public List<MeshDisplay> Fallback = new List<MeshDisplay>();
    [Space(20)] public List<MeshDisplay_Doors> Doors = new List<MeshDisplay_Doors>();
    [Space(20)] public List<MeshDisplay_Cover> Cover = new List<MeshDisplay_Cover>();
    [Space(20)] public List<MeshDisplay_Lockers> Lockers = new List<MeshDisplay_Lockers>();


    private void OnEnable()
    {
        foreach (MeshDisplay_Doors md in Doors)
            md.name = " > " + md.Type.ToString();
        foreach (MeshDisplay_Cover md in Cover)
            md.name = " > " + md.Type.ToString();
        foreach (MeshDisplay_Lockers md in Lockers)
            md.name = " > " + md.Type.ToString();
    }



    [System.Serializable]
    public class MeshDisplay
    {
        [HideInInspector] public string name;
        public Mesh Mesh;
        //public List<string> Types;
    }

    [System.Serializable]
    public class MeshDisplay_Doors : MeshDisplay
    {
        public ProxyObj_Door.ProxyType Type;
    }
    [System.Serializable]
    public class MeshDisplay_Cover : MeshDisplay
    {
        public ProxyObj_Cover.ProxyType Type;
    }
    [System.Serializable]
    public class MeshDisplay_Lockers : MeshDisplay
    {
        public ProxyObj_Locker.ProxyType Type;
    }
}