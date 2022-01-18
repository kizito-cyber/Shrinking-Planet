using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;

public class LeaderBoardController : MonoBehaviour
{
    public InputField MemberID, PlayerScore;
    public int ID;
    int MaxScores = 7;
    public Text[] Entries;
    // Start is called before the first frame update
    void Start()
    {
        LootLockerSDKManager.StartSession("Player", (response) =>
         {
             if(response.success)
             {
                 Debug.Log("Suceess");
             }
             else
             {
                 Debug.Log("Failed");
             }
         });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
          {
              if (response.success)
              {

                  LootLockerLeaderboardMember[] scores = response.items;
                  for(int i = 0; i < scores.Length; i++)
                  {
                      Entries[i].text = (scores[i].rank + ".   " + scores[i].score);
                  }
                  if(scores.Length < MaxScores)
                  {
                      for(int i = scores.Length; i < MaxScores; i++)
                      {
                          Entries[i].text = (i + 1).ToString() + ".   none";
                      }
                  }

              }
              else
              {
                  Debug.Log("Failed");
              }

          });
    }
    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(MemberID.text, int.Parse(PlayerScore.text), ID, (response) =>
           {
               if (response.success)
               {
                   Debug.Log("Suceess");
               }
               else
               {
                   Debug.Log("Failed");
               }
           });
    }
}
