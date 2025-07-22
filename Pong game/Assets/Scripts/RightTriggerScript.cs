using TMPro;
using UnityEngine;

public class RightTriggerScript : MonoBehaviour
{
    public int leftScore;
    public TextMeshProUGUI leftScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        leftScoreText.text = leftScore.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        leftScore++;
        collision.gameObject.transform.position = Vector3.zero;

    }
}
