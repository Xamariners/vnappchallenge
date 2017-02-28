using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Emotion;

namespace EmotionClient
{
    public class Core
    {
        private static async Task<Emotion[]> GetHappiness(Stream stream)
        {
            string emotionKey = "80c8d276497e461fa8272f52593f4a0b";
            EmotionServiceClient emotionClient = new EmotionServiceClient(emotionKey);
            var emotionResults = await emotionClient.RecognizeAsync(stream);
            if (emotionResults == null || emotionResults.Count() == 0)
            {
                throw new Exception("Can't detect face");
            }
            return emotionResults;
        }
        public static async Task<float> GetAverageHappinessScore(Stream stream)
        {
            Emotion[] emotionResults = await GetHappiness(stream);
            float score = 0;
            foreach (var emotionResult in emotionResults)
            {
                score = score + emotionResult.Scores.Happiness;
            }
            return score / emotionResults.Count();
        }
        public static string GetHappinessMessage(float score)
        {
            score = score * 100;
            double result = Math.Round(score, 2);
            if (score >= 50)
                return result + " % :-)";
            else
                return result + "% :-(";
        }
    }
}
