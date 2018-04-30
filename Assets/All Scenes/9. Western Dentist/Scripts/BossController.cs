using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public static int phase1Health;
    public static int phase2Health;
    public static int phase3Health;
    public static int phase4Health;

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

    public GameObject instantiatorsGroup3;
    public GameObject instantiator17;
    public GameObject instantiator18;
    public GameObject instantiator19;
    public GameObject instantiator20;
    public GameObject instantiator21;
    public GameObject instantiator22;
    public GameObject instantiator23;
    public GameObject instantiator24;

    public GameObject instantiatorsGroup4;
    public GameObject instantiator25;
    public GameObject instantiator26;
    public GameObject instantiator27;
    public GameObject instantiator28;
    public GameObject instantiator29;
    public GameObject instantiator30;
    public GameObject instantiator31;
    public GameObject instantiator32;

    Vector2 newPosition;
    float newSpeed;

    float newRotationSpeed1;
    float newRotationSpeed2;
    float newRotationSpeed3;
    float newRotationSpeed4;

    Coroutine movementCR;
    Coroutine phaseCR;

    Coroutine instantiation1CR;
    Coroutine instantiation2CR;
    Coroutine instantiation3CR;
    Coroutine instantiation4CR;

    int choice;

    public static bool phaseOver;

    float fireRate1;
    float fireRate2;
    float fireRate3;
    float fireRate4;

    void Start()
    {
        phase1Health = 500;
        phase2Health = 1000;
        phase3Health = 1500;
        phase4Health = 2000;
        movementCR = StartCoroutine(Movement());
        phaseCR = StartCoroutine(StartPhase());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            Destroy(collision.gameObject);
            LogicController.playerScore += 100;
            if (phase1Health > 0)
            {
                phase1Health -= 1;
            }
            else if (phase2Health > 0)
            {
                phase2Health -= 1;
            }
            else if (phase3Health > 0)
            {
                phase3Health -= 1;
            }
            else if (phase4Health > 0)
            {
                phase4Health -= 1;
            }
        }
        if (collision.gameObject.tag == "SpecialAttack")
        {
            LogicController.playerScore += 1000;
            if (phase1Health > 0)
            {
                phase1Health -= 1;
            }
            else if (phase2Health > 0)
            {
                phase2Health -= 1;
            }
            else if (phase3Health > 0)
            {
                phase3Health -= 1;
            }
            else if (phase4Health > 0)
            {
                phase4Health -= 1;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpecialAttack")
        {
            LogicController.playerScore += 1000;
            if (phase1Health > 0)
            {
                phase1Health -= 1;
            }
            else if (phase2Health > 0)
            {
                phase2Health -= 1;
            }
            else if (phase3Health > 0)
            {
                phase3Health -= 1;
            }
            else if (phase4Health > 0)
            {
                phase4Health -= 1;
            }
        }
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, newPosition, newSpeed * Time.deltaTime);
        instantiatorsGroup1.transform.Rotate(Vector3.forward * newRotationSpeed1 * Time.deltaTime);
        instantiatorsGroup2.transform.Rotate(Vector3.forward * newRotationSpeed2 * Time.deltaTime);
        instantiatorsGroup3.transform.Rotate(Vector3.forward * newRotationSpeed3 * Time.deltaTime);
        instantiatorsGroup4.transform.Rotate(Vector3.forward * newRotationSpeed4 * Time.deltaTime);

        if (phase1Health == 0)
        {
            phase1Health--;
            MerryController.merryHealth += 1;
            if (MerryController.merryHealth > 5)
            {
                MerryController.merryHealth = 5;
            }
            StopCoroutine(movementCR);
            movementCR = StartCoroutine(Movement());
            StopCoroutine(phaseCR);
            phaseCR = StartCoroutine(StartPhase());
        }
        else if (phase2Health == 0)
        {
            phase2Health--;
            MerryController.merryHealth += 2;
            if (MerryController.merryHealth > 5)
            {
                MerryController.merryHealth = 5;
            }
            StopCoroutine(movementCR);
            movementCR = StartCoroutine(Movement());
            StopCoroutine(phaseCR);
            phaseCR = StartCoroutine(StartPhase());
        }
        else if (phase3Health == 0)
        {
            phase3Health--;
            MerryController.merryHealth += 3;
            if (MerryController.merryHealth > 5)
            {
                MerryController.merryHealth = 5;
            }
            StopCoroutine(movementCR);
            movementCR = StartCoroutine(Movement());
            StopCoroutine(phaseCR);
            phaseCR = StartCoroutine(StartPhase());
        }
        else if (phase4Health == 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Movement()
    {
        newPosition = new Vector2(Random.Range(73f, 560f), Random.Range(372f, 627.7f));
        newSpeed = Random.Range(50f, 125f);
        yield return new WaitForSeconds(Random.Range(5f, 10f));
        movementCR = StartCoroutine(Movement());
    }

    IEnumerator StartPhase()
    {
        if (instantiation1CR != null)
        {
            StopCoroutine(instantiation1CR);
        }
        if (instantiation2CR != null)
        {
            StopCoroutine(instantiation2CR);
        }
        if (instantiation3CR != null)
        {
            StopCoroutine(instantiation3CR);
        }
        if (instantiation4CR != null)
        {
            StopCoroutine(instantiation4CR);
        }
        phaseOver = true;
        yield return new WaitForSeconds(3);
        phaseOver = false;
        if (phase1Health > 0)
        {
            Instantiator1.selectedProjectile = "BallBlue";
            Instantiator2.selectedProjectile = "BallRed";
            Instantiator3.selectedProjectile = "BallBlue";
            Instantiator4.selectedProjectile = "BallRed";
        }
        else if (phase2Health > 0)
        {
            Instantiator1.selectedProjectile = "BallBlue";
            Instantiator2.selectedProjectile = "BallRed";
            Instantiator3.selectedProjectile = "BallGreen";
            Instantiator4.selectedProjectile = "BallRed";
        }
        else if (phase3Health > 0)
        {
            Instantiator1.selectedProjectile = "BallBlue";
            Instantiator2.selectedProjectile = "BallRed";
            Instantiator3.selectedProjectile = "BallGreen";
            Instantiator4.selectedProjectile = "OvalYellow";
        }
        else if (phase4Health > 0)
        {
            Instantiator1.selectedProjectile = "BallRed";
            Instantiator2.selectedProjectile = "BallGreen";
            Instantiator3.selectedProjectile = "OvalYellow";
            Instantiator4.selectedProjectile = "CardPink";
        }

        if (Instantiator1.selectedProjectile == "BallBlue")
        {
            fireRate1 = Random.Range(0.25f, 0.3f);
        }
        else if (Instantiator1.selectedProjectile == "BallRed")
        {
            fireRate1 = Random.Range(0.5f, 0.75f);
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

        if (Instantiator3.selectedProjectile == "BallBlue")
        {
            fireRate3 = Random.Range(0.25f, 0.3f);
        }
        else if (Instantiator3.selectedProjectile == "BallRed")
        {
            fireRate3 = Random.Range(0.5f, 0.75f);
        }
        else if (Instantiator3.selectedProjectile == "BallGreen")
        {
            fireRate3 = Random.Range(1f, 1.25f);
        }
        else if (Instantiator3.selectedProjectile == "OvalYellow")
        {
            fireRate3 = Random.Range(0.25f, 0.5f);
        }

        if (Instantiator4.selectedProjectile == "BallBlue")
        {
            fireRate4 = Random.Range(0.25f, 0.3f);
        }
        else if (Instantiator4.selectedProjectile == "BallRed")
        {
            fireRate4 = Random.Range(0.5f, 0.75f);
        }
        else if (Instantiator4.selectedProjectile == "BallGreen")
        {
            fireRate4 = Random.Range(1f, 1.25f);
        }
        else if (Instantiator4.selectedProjectile == "OvalYellow")
        {
            fireRate4 = Random.Range(0.25f, 0.5f);
        }
        else if (Instantiator4.selectedProjectile == "CardPink")
        {
            fireRate4 = 3f;
        }

        choice = Random.Range(0, 3);
        switch (choice)
        {
            case 0:
                newRotationSpeed1 = Random.Range(-50f, 50f);
                newRotationSpeed2 = Random.Range(-50f, 50f);
                newRotationSpeed3 = Random.Range(-50f, 50f);
                newRotationSpeed4 = Random.Range(-50f, 50f);
                instantiation1CR = StartCoroutine(Instantiation1());
                instantiation2CR = StartCoroutine(Instantiation2());
                instantiation3CR = StartCoroutine(Instantiation3());
                instantiation4CR = StartCoroutine(Instantiation4());
                break;
            case 1:
                newRotationSpeed1 = Random.Range(0f, 50f);
                newRotationSpeed2 = -newRotationSpeed1;
                newRotationSpeed3 = newRotationSpeed1;
                newRotationSpeed4 = -newRotationSpeed1;
                instantiation1CR = StartCoroutine(Instantiation1());
                instantiation2CR = StartCoroutine(Instantiation2());
                instantiation3CR = StartCoroutine(Instantiation3());
                instantiation4CR = StartCoroutine(Instantiation4());
                break;
            case 2:
                newRotationSpeed1 = Random.Range(0f, 25f);
                newRotationSpeed2 = newRotationSpeed1;
                newRotationSpeed3 = newRotationSpeed1;
                newRotationSpeed4 = newRotationSpeed1;
                instantiation1CR = StartCoroutine(Instantiation1());
                instantiation2CR = StartCoroutine(Instantiation2());
                instantiation3CR = StartCoroutine(Instantiation3());
                instantiation4CR = StartCoroutine(Instantiation4());
                break;
        }
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

    IEnumerator Instantiation3()
    {
        instantiator17.SetActive(true);
        instantiator18.SetActive(true);
        instantiator19.SetActive(true);
        instantiator20.SetActive(true);
        instantiator21.SetActive(true);
        instantiator22.SetActive(true);
        instantiator23.SetActive(true);
        instantiator24.SetActive(true);
        yield return new WaitForSeconds(fireRate3);
        instantiation3CR = StartCoroutine(Instantiation3());
    }

    IEnumerator Instantiation4()
    {
        instantiator25.SetActive(true);
        instantiator26.SetActive(true);
        instantiator27.SetActive(true);
        instantiator28.SetActive(true);
        instantiator29.SetActive(true);
        instantiator30.SetActive(true);
        instantiator31.SetActive(true);
        instantiator32.SetActive(true);
        yield return new WaitForSeconds(fireRate4);
        instantiation4CR = StartCoroutine(Instantiation4());
    }

    public void restartPhase()
    {
        StopCoroutine(movementCR);
        movementCR = StartCoroutine(Movement());
        StopCoroutine(phaseCR);
        phaseCR = StartCoroutine(StartPhase());
    }
}
