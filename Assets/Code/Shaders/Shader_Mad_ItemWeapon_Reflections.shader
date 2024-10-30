﻿Shader  "Madness/Items - Weapon +Reflect" {
	Properties {
			_MainTex ( "Texture", 2D) = "white" {}
			_EffectMap("*** Effect Map <--- USE THIS!", 2D) = "black" {}
			_BloodTex ( "Blood", 2D) = "red" {}
			_ToneLimit ( "2-Tone Depth", Range (-0.5,1.5) ) = 0.5		// How far from light the normal must be to tint it.
	 		_TonePower ( "2-Tone Strength", Range (0, 1) ) = 0.5		// See-through of the tone
	 		_Outline ( "Outline Thickness", Range (0.05, 0.4) ) = 0.05
	 		_OutlineColor ( "Outline Color", Color ) = (0, 0, 0, 1)
			_TintColor ( "Tint Color", Color ) = (0, 0, 0, 0)
			
			_Cube("Reflection Cube", Cube) = "" {}
					_CubeMap("UNUSED: Cube Map", 2D) = "black" {}
			_CubeAmount("Reflect Amount", range(0,5)) = 1
			_BumpMap("Distort Map", 2D) = "bump" {}
			_BumpAmt("Distortion", range(0,5)) = 0.1
	}
	
	SubShader {
	
	
		Tags { "RenderType" = "Opaque" }
		Tags { "Queue" = "Geometry+20" } 	// These are for outline behind walls. Transparency+50 is the old amount, but that would make these items overlap-silhouette EACHOTHER.


/////////////////////////////////////////
//			SILHOUETTE
/////////////////////////////////////////
		//UsePass "Madness/StoredPasses/Outline/SILHOUETTE"
		
		
/////////////////////////////////////////
//			TOON OUTLINE
/////////////////////////////////////////
		UsePass "Madness/StoredPasses/Outline/OUTLINE"

		
/////////////////////////////////////////
//			PRIMARY LIGHTS
/////////////////////////////////////////
		UsePass "Madness/StoredPasses/Primary/PRIMARYWEAPON_EMISSION" // TO-DO: Weapons use PRIMARYBASIC, and we need a version that uses the EMISSION MAP

/////////////////////////////////////////
//			REFLECTION
/////////////////////////////////////////
		UsePass "Madness/StoredPasses/Secondary/REFLECTIONS"

/////////////////////////////////////////
//		SECONDARY LIGHTS
/////////////////////////////////////////
		UsePass "Madness/StoredPasses/Secondary/SECONDARYTERRAIN_IMPROVED"


/////////////////////////////////////////
//		SHADOW PASS
/////////////////////////////////////////
		UsePass "Madness/StoredPasses/Misc/SHADOWPASS"

	
	}
	//Fallback "Diffuse"
}