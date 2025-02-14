using UnityEngine;
 using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private BallController ball;
    [SerializeField] private GameObject pinCollection;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;

    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] fallTriggers;
    private GameObject pinObjects;

    private void Start()
    {
        //We find all objects of type FallTrigger
        fallTriggers = Resources.FindObjectsOfTypeAll<FallTrigger>();

        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }

        inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();
    }

    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }

    private void SetPins()
    {
        if(pinObjects)
        {
            foreach (Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }
        }
        Destroy(pinObjects);

        pinObjects = Instantiate(pinCollection,
        pinAnchor.transform.position,
        Quaternion.identity, transform);

        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include,
        FindObjectsSortMode.None);

        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}
