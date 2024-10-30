using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

// These are used by the find-parent code at the very bottom, which was needed for the Test Wave button.
using System.Reflection; // Used for:  BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance
using System;
using System.Linq;

class Wave_Generator_GUI : Editor
{


}
class CharacterDrawer_Base : PropertyDrawer
{

	protected string GetCharacterName(SerializedProperty property)
    {
		string mc = property.FindPropertyRelative("MadCard").stringValue;
		return mc == null || mc == "" || mc == "NONE" ? property.FindPropertyRelative("Character").enumDisplayNames[property.FindPropertyRelative("Character").enumValueIndex] : mc;
	}

}

[CanEditMultipleObjects]
[CustomPropertyDrawer( typeof( WaveCharacter_STP ) )]
class WaveCharacterDrawer : CharacterDrawer_Base
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		// Begin, Cancel Indent (but store for restore at end)
		EditorGUI.BeginProperty(position, label, property);
		var indent = EditorGUI.indentLevel;

		////////////////////////////////////////////////////////

		// Pre-Calculations //

		//StatCard_Character myDude = (property.FindPropertyRelative("Type").objectReferenceValue as System.Object as StatCard_Character);
		//label.text = myDude ? myDude.ShortName : " ";
		label.text = GetCharacterName(property);

		////////////////////////////////////////////////////////

		// Label
		GUI.color = (Color.white * 3f + Color.red) / 3.5f;
		position = 	EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
		GUI.color = Color.white;


				// Indent <<<
				EditorGUI.indentLevel = 0;

		//Rect rect0 = new Rect(position.x, position.y + height, position.width - 85, 16);
		//Rect rect0b = new Rect(position.x + position.width - 80, position.y + height, 80, 16); height += 18;

		// Rectangles
		int xPos = 0;
		Rect rect_Amount = new Rect(position.x,      position.y, 30, 				  position.height / 2f);
		Rect rect_Type =   new Rect(position.x + 35, position.y, position.width - 35 - 85, position.height / 2f);
		Rect rect_TypeB = new Rect(position.x + position.width - 80, position.y, 80, position.height / 2f);	
		Rect rect_Scale = new Rect(position.x, position.y + 18, position.width, position.height / 2f);
		//Rect rect_Scale = new Rect(position.x, position.y + 18, position.width - 35, position.height / 2f);
		//Rect rect_Exp = new Rect(position.x + position.width - 30, position.y + 18, 30, position.height / 2f);

		//Rect nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

		// Draw fields - passs GUIContent.none to each so they are drawn without labels
		GUI.backgroundColor = Color.red + Color.white * 0.5f;
		EditorGUI.PropertyField(rect_Amount, property.FindPropertyRelative("Total"), GUIContent.none);
		EditorGUI.PropertyField(rect_Type, property.FindPropertyRelative("MadCard"), GUIContent.none); EditorGUI.PropertyField(rect_TypeB, property.FindPropertyRelative("Character"), GUIContent.none);
		GUI.backgroundColor = Color.red + Color.white * 0.75f + Color.yellow * 0.75f;
		EditorGUI.Slider(rect_Scale, property.FindPropertyRelative("GenerationScale"), 0, 1, GUIContent.none);
		//EditorGUI.PropertyField(rect_Exp, property.FindPropertyRelative("GenerationExponentArc"), GUIContent.none);
		GUI.backgroundColor = Color.white;

				// Indent >>>
				EditorGUI.indentLevel = indent;

		////////////////////////////////////////////////////////

		// End, and Restore Indent to Default
		EditorGUI.EndProperty();

	}

	// https://forum.unity3d.com/threads/custom-property-drawer-height-and-width-solved.469692/
	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		// Increases height of this area
		return base.GetPropertyHeight(property, label) + 18;
	} 

}


[CanEditMultipleObjects]
[CustomPropertyDrawer( typeof(SingleCharacter_STP) )]
class SingleCharacterDrawer : CharacterDrawer_Base
{
	
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		// Begin, Cancel Indent (but store for restore at end)
		EditorGUI.BeginProperty(position, label, property);
		var indent = EditorGUI.indentLevel;

