﻿using UnityEditor;
using UnityEngine;

namespace RadiUX.Unity.Demo {

	/*================================================================================================*/
	[CustomEditor(typeof(SphereContainer))]
	public class SphereContainerEditor : Editor {

		private SphereContainer vItem;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void OnEnable() {
			vItem = (SphereContainer)target;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void OnInspectorGUI() {
			Undo.RecordObject(vItem, vItem.GetType().Name);

			vItem.CenterX = EditorGUILayout.Slider("Center X", vItem.CenterX, -180f, 180f);
			vItem.CenterY = EditorGUILayout.Slider("Center Y", vItem.CenterY, -180f, 180f);
			vItem.CenterZ = EditorGUILayout.Slider("Center Z", vItem.CenterZ, -10f, 10f);

			if ( GUI.changed ) {
				EditorUtility.SetDirty(vItem);
			}
		}

	}

}
