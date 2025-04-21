using Godot;
using System;

public partial class Mur : StaticBody2D
{
	private float len = 1000;
    private float height = 20;
    public override void _Draw()
	{
		// Un mur noir de 1000x20
		DrawRect(new Rect2(new Vector2(-len/2, -height/2), new Vector2(len, height)), new Color(0, 0, 0));
	}
}
