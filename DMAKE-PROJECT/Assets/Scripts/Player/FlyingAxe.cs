using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAxe : MonoBehaviour
{
    [Range(15f, 30f)]
    public float speed = 15f;

    private float rotationSpeed = 300f;

    private float minSpeed;
    private float originalSpeed;

    private Vector2 shootDirection;

    private void Start()
    {
        minSpeed = speed / 3f;
        originalSpeed = speed;

        shootDirection = Input.mousePosition;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - (Vector2)Player.Instance.transform.position;

        StartCoroutine(FlyRoutine());
    }

    private void Update()
    {
        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
    }

    private IEnumerator FlyRoutine()
    {
        Vector2 direction = new Vector2(shootDirection.x, shootDirection.y).normalized;

        Vector2 initialPlayerPos = Player.Instance.transform.position;

        while (Vector2.Distance(transform.position, initialPlayerPos) < 4f)
        {
            if (speed > minSpeed) speed -= 0.1f;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
            yield return null;
        }

        while(Vector2.Distance(transform.position, Player.Instance.axeSprite.transform.position) > 0.1f)
        {
            if (speed < originalSpeed) speed += 0.1f;
            transform.position = 
                Vector2.MoveTowards(transform.position, Player.Instance.axeSprite.transform.position, speed * Time.deltaTime);
            yield return null;
        }

        Player.Instance.EnableAxeSprite(true);

        Destroy(gameObject);
    }
}
