using TMPro;
using UnityEngine;

public class Pointcounterscript : MonoBehaviour
{
    public TextMeshProUGUI Counter;
    public string playerTag = "Player";
    public string finishTag = "Finish";

    private int points;

    private void Start()
    {
        UpdatePointsText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;

        if ((CompareTag(finishTag) && other.CompareTag(playerTag)) ||
            (CompareTag(playerTag) && other.CompareTag(finishTag)))
        {
            Increment();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == null) return;

        if ((CompareTag(finishTag) && other.CompareTag(playerTag)) ||
            (CompareTag(playerTag) && other.CompareTag(finishTag)))
        {
            Increment();
        }
    }

    private void Increment()
    {
        points++;
        UpdatePointsText();
    }

    private void UpdatePointsText()
    {
        if (Counter != null)
            Counter.text = "Marbles Finished: " + points;
    }
}
