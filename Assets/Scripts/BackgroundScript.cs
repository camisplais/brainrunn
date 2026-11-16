using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public float velocidad;
    float ancho;

    void Start()
    {
        ancho = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);

        if (transform.position.x <= -ancho)
            transform.position += Vector3.right * ancho * 2;
    }
}
