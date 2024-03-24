using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket1 : MonoBehaviour {

	public float movementSpeed;

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
	{
		float v = Input.GetAxisRaw("Vertical");

		GetComponent<Rigidbody2D> ().velocity = new Vector2(0, v) * movementSpeed;

        // Verificar si hay toques en la pantalla
        if (Input.touchCount > 0)
        {
            // Obtener el primer toque
            Touch touch = Input.GetTouch(0);

            // Convertir la posición del toque a coordenadas del mundo
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            // Obtener la posición actual de la raqueta
            Vector2 currentPosition = rb2D.position;

            // Comparar la posición del toque con la posición actual de la raqueta
            if (touchPosition.y > currentPosition.y)
            {
                // Mover la raqueta hacia arriba
                rb2D.velocity = new Vector2(0, 1) * movementSpeed;
            }
            else if (touchPosition.y < currentPosition.y)
            {
                // Mover la raqueta hacia abajo
                rb2D.velocity = new Vector2(0, -1) * movementSpeed;
            }
            else
            {
                // Detener el movimiento si la posición del toque es igual a la posición de la raqueta
                rb2D.velocity = Vector2.zero;
            }
        }
        else
        {
            // Si no hay toques, detener el movimiento de la raqueta
            rb2D.velocity = Vector2.zero;
        }
    }
}


