using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ShareApp : MonoBehaviour
{

    string url = "https://play.google.com/store/apps/details?id=com.TicTac.TicTacToe";
    NativeShare share;
    
    StringBuilder sb;
    [SerializeField] Button shareButton;
    void Start()
    {
        Initialize();
        shareButton.onClick.AddListener(() => { share.Share(); });
    }
    public void Initialize()
    {
        share = new NativeShare();
        sb = new StringBuilder();
        sb.Append("Hey param mitter let's play your favourite game The Tic - Tac - Toe");
        share.SetSubject("Tic - Tac - Toe");
        share.SetText(sb.ToString());
        share.SetUrl(url);
    }
}
