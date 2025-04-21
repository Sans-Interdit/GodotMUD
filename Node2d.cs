using Godot;
using System;

public partial class Node2d : Caracter
{
    protected override float Speed => 300.0f;
    private const float MinJumpForce = -300.0f; // Saut minimum si relâché tôt
    private const float JumpHoldTimeMax = 0.2f; // Durée max pendant laquelle on peut "charger" le saut
    public override void _PhysicsProcess(double delta)
    {
        direction = Vector2.Zero;

        // Lecture des touches (mouvement horizontal uniquement ici, pour rester logique avec la gravité)
        if (Input.IsKeyPressed(Key.D))
            direction.X += 1;
        if (Input.IsKeyPressed(Key.Q))
            direction.X -= 1;

        // Lecture de la touche espace pour sauter
        if (Input.IsKeyPressed(Key.Space))
        {
            jump();
        }

        // Si on est en saut, et que la touche est relâchée trop tôt, on écourte le saut
        if (isJumping)
		{
			jumpTime += (float)delta;

			// Si l'utilisateur relâche la touche espace avant le temps max autorisé
			if (!Input.IsKeyPressed(Key.Space) && velocity.Y < MinJumpForce)
			{
				velocity.Y = MinJumpForce;
				isJumping = false;
			}

			// Après un certain temps, on arrête de moduler le saut
			if (jumpTime > JumpHoldTimeMax)
			{
				isJumping = false;
			}
		}

        base._PhysicsProcess(delta);
    }
}
