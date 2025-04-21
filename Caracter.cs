using Godot;
using System;

public partial class Caracter : CharacterBody2D
{
    protected virtual float Speed => 150.0f;
	private const float Gravity = 1500.0f;
	private const float JumpForce = -600.0f;

    protected Vector2 velocity = Vector2.Zero;
    protected Vector2 direction = Vector2.Zero;
    protected bool isJumping = false;
    protected float jumpTime = 0f;
	
	public override void _PhysicsProcess(double delta)
	{
		// Applique la gravité
		velocity.Y += Gravity * (float)delta;

        // Déplacement horizontal
        if (direction != Vector2.Zero)
            Console.WriteLine(direction);
            direction = direction.Normalized();

        velocity.X = direction.X * Speed;
        // Appelle le déplacement physique avec glissement
        Velocity = velocity;
		MoveAndSlide();

		// Met à jour la vélocité interne pour le prochain frame
		velocity = Velocity;
	}

	protected void jump()
    {
        if (IsOnFloor())
        {
            velocity.Y = JumpForce;
            isJumping = true;
            jumpTime = 0f;
        }
    }

    public override void _Draw()
	{
		// Dessine un cercle rouge à la position du corps
		DrawCircle(Vector2.Zero, 40, new Color(1, 0, 0)); // Vector2.Zero car on dessine localement
	}
}
