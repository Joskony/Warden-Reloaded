using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Telemetry : MonoBehaviour
{
    [SerializeField] private DataTracker m_dataTracker;
    
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
        form.AddField(GformCustomTimeStamp, System.DateTime.Now.ToString()); // Exact format needs to be decided
        form.AddField(GformUserId, SystemInfo.deviceUniqueIdentifier); // Is already a string
        form.AddField(GformAttemptDuration, m_dataTracker.GetAttemptDuration().ToString()); // Needs to be a string, since float can't be send through www requests
        form.AddField(GformMovementLeftPressed, m_dataTracker.GetMovementLeftPressed()); // Can be send as an int
        form.AddField(GformMovementRightPressed, m_dataTracker.GetMovementRightPressed()); // Can be send as an int
        form.AddField(GformBombButtonsPressed, m_dataTracker.GetBombButtonsPressed()); // Can be send as an int
        form.AddField(GformRetractedPressed, m_dataTracker.GetRetractedPressed()); // Can be send as an int
        form.AddField(GformExtendedPressed, m_dataTracker.GetExtendedPressed()); // Can be send as an int

        const string urlGoogleFormResponse = GoogleFormBaseUrl + "formResponse";
        using (var www = UnityWebRequest.Post(urlGoogleFormResponse, form))
        {
            yield return www.SendWebRequest();
        }
    }
}