		////////////////////////////////////////////////////////

		// Pre-Calculations //
		//StatCard_Character myDude = (property.FindPropertyRelative("Type").objectReferenceValue as System.Object as StatCard_Character);
		//label.text = myDude ? myDude.FullName : " ";
		label.text = GetCharacterName(property);

		////////////////////////////////////////////////////////

		// Label
		GUI.color = (Color.white * 3f + Color.blue) / 3.5f;
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
		GUI.color = Color.white;


				// Indent <<<
				EditorGUI.indentLevel = 0;

		// Rectangles
		int height = 0;
		Rect rect0 = new Rect(position.x, position.y + height, position.width - 85, 16); 
		Rect rect0b= new Rect(position.x + position.width - 80, position.y + height, 80, 16); height += 18;
		Rect rect1 = new Rect(position.x, position.y + height, position.width, 16); height += 18;
		Rect rect2 = new Rect(position.x, position.y + height, position.width, 16); height += 16;
		Rect rect3 = new Rect(position.x, position.y + height, position.width, 16); height += 18;
		Rect rect4 = new Rect(position.x, position.y + height, position.width, 16); height += 18;
		Rect rect5 = new Rect(position.x, position.y + height, position.width, 16); height += 18;
		Rect rect6 = new Rect(position.x, position.y + height, position.width, 16);
		//Rect nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

		// Draw fields - passs GUIContent.none to each so they are drawn without labels
		GUI.backgroundColor = Color.blue + Color.white * 0.5f;
		//EditorGUI.PropertyField(rect0, property.FindPropertyRelative("Type"), GUIContent.none);
		//public string MadCard = "NONE";
		//public CharacterTypes Character;
		EditorGUI.PropertyField(rect0, property.FindPropertyRelative("MadCard"), GUIContent.none); EditorGUI.PropertyField(rect0b, property.FindPropertyRelative("Character"), GUIContent.none);
		EditorGUI.PropertyField(rect1, property.FindPropertyRelative("SerialNumber"), new GUIContent("Serial#"));
		EditorGUI.PropertyField(rect2, property.FindPropertyRelative("Weapon"), new GUIContent("Weapon"));
		EditorGUI.PropertyField(rect3, property.FindPropertyRelative("Sidearm"),new GUIContent("Sidearm"));
		EditorGUI.PropertyField(rect4, property.FindPropertyRelative("Throwable"),new GUIContent("Thrown"));
		EditorGUI.PropertyField(rect5, property.FindPropertyRelative("Key"), new GUIContent("Key"), true);
        EditorGUI.PropertyField(rect6, property.FindPropertyRelative("Gear"), new GUIContent("Gear"), true);
        GUI.backgroundColor = Color.white;

				// Indent >>>
				EditorGUI.indentLevel = indent;

		////////////////////////////////////////////////////////

		// End, and Restore Indent to Default
		EditorGUI.EndProperty();

	}

	float myHeightBonus = 0;
	// https://forum.unity3d.com/threads/custom-property-drawer-height-and-width-solved.469692/
	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		//Debug.Log("(GPH) " + property.displayName + ": " + myHeightBonus);
		myHeightBonus = (6 + property.FindPropertyRelative("Gear").Copy().CountInProperty() - 1) * 18;

		// Increases height of this area
		return base.GetPropertyHeight(property, label) + myHeightBonus;
	} 
}
















[CanEditMultipleObjects]
[CustomPropertyDrawer(typeof(WeaponLoadout_STP))]
class WeaponLoadoutDrawer : PropertyDrawer
{

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		// Begin, Cancel Indent (but store for restore at end)
		EditorGUI.BeginProperty(position, label, property);
		var indent = EditorGUI.indentLevel;

		////////////////////////////////////////////////////////

		// Pre-Calculations //

		label.text = "Loadout " + property.displayName.Replace("Element ", "");

