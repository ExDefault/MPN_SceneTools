﻿using UnityEngine;

public class ProxyObj_Playground : ProxyObj
{
    [Tooltip("The Playgorund control room will mask away a wall its the window isn't obstructed. \n\nWARNING: This will also mask out a ton of visual effects, like blood and selection outlines. We recommend cutting a hole n your geometry for the window to line up with.")]
    public bool ApplyWindowMask = false;
    [Tooltip("Enable scaffolding visuals.")]
    public bool ScaffoldLegs = false;
}