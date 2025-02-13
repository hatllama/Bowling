using UnityEngine;
 using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] pins;
    private void Start()
    {
    //We find all objects of type FallTrigger
    pins = Resources.FindObjectsOfTypeAll<FallTrigger>();

    foreach (FallTrigger pin in pins)
    {
        pin.OnPinFall.AddListener(IncrementScore);
    }

    void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
 }
}
