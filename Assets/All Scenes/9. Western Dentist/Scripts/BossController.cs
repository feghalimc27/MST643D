using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject instantiatorsGroup1;
    public GameObject instantiator1;
    public GameObject instantiator2;
    public GameObject instantiator3;
    public GameObject instantiator4;
    public GameObject instantiator5;
    public GameObject instantiator6;
    public GameObject instantiator7;
    public GameObject instantiator8;

    public GameObject instantiatorsGroup2;
    public GameObject instantiator9;
    public GameObject instantiator10;
    public GameObject instantiator11;
    public GameObject instantiator12;
    public GameObject instantiator13;
    public GameObject instantiator14;
    public GameObject instantiator15;
    public GameObject instantiator16;

    Vector2 newPosition;
    float newSpeed;
    float newRotationSpeed1;
    float newRotationSpeed2;

    Coroutine movementCR;
    Coroutine instantiationCR;
    int choice;

    void Start()
    {
        movementCR = StartCoroutine(Movement());
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, newPosition, newSpeed * Time.deltaTime);
        instantiatorsGroup1.transform.Rotate(Vector3.forward * newRotationSpeed1 * Time.deltaTime);
        instantiatorsGroup2.transform.Rotate(Vector3.forward * newRotationSpeed2 * Time.deltaTime);
    }

    IEnumerator Movement()
    {
        newPosition = new Vector2(Random.Range(73f, 560f), Random.Range(372f, 627.7f));
        newSpeed = Random.Range(50f, 125f);
        if (instantiationCR != null)
        {
            StopCoroutine(instantiationCR);
        }
        yield return new WaitForSeconds(1);
        choice = Random.Range(0, 3);
        switch (choice)
        {
            case 0:
                newRotationSpeed1 = Random.Range(-50f, 50f);
                newRotationSpeed2 = Random.Range(-50f, 50f);
                instantiationCR = StartCoroutine(Instantiation());
                break;
            case 1:
                newRotationSpeed1 = Random.Range(0f, 50f);
                newRotationSpeed2 = -newRotationSpeed1;
                instantiationCR = StartCoroutine(Instantiation());
                break;
            case 2:
                newRotationSpeed1 = Random.Range(0f, 25f);
                newRotationSpeed2 = newRotationSpeed1;
                instantiationCR = StartCoroutine(Instantiation());
                break;
        }
        yield return new WaitForSeconds(Random.Range(5f, 15f));
        movementCR = StartCoroutine(Movement());
    }

    IEnumerator Instantiation()
    {
        Instantiator.selectedProjectile = "BallBlue";
        instantiator1.SetActive(true);
        instantiator2.SetActive(true);
        instantiator3.SetActive(true);
        instantiator4.SetActive(true);
        instantiator5.SetActive(true);
        instantiator6.SetActive(true);
        instantiator7.SetActive(true);
        instantiator8.SetActive(true);
        instantiator9.SetActive(true);
        instantiator10.SetActive(true);
        instantiator11.SetActive(true);
        instantiator12.SetActive(true);
        instantiator13.SetActive(true);
        instantiator14.SetActive(true);
        instantiator15.SetActive(true);
        instantiator16.SetActive(true);
        yield return new WaitForSeconds(Random.Range(0.05f, 0.2f));
        instantiationCR = StartCoroutine(Instantiation());
    }
}
