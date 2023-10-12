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

    void Start()
    {
        getReadyText.gameObject.SetActive(false);

        targetsAmount = 20;
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {



        }

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
    }

    private IEnumerator SpawnTargets()
    {
        getReadyText.gameObject.SetActive(false);
        targetsHit = 0;

        for (int i = targetsAmount; i >= 0; i--)
        {
            targetRandomPosition = new Vector2(Random.Range(-7f, 7f), Random.Range(-4f, 4f));
            Instantiate(target, targetRandomPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.8f);
        }

        resultsPanel.SetActive(true);
        targetsHitText.text = "Targets hit: " + targetsHit + "/" + targetsAmount;
        titleText.text = "Play again?";
    }

    public void StartGedReadyCoroutine()
    {
        resultsPanel.SetActive(false);
        getReadyText.gameObject.SetActive(true);
        StartCoroutine("GetReady");

    }
}