		////////////////////////////////////////////////////////

		// Label
		GUI.color = (Color.white);
		GUI.backgroundColor = (Color.white * 0.1f);
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
		GUI.color = Color.white;


		// Indent <<<
		EditorGUI.indentLevel = 0;

		// Rectangles
		Rect rect_Amount = new Rect(position.x, position.y, 30, position.height);
		Rect rect_Type = new Rect(position.x + 35, position.y, position.width - 35, position.height);
		//Rect nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

		// Draw fields - passs GUIContent.none to each so they are drawn without labels
		GUI.backgroundColor = (Color.black);
		EditorGUI.PropertyField(rect_Amount, property.FindPropertyRelative("Count"), GUIContent.none);
		EditorGUI.PropertyField(rect_Type, property.FindPropertyRelative("Loadout"), GUIContent.none);
		GUI.backgroundColor = Color.white;

		// NO LONGER USEFUL
		// Clamp Value
		//if (property.FindPropertyRelative("Loadout").objectReferenceValue != null && property.FindPropertyRelative("Count").intValue > (property.FindPropertyRelative("Loadout").objectReferenceValue as System.Object as StatCard_Loadout).ReturnFinalWeaponCount()) 
		//	property.FindPropertyRelative("Count").intValue = (property.FindPropertyRelative("Loadout").objectReferenceValue as System.Object as StatCard_Loadout).ReturnFinalWeaponCount(); // Randomize if 0!
		//else if (property.FindPropertyRelative("Count").intValue < 0)
		//	property.FindPropertyRelative("Count").intValue = 0;
		property.FindPropertyRelative("Count").intValue = Mathf.Max(0, property.FindPropertyRelative("Count").intValue);

		// Indent >>>
		EditorGUI.indentLevel = indent;

		////////////////////////////////////////////////////////

		// End, and Restore Indent to Default
		EditorGUI.EndProperty();

	}
}






[CanEditMultipleObjects]
[CustomPropertyDrawer(typeof(WeaponDraft_STP))]
class WeaponDraftDrawer : PropertyDrawer
{

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		// Begin, Cancel Indent (but store for restore at end)
		EditorGUI.BeginProperty(position, label, property);
		var indent = EditorGUI.indentLevel;

		////////////////////////////////////////////////////////

		// Pre-Calculations //

		label.text = "Squad " + property.FindPropertyRelative("SquadNumber").intValue + ":";

		////////////////////////////////////////////////////////

		// Label
		GUI.color = (Color.white * 3f + Color.yellow) / 3.5f;
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
		GUI.color = Color.white;


		// Indent <<<
		EditorGUI.indentLevel = 0;

		// Rectangles
		Rect rect_Wave = new Rect(position.x, position.y, 35, position.height);
		Rect rect_Type = new Rect(position.x + 40, position.y, position.width - 40, position.height);
		//Rect nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

		// Draw fields - passs GUIContent.none to each so they are drawn without labels
		GUI.backgroundColor = Color.yellow + Color.white * 0.5f;
		EditorGUI.PropertyField(rect_Wave, property.FindPropertyRelative("SquadNumber"), GUIContent.none);
		EditorGUI.PropertyField(rect_Type, property.FindPropertyRelative("Type"), GUIContent.none);
		GUI.backgroundColor = Color.white;

		// Indent >>>
		EditorGUI.indentLevel = indent;

		////////////////////////////////////////////////////////

		// End, and Restore Indent to Default
		EditorGUI.EndProperty();

	}
}











[CanEditMultipleObjects]
[CustomPropertyDrawer( typeof(WaveSquad_STP) )]
class WaveSquadDrawer : PropertyDrawer
{

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		// Begin, Cancel Indent (but store for restore at end)
		EditorGUI.BeginProperty(position, label, property);
		var indent = EditorGUI.indentLevel;

		////////////////////////////////////////////////////////

