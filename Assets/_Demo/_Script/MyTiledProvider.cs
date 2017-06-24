using UnityEngine;
using System.Collections;
using scene;
using System;

[RequireComponent(typeof(scene.TiledBackground))]
public class MyTiledProvider : MonoBehaviour, scene.TiledBackground.TileProvider
{

	public bool debugShowAllTiles;

	bool TiledBackground.TileProvider.showAllTiles
	{
		get
		{
			return debugShowAllTiles;
		}
	}

	void Awake()
	{
		var comp = GetComponent<scene.TiledBackground>();
		comp.tileProvider = this;
	}

	Texture[] allTiles = new Texture[24];

	public Texture GetTile(int tileX, int tileY)
	{
		if (tileX < 0 || tileX >= 4
			|| tileY < 0 ||	tileY >= 6)
		{
			return Texture2D.whiteTexture;
		}
		var index = tileX + (6 - tileY - 1) * 4;
		if (allTiles[index] == null)
			allTiles[index] = Resources.Load<Texture>(string.Format("Tiles/test_{0:D2}", index + 1));
		return allTiles[index];
	}


	public Texture[] GetAllTiles(out int tileX0, out int tileY0, out int tileX1, out int tileY1)
	{
		tileX0 = 0;
		tileY0 = 0;
		tileX1 = 4;
		tileY1 = 6;
		for (int j = tileY0; j < tileY1; ++j)
		{
			for (int i = tileX0; i < tileX1; ++i)
			{
				GetTile(i, j);
			}
		}
		return allTiles;
	}
}
