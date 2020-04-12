using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class TelemetryB : MonoBehaviour
{
    [SerializeField] private DataTracker m_dataTracker;
    
    private const string GoogleFormBaseUrl = "https://docs.google.com/forms/d/e/1FAIpQLSeBA3qh2Tkv_J4EpD_VC8GUVoerwjfL0UH7akTW05w2eLQD_Q/";

    private const string GformUserId = "entry.163445355";
    private const string GformAttemptDuration = "entry.321057223";
    private const string GformMovementLeftPressed = "entry.914844437";
    private const string GformMovementRightPressed = "entry.464725180";
    private const string GformBombButtonsPressed = "entry.1278176303";
    private const string GformRetractedPressed = "entry.1003309508";
    private const string GformExtendedPressed = "entry.183858019";

    public void SendData()
    {
        StartCoroutine(SubmitGoogleForm());
    }

    private IEnumerator SubmitGoogleForm()
    {
        var form = new WWWForm();
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