		// Pre-Calculations //
		//StatCard_Character myDude = (property.FindPropertyRelative("Type").objectReferenceValue as System.Object as StatCard_Character);
		//label.text = "Squad ";// + property.displayName.Replace("Element ", "");

		////////////////////////////////////////////////////////

		// Label
		//GUI.color = (Color.white * 3f + Color.blue) / 3.5f;
		//position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
		//GUI.color = Color.white;


		// Indent <<<
		//EditorGUI.indentLevel = 0;

		// Rectangles
		Rect rect_SpawnOrder = new Rect(position.x + position.width * 0.5f, position.y,      position.width * 0.5f, 16); 
		Rect rect_Units = 	   new Rect(position.x, position.y, position.width, 16); 
		//Rect nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

		// Draw fields - passs GUIContent.none to each so they are drawn without labels
		GUI.backgroundColor = Color.blue + Color.white * 0.5f;
		EditorGUI.PropertyField(rect_SpawnOrder, property.FindPropertyRelative("SpawnOrder"), new GUIContent("Spawn Order #:"));
		EditorGUI.PropertyField(rect_Units, property.FindPropertyRelative("SquadUnits"), new GUIContent("Squad " + property.displayName.Replace("Element ", "")), true);
		GUI.backgroundColor = Color.white;


		// Indent >>>
		//EditorGUI.indentLevel = indent;

		////////////////////////////////////////////////////////

		// End, and Restore Indent to Default
		EditorGUI.EndProperty();

	}

	// https://forum.unity3d.com/threads/custom-property-drawer-height-and-width-solved.469692/
	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		// Increases height of this area
		return EditorGUI.GetPropertyHeight(property.FindPropertyRelative("SquadUnits"), label, true);
		//return Mathf.Max(1, property.CountInProperty() - 2) * 18;
	}
}






[CanEditMultipleObjects]
[CustomPropertyDrawer( typeof(WaveSpawn_STP) )]
class WaveSpawnDrawer : PropertyDrawer
{

	//bool foldout = false;
	Dictionary<string, bool> unfold = new Dictionary<string, bool> ();

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		
		// Begin, Cancel Indent (but store for restore at end)
		EditorGUI.BeginProperty(position, label, property);
		var indent = EditorGUI.indentLevel;

		////////////////////////////////////////////////////////

		// Pre-Calculations //
		//StatCard_Character myDude = (property.FindPropertyRelative("Type").objectReferenceValue as System.Object as StatCard_Character);
		label.text = "**WAVE ";
		if (property.displayName.Contains("Element")) label.text += (System.Int32.Parse(property.displayName.Replace("Element ", "")) + 1).ToString() + " "; 
		label.text += "**";
		// Writeup //
			//string waveAnalysis = " [";
			// Insert Calculations Here
			//waveAnalysis += "]";
			//label.text += waveAnalysis;
		////////////////////////////////////////////////////////

		// Label
		GUI.color = (Color.white * 3f + Color.yellow) / 3.5f;
			//float positionXWas = position.x;
		//EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
			//position.x = positionXWas + (position);
			//position.x += 16f; position.width -= 18f;

		// Foldout
		Rect rect_Foldout = new Rect(position.x, position.y, position.width * 0.2f, 18f);
		if (!unfold.ContainsKey (property.propertyPath)) // Add this PROPERTY to the unfold dictionary.
			unfold.Add (property.propertyPath, true);
		unfold[property.propertyPath] = EditorGUI.Foldout(rect_Foldout, unfold[property.propertyPath], label);
			
