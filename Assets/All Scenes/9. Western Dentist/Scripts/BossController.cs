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
    Coroutine instantiation1CR;
    Coroutine instantiation2CR;
    int choice;

    string[] projectileTypes;

    public static bool phaseOver;

    float fireRate1;
    float fireRate2;

    void Start()
    {
        projectileTypes = new string[] { "BallRed", "BallBlue", "BallGreen", "OvalYellow", "CardPink" };
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
        if (instantiation1CR != null)
        {
            StopCoroutine(instantiation1CR);
        }
        if (instantiation2CR != null)
        {
            StopCoroutine(instantiation2CR);
        }
        phaseOver = true;
        yield return new WaitForSeconds(3);
        phaseOver = false;
        Instantiator1.selectedProjectile = projectileTypes[Random.Range(0, 5)];
        Instantiator2.selectedProjectile = projectileTypes[Random.Range(0, 5)];
        if (Instantiator1.selectedProjectile == "BallBlue")
        {
            fireRate1 = Random.Range(0.25f, 0.3f);
        }
        else if (Instantiator1.selectedProjectile == "BallRed")
        {
            fireRate1 = Random.Range(0.5f, 0.75f);
        }
        else if (Instantiator1.selectedProjectile == "BallGreen")
        {
            fireRate1 = Random.Range(1f, 1.25f);
        }
        else if (Instantiator1.selectedProjectile == "OvalYellow")
        {
            fireRate1 = Random.Range(0.25f, 0.5f);
        }
        else if (Instantiator1.selectedProjectile == "CardPink")
        {
            fireRate1 = 1.5f;
        }

        if (Instantiator2.selectedProjectile == "BallBlue")
        {
            fireRate2 = Random.Range(0.25f, 0.3f);
        }
        else if (Instantiator2.selectedProjectile == "BallRed")
        {
            fireRate2 = Random.Range(0.5f, 0.75f);
        }
        else if (Instantiator2.selectedProjectile == "BallGreen")
        {
            fireRate2 = Random.Range(1f, 1.25f);
        }
        else if (Instantiator2.selectedProjectile == "OvalYellow")
        {
            fireRate2 = Random.Range(0.25f, 0.5f);
        }
        else if (Instantiator2.selectedProjectile == "CardPink")
        {
            fireRate2 = 1.5f;
        }

        choice = Random.Range(0, 3);
        switch (choice)
        {
            case 0:
                newRotationSpeed1 = Random.Range(-50f, 50f);
                newRotationSpeed2 = Random.Range(-50f, 50f);
                instantiation1CR = StartCoroutine(Instantiation1());
                instantiation2CR = StartCoroutine(Instantiation2());
                break;
            case 1:
                newRotationSpeed1 = Random.Range(0f, 50f);
                newRotationSpeed2 = -newRotationSpeed1;
                instantiation1CR = StartCoroutine(Instantiation1());
                instantiation2CR = StartCoroutine(Instantiation2());
                break;
            case 2:
                newRotationSpeed1 = Random.Range(0f, 25f);
                newRotationSpeed2 = newRotationSpeed1;
                instantiation1CR = StartCoroutine(Instantiation1());
                instantiation2CR = StartCoroutine(Instantiation2());
                break;
        }
        yield return new WaitForSeconds(Random.Range(10f, 15f));
        movementCR = StartCoroutine(Movement());
    }

    IEnumerator Instantiation1()
    {
        instantiator1.SetActive(true);
        instantiator2.SetActive(true);
        instantiator3.SetActive(true);
        instantiator4.SetActive(true);
        instantiator5.SetActive(true);
        instantiator6.SetActive(true);
        instantiator7.SetActive(true);
        instantiator8.SetActive(true);
        yield return new WaitForSeconds(fireRate1);
       instantiation1CR = StartCoroutine(Instantiation1());
    }

    IEnumerator Instantiation2()
    {
        instantiator9.SetActive(true);
        instantiator10.SetActive(true);
        instantiator11.SetActive(true);
        instantiator12.SetActive(true);
        instantiator13.SetActive(true);
        instantiator14.SetActive(true);
        instantiator15.SetActive(true);
        instantiator16.SetActive(true);
        yield return new WaitForSeconds(fireRate2);
        instantiation2CR = StartCoroutine(Instantiation2());
    }
}
