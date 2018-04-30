using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicController : MonoBehaviour
{
    public AudioSource audioSource;
    public static GameObject merryObject;
    public static Sprite pointBallSprite;
    public static int playerScore;
    public GameObject mainCamera;
    public GameObject bossObject;
    public RawImage bossMarker;
    public RawImage backgroundScroll;
    public Text hiScoreText;
    public Text scoreText;
    public Image phase1HealthBar;
    public Image phase2HealthBar;
    public Image phase3HealthBar;
    public Image phase4HealthBar;
    public RawImage lifeStatus;
    public RawImage spellStatus;
    public Texture life1;
    public Texture life2;
    public Texture life3;
    public Texture life4;
    public Texture life5;
    public Texture spell0;
    public Texture spell1;
    public Texture spell2;
    public Texture spell3;
    public Texture spell4;
    public Texture spell5;

    Texture []lifeStars;
    Texture []spellStars;

    Coroutine cameraShakeCR;

    GameObject codecScreen;
    GameObject pauseMenu;

    void Start ()
    {
        merryObject = GameObject.Find("Merry").gameObject;
        pointBallSprite = Resources.Load<Sprite>("WesternDentist_PointBall");
        playerScore = 0;
        lifeStars = new Texture[] { life1, life2, life3, life4, life5 };
        spellStars = new Texture[] { spell0, spell1, spell2, spell3, spell4, spell5 };
        StartCoroutine(BackgroundScroll());
    }

    void Update()
    {
        try
        {
            codecScreen = GameObject.Find("Codec").gameObject;
            pauseMenu = GameObject.Find("Global Menu").gameObject;
            if (codecScreen != null || pauseMenu != null)
            {
                audioSource.Pause();
            }
            else if (audioSource.isPlaying == false)
            {
                audioSource.UnPause();
            }
        }
        catch (NullReferenceException e) { }

        if (bossObject != null)
        {
            bossMarker.rectTransform.localPosition = new Vector3(((bossObject.transform.position.x / 900f) * 800f) - 400f, 0, 0);
        }
        else
        {
            bossMarker.gameObject.SetActive(false);
        }
        phase1HealthBar.fillAmount = (float)BossController.phase1Health / 500;
        phase2HealthBar.fillAmount = (float)BossController.phase2Health / 1000;
        phase3HealthBar.fillAmount = (float)BossController.phase3Health / 1500;
        phase4HealthBar.fillAmount = (float)BossController.phase4Health / 2000;
        scoreText.text = "" + playerScore.ToString("0000000000");
        hiScoreText.text = "" + playerScore.ToString("0000000000");
        if (MerryController.merryHealth != 0)
        {
            lifeStatus.texture = lifeStars[MerryController.merryHealth - 1];
        }
        if (MerryController.merrySpell != -1)
        {
            spellStatus.texture = spellStars[MerryController.merrySpell];
        }
        if (Time.timeScale == 1 && bossObject != null)
        {
            if (BossController.phase1Health > 0)
            {
                playerScore += (int)Time.timeSinceLevelLoad;
            }
            else if (BossController.phase2Health > 0)
            {
                playerScore += (int)Time.timeSinceLevelLoad * 2;
            }
            else if (BossController.phase3Health > 0)
            {
                playerScore += (int)Time.timeSinceLevelLoad * 4;
            }
            else if (BossController.phase4Health > 0)
            {
                playerScore += (int)Time.timeSinceLevelLoad * 8;
            }

            if (BossController.phase1Health == 0)
            {
                StartCoroutine(PointBurst1Mil());
            }
            else if (BossController.phase2Health == 0)
            {
                StartCoroutine(PointBurst10Mil());
            }
            else if (BossController.phase3Health == 0)
            {
                StartCoroutine(PointBurst100Mil());
            }
            else if (BossController.phase4Health == 0)
            {
                StartCoroutine(PointBurst1000Mil());
            }
        }
    }

    IEnumerator BackgroundScroll()
    {
        for (float t = 2486; t >= -2486; t -= Time.deltaTime * 60)
        {
            backgroundScroll.rectTransform.localPosition = new Vector3(0, t, 0);
            yield return null;
        }
    }

    IEnumerator CameraShake()
    {
        float randomShakeX = UnityEngine.Random.Range(-10, 10);
        float randomShakeY = UnityEngine.Random.Range(-10, 10);
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + randomShakeX, mainCamera.transform.position.y + randomShakeY, -10);
        yield return null;
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x - randomShakeX, mainCamera.transform.position.y - randomShakeY, -10);
        yield return null;
        cameraShakeCR = StartCoroutine(CameraShake());
    }

    public void startCameraShake()
    {
        cameraShakeCR = StartCoroutine(CameraShake());
    }

    public void stopCameraShake()
    {
        if (cameraShakeCR != null)
        {
            mainCamera.transform.position = new Vector3(452, 339, -10);
            StopCoroutine(cameraShakeCR);
        }
    }

    IEnumerator PointBurst1Mil()
    {
        for (int i = 0; i < 120; i++)
        {
            playerScore += 8334 * UnityEngine.Random.Range(1, 10);
            yield return null;
        }
    }
    IEnumerator PointBurst10Mil()
    {
        for (int i = 0; i < 180; i++)
        {
            playerScore += 55556 * UnityEngine.Random.Range(1, 10);
            yield return null;
        }
    }

    IEnumerator PointBurst100Mil()
    {
        for (int i = 0; i < 240; i++)
        {
            playerScore += 416667 * UnityEngine.Random.Range(1, 10);
            yield return null;
        }
    }

    IEnumerator PointBurst1000Mil()
    {
        for (int i = 0; i < 300; i++)
        {
            playerScore += 3333334 * UnityEngine.Random.Range(1, 8);
            yield return null;
        }
    }
}
