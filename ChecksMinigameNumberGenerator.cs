using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChecksMinigameNumberGenerator : MonoBehaviour
{
    public GameObject originalText, originalButton;
    [SerializeField] int numberOfNumbers;
    [SerializeField] float minXCoordinate, maxXCoordinate, minYCoordinate, maxYCoordinate, minSize, maxSize;
    [SerializeField] Vector4[] allowedColours;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Number = Instantiate(originalText, gameObject.transform);
        float rotation = Random.Range(0, 360);
        float XPosition = Random.Range(minXCoordinate, maxXCoordinate);
        float YPosition = Random.Range(minYCoordinate, maxYCoordinate);
        float fontSize = Random.Range(minSize, maxSize);
        float content = Random.Range(0, 100);
        TextMeshProUGUI NumberTMP = Number.GetComponent<TextMeshProUGUI>();
        Number.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
        Number.transform.localPosition = new Vector3(XPosition, YPosition, 0);
        NumberTMP.fontSize = fontSize;
        NumberTMP.text = content.ToString();
        for (int i = 0; i < numberOfNumbers - 1; i++)
        {
            Number = Instantiate(originalText, gameObject.transform);
            rotation = Random.Range(0, 360);
            XPosition = Random.Range(minXCoordinate, maxXCoordinate);
            YPosition = Random.Range(minYCoordinate, maxYCoordinate);
            fontSize = Random.Range(minSize, maxSize);
            content = Random.Range(0, 100);
            NumberTMP = Number.GetComponent<TextMeshProUGUI>();
            Number.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
            Number.transform.localPosition = new Vector3(XPosition, YPosition, 0);
            NumberTMP.fontSize = fontSize;
            NumberTMP.text = content.ToString();
        }
        Number = Instantiate(originalButton, gameObject.transform);
        rotation = Random.Range(0, 360);
        XPosition = Random.Range(minXCoordinate, maxXCoordinate);
        YPosition = Random.Range(minYCoordinate, maxYCoordinate);
        Number.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
        Number.transform.localPosition = new Vector3(XPosition, YPosition, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
