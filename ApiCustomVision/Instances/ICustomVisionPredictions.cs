using ApiCustomVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;

namespace ApiCustomVision.Instances
{
    public interface ICustomVisionPredictions
    {
        Task<ImagePrediction> TestImageUrl(TestImage testImage);
    }
}
