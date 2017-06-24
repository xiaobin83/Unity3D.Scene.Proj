using UnityEngine;
using System.Collections;
using UnityEditor;

namespace scene
{
	[CustomEditor(typeof(scene.TiledBackground))]
	public class TiledBackgroundEditor : Editor
	{
		void OnSceneGUI()
		{
			var tiled = target as TiledBackground;

		}

	}
}
