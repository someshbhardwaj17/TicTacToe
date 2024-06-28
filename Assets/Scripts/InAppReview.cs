using Google.Play.Review;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAppReview : MonoBehaviour
{
    private ReviewManager _reviewManager;
    private PlayReviewInfo _playReviewInfo;
    private int count;
    void Start()
    {
        if (PlayerPrefs.HasKey("openCount"))
        {
            count = PlayerPrefs.GetInt("openCount");
            count++;

            if (count > 5)
                StartCoroutine(RequestForReview());
            else
                PlayerPrefs.SetInt("openCount", count);

            return;
        }
        PlayerPrefs.SetInt("openCount", count);

    }

    private IEnumerator RequestForReview()
    {
        _reviewManager = new ReviewManager();
        var requestFlowOperation = _reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
        if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        {
            yield break;
        }
        _playReviewInfo = requestFlowOperation.GetResult();

        var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
        yield return launchFlowOperation;
        _playReviewInfo = null; // Reset the object
        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            yield break;
        }

    }
}
