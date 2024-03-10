using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class cuenta_atras : MonoBehaviour
{
    public GameObject uno;
    public GameObject dos;
    public GameObject tres;
    public GameObject start;

    void Start()
    {
        uno.SetActive(false);
        dos.SetActive(false);
        tres.SetActive(false);
        start.SetActive(false);

        StartCoroutine(StartCountdown());
    }

    public IEnumerator StartCountdown()
    {
        yield return new WaitForSecondsRealtime(1f);
        tres.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        tres.SetActive(false);

        dos.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        dos.SetActive(false);

        uno.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        uno.SetActive(false);

        start.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        start.SetActive(false);
        Time.timeScale = 1f;

    }
}
