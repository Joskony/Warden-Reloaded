using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Telemetry : MonoBehaviour
{
    private const string GoogleFormBaseUrl = "https://docs.google.com/forms/d/e/1FAIpQLSfiq9MhRmGel9PFQHqydUu4egND-l2lvqBjIvnQJtZUzTR0UQ/";

    private const string GformCustomTimeStamp = "entry.1273675796";
    private const string GformUserId = "entry.47680143";
    private const string GformAttemptDuration = "entry.1439297271";
    private const string GformMovementLeftPressed = "entry.1049173437";
    private const string GformMovementRightPressed = "entry.1824591726";
    private const string GformBombButtonsPressed = "entry.2112181685";
    private const string GformRetractedPressed = "entry.532483446";
    private const string GformExtendedPressed = "entry.488609001";

    public void SendData()
    {
        StartCoroutine(SubmitGoogleForm());
    }

    private IEnumerator SubmitGoogleForm()
    {
        var form = new WWWForm();
        form.AddField(GformCustomTimeStamp, -1);
        form.AddField(GformUserId, - 2);
        form.AddField(GformAttemptDuration, -3);
        form.AddField(GformMovementLeftPressed, -4);
        form.AddField(GformMovementRightPressed, -5);
        form.AddField(GformBombButtonsPressed, -6);
        form.AddField(GformRetractedPressed, -7);
        form.AddField(GformExtendedPressed, -8);

        const string urlGoogleFormResponse = GoogleFormBaseUrl + "formResponse";
        using (var www = UnityWebRequest.Post(urlGoogleFormResponse, form))
        {
            yield return www.SendWebRequest();
        }
    }
}
