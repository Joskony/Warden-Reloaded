using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class TelemetryA : MonoBehaviour
{
    [SerializeField] private DataTracker m_dataTracker;
    
    private const string GoogleFormBaseUrl = "https://docs.google.com/forms/d/e/1FAIpQLSfBdE2Rw38W9QQkCjZqmKqKSfLlMU-YMM9nPYCd_9uIwMlA8Q/";

    private const string GformUserId = "entry.1211971394";
    private const string GformAttemptDuration = "entry.282272031";
    private const string GformMovementLeftPressed = "entry.139165087";
    private const string GformMovementRightPressed = "entry.1207909734";
    private const string GformBombButtonsPressed = "entry.726387168";
    private const string GformRetractedPressed = "entry.1510851726";
    private const string GformExtendedPressed = "entry.37717233";

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