		GUI.color = Color.white;
		if (unfold[property.propertyPath]) {

		//BEGINNING OF FOLDOUT//////////////////////////////////////////////////////

					// Indent <<<
					EditorGUI.indentLevel = 2;


			// Rectangles
			totalHeight = 18;// 0;//18;
			float intWidth = position.width / 12f;
			//Rect desc_Int1 = new Rect(position.x + intWidth * 0f, 	position.y + totalHeight, intWidth * 3f, 16);
			//Rect rect_Int1 = new Rect(position.x + intWidth * 2f, 	position.y + totalHeight, intWidth * 2f, 16);
			float heightDiff = 0f; // 8f;
			Rect desc_Int2 = 	new Rect (position.x + intWidth * 4f, 	position.y + totalHeight + heightDiff, intWidth * 2f, 16);
			Rect rect_Int2 = 	new Rect (position.x + intWidth * 5.75f,position.y + totalHeight + heightDiff, intWidth * 2f, 16);
			Rect desc_Int3 = 	new Rect (position.x + intWidth * 6.5f, position.y + totalHeight + heightDiff, intWidth * 2f, 16);
			Rect rect_Int3 = 	new Rect (position.x + intWidth * 8f, 	position.y + totalHeight + heightDiff, intWidth * 2f, 16);
			Rect rect_TestWave =new Rect (position.x + intWidth * 9.75f,position.y + totalHeight + heightDiff - 8f, intWidth * 2f, 16f + 8f);

			//totalHeight += 18;


			Rect rect_Units =   	new Rect(position.x, position.y + totalHeight,	position.width, 16);
			totalHeight += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("WaveUnits"), label, true);

			Rect rect_WeaponStock = new Rect(position.x, position.y + totalHeight, 	position.width, 16); 
			totalHeight += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("WeaponStock"), label, true);

				// Only draw if STOCK is expanded!
				Rect rect_StockSeed = new Rect (position.x + 15f, position.y + totalHeight + heightDiff, position.width - 30f, 16f);
				if (property.FindPropertyRelative("WeaponStock").isExpanded)
					totalHeight += 18;

			Rect rect_WeaponDrafts = new Rect(position.x, position.y + totalHeight,	position.width, 16); 
			totalHeight += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("WeaponDrafts"), label, true);

			Rect rect_Bosses = 	new Rect(position.x, position.y + totalHeight, 		position.width, 16); 
			totalHeight += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("Bosses"), label, true);

			Rect rect_Squads = 	new Rect(position.x, position.y + totalHeight, 		position.width, 16); 
			totalHeight += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("CustomSquads"), label, true);

			GUI.color = (Color.white * 3f + Color.yellow) / 3.5f;
			EditorGUI.PrefixLabel(desc_Int2, GUIUtility.GetControlID(FocusType.Passive), new GUIContent("Squad"));
			EditorGUI.PropertyField(rect_Int2, property.FindPropertyRelative("MaxSquadSize"), GUIContent.none);
			//EditorGUI.PrefixLabel(desc_Int2, GUIUtility.GetControlID(FocusType.Passive), new GUIContent("Ideal Units"));
			//EditorGUI.PropertyField(rect_Int2, property.FindPropertyRelative("IdealUnitCount"), GUIContent.none);
			EditorGUI.PrefixLabel(desc_Int3, GUIUtility.GetControlID(FocusType.Passive), new GUIContent("Max"));
			EditorGUI.PropertyField(rect_Int3, property.FindPropertyRelative("MaxUnitCount"), GUIContent.none);
			GUI.color = Color.white;

			// Squad Count Default (Can't be 0)
			if (property.FindPropertyRelative("MaxSquadSize").intValue == 0) 
				property.FindPropertyRelative("MaxSquadSize").intValue = 3; // Randomize if 0!
			if (property.FindPropertyRelative("MaxUnitCount").intValue == 0) 
				property.FindPropertyRelative("MaxUnitCount").intValue = 4; // Randomize if 0!
			
			EditorGUI.PropertyField(rect_Units, property.FindPropertyRelative("WaveUnits"), new GUIContent("Units"), true);
			EditorGUI.PropertyField(rect_WeaponStock, property.FindPropertyRelative("WeaponStock"), new GUIContent("Weapon Stockpiles"), true);
			EditorGUI.PropertyField(rect_WeaponDrafts, property.FindPropertyRelative("WeaponDrafts"), new GUIContent("Weapon Draft Rules"), true);
			EditorGUI.PropertyField(rect_Bosses, property.FindPropertyRelative("Bosses"), new GUIContent("Bosses"), true);
			EditorGUI.PropertyField(rect_Squads, property.FindPropertyRelative("CustomSquads"), new GUIContent("Custom Squads"), true);

			// Weapon Stock Slider (Only appears if WeaponStock is expanded)
			if (property.FindPropertyRelative("WeaponStock").isExpanded)
				EditorGUI.IntSlider(rect_StockSeed, property.FindPropertyRelative("WeaponStock_RandomSeed"), -1, 999999, new GUIContent("Weapon Random Seed"));
			if (property.FindPropertyRelative("WeaponStock_RandomSeed").intValue == 0) 
				property.FindPropertyRelative("WeaponStock_RandomSeed").intValue = UnityEngine.Random.Range(1, 1000000); // Randomize if 0!

			////////////////////////////////////////////////////////

			
