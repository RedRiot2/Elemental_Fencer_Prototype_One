using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private GameObject resultsPanel;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private GameObject target2;

    [SerializeField]
    private GameObject target3;

    [SerializeField]
    private TextMeshProUGUI targetsHitText;

    [SerializeField]
    private TextMeshProUGUI titleText;

    [SerializeField]
    private Vector2 mousePos;

    [SerializeField]
    private TextMeshProUGUI getReadyText;

    public static int targetsHit;

    [SerializeField]
    private int targetsAmount;

    private Vector2 targetRandomPosition;

    private Vector2 target2RandomPosition;
    private Vector2 target2Velocity;

    private Vector2 target3RandomPosition;

    [SerializeField]
    private GameObject playerObject;

    public float spawn_circle_radius = 80f;
    public float death_circle_radius = 90f;
    public GameObject game_area;

    public Transform game_area_test;
    void Start()
    {
        getReadyText.gameObject.SetActive(false);

        targetsAmount = 20;
    }

    void Update()
    {
       

    }

    public void StartGedReadyCoroutine()
    {
        resultsPanel.SetActive(false);
        getReadyText.gameObject.SetActive(true);
        StartCoroutine("GetReady");

    }
    private IEnumerator GetReady()
    {

        for (int i = 3; i >= 1; i--)
        {

            getReadyText.text = "Get Ready!\n" + i.ToString();

            yield return new WaitForSeconds(1f);

        }

        getReadyText.text = "Go!";
        yield return new WaitForSeconds(1f);

        StartCoroutine("SpawnTargets");
        StartCoroutine("SpawnTargets2");
        StartCoroutine("SpawnTargets3");
    }

    private IEnumerator SpawnTargets()
    {
        getReadyText.gameObject.SetActive(false);
        Instantiate(playerObject);
        targetsHit = 0;

        for (int i = targetsAmount; i * 2 >= 0; i--)
        {
            targetRandomPosition = new Vector2(Random.Range(-9f, 9f), Random.Range(-5f, 5f));
            Instantiate(target, targetRandomPosition, Quaternion.identity);
            yield return new WaitForSeconds(1.2f);
        }

        resultsPanel.SetActive(true);
        targetsHitText.text = "Targets hit: " + targetsHit;
        titleText.text = "Play again?";
    }

    private IEnumerator SpawnTargets2()
    {
        for (int i = targetsAmount * 3; i >= 0; i--)
        {

            Vector3 position = GetRandomPosition(false);
            transform.rotation = new Quaternion(Random.Range(1f,6f),Random.Range(1f,6f),0,0);
            target2RandomPosition = new Vector2(Random.Range(-7f, 7f), Random.Range(-4f, 4f));
            GameObject newTarget2 = Instantiate(target2, position, transform.rotation);
            target2Velocity = new Vector2(Random.Range(-7f, 7f), Random.Range(-7f,7f));
            newTarget2.GetComponent<Rigidbody2D>().velocity = target2Velocity;
            yield return new WaitForSeconds(0.6f);
        }

    }

    Vector3 GetRandomPosition(bool within_camera)
    {

        Vector3 position = Random.insideUnitCircle;

        if(within_camera == false)
        {

            position = position.normalized;

        }

        position *= spawn_circle_radius;
        position += game_area.transform.position;

        return position;

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(game_area_test.position, spawn_circle_radius);
    }
    private IEnumerator SpawnTargets3()
    {
        for (int i = targetsAmount; i / 3 >= 0; i--)
        {

            target3RandomPosition = new Vector2(Random.Range(-7f, 7f), Random.Range(-4f, 4f));
            Instantiate(target3, target3RandomPosition, Quaternion.identity);
            yield return new WaitForSeconds(5.4f);

        }

    }

    public void GameEnd()
    {

        resultsPanel.SetActive(true);
        targetsHitText.text = "Targets hit: " + targetsHit;
        titleText.text = "Play again?";

    }
}
