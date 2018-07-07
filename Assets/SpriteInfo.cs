using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace x600d1dea.scene
{

	[ExecuteInEditMode, RequireComponent(typeof(SpriteRenderer))]
	public class SpriteInfo : MonoBehaviour
	{
		SpriteRenderer spr;

		void OnEnable()
		{
			spr = GetComponent<SpriteRenderer>();
		}

		Vector2 scrollPos = Vector2.zero;
		void OnGUI()
		{
			var bounds = spr.bounds;
			var p = Camera.main.WorldToScreenPoint(bounds.center + bounds.extents);
			p.y = Screen.height - p.y;
			GUILayout.BeginArea(new Rect(p, new Vector2(200, 200)));
			GUILayout.Label("SpriteRenderer info");
			scrollPos = GUILayout.BeginScrollView(scrollPos, false, true);
			GUILayout.Label("spr bounds: " + bounds.ToString());
			GUILayout.Label("sp bounds: " + spr.sprite.border.ToString());
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}

	}
}