//GUI.color = Color.white;


			// Draw Line
			//EditorGUI.DrawRect( new Rect(position.x + 32, position.y + totalHeight + 8f, position.width * 0.75f, 2), Color.white * 0.5f); // Draw a Line
			EditorGUI.DrawRect( new Rect(position.x + 8f, position.y + 12f, 2, totalHeight - 12f), Color.white * 0.5f); // Draw a Line

			// END OF FOLDOUT //////////////////////////////////////////////////////
		}

				// Indent >>>
				EditorGUI.indentLevel = indent;


		// End, and Restore Indent to Default
		EditorGUI.EndProperty();

	}


	// https://forum.unity3d.com/threads/custom-property-drawer-height-and-width-solved.469692/
	[SerializeField]
	public float totalHeight;
	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		// Increases height of this area
		if (unfold.ContainsKey(property.propertyPath) && !unfold[property.propertyPath])
			return 18f;
		else
			return
				 // 18f // Squad/Unit Ints
				+ EditorGUI.GetPropertyHeight(property.FindPropertyRelative("WaveUnits"), label, true)
				+ EditorGUI.GetPropertyHeight(property.FindPropertyRelative("WeaponStock"), label, true)
				+ (property.FindPropertyRelative("WeaponStock").isExpanded ? 18f : 0f) // Weapon Stock Seed Slider (only if Stock is expanded!)
				+ EditorGUI.GetPropertyHeight(property.FindPropertyRelative("WeaponDrafts"), label, true)
				+ EditorGUI.GetPropertyHeight(property.FindPropertyRelative("Bosses"), label, true)
				+ EditorGUI.GetPropertyHeight(property.FindPropertyRelative("CustomSquads"), label, true)
				+ 18f // Buffer
				+ 18f // 2024 Buffer
				;
	}









							// Used by the Test Wave Order button! //

							//http://answers.unity3d.com/questions/425012/get-the-instance-the-serializedproperty-belongs-to.html

							public object GetParent(SerializedProperty prop)
							{
								string path = prop.propertyPath.Replace(".Array.data[", "[");
								object obj = prop.serializedObject.targetObject;
								string[] elements = path.Split('.');
								foreach(string element in elements)
								{
									if(element.Contains("["))
									{
										var elementName = element.Substring(0, element.IndexOf("["));
										var index = Convert.ToInt32(element.Substring(element.IndexOf("[")).Replace("[","").Replace("]",""));
										obj = GetValue(obj, elementName, index);
									}
									else
									{
										obj = GetValue(obj, element);
									}
								}
								return obj;
							}

							public object GetValue(object source, string name)
							{
								if(source == null)
									return null;
								var type = source.GetType();
								var f = type.GetField(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
								if(f == null)
								{
									var p = type.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
									if(p == null)
										return null;
									return p.GetValue(source, null);
								}
								return f.GetValue(source);
							}

							public object GetValue(object source, string name, int index)
							{
								var enumerable = GetValue(source, name) as IEnumerable;
								var enm = enumerable.GetEnumerator();
								while(index-- >= 0)
									enm.MoveNext();
								return enm.Current;
							}
}