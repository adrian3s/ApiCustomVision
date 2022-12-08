using ApiCustomVision.Instances;
using ApiCustomVision.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;

namespace ApiCustomVision.Predictions
{
    public class CustomVisionPredictions: ICustomVisionPredictions
    {
        private readonly string _predictionEndpoint;
        private readonly string _predictionKey;
        private readonly string _projectId;
        private readonly string _publicationName;

        public CustomVisionPredictions(IConfiguration configuration)
        {
            ///Prediction
            _predictionEndpoint = configuration.GetSection("AzureCustomVisionPrediction").GetValue<string>("EndPoint");
            _projectId = configuration.GetSection("AzureCustomVisionPrediction").GetValue<string>("ProjectId");
            _predictionKey = configuration.GetSection("AzureCustomVisionPrediction").GetValue<string>("PredictionKey");
            _publicationName = configuration.GetSection("AzureCustomVisionPrediction").GetValue<string>("PublicationName");
        }

        public async Task<ImagePrediction> TestImageUrl(TestImage testImage) 
        {
            ImagePrediction imagePrediction = new ImagePrediction();

            try
            {
                CustomVisionPredictionClient predictionClient = new CustomVisionPredictionClient(new ApiKeyServiceClientCredentials(_predictionKey));

                predictionClient.Endpoint = _predictionEndpoint;

                ImageUrl imageUrl = new ImageUrl(testImage.Url);

                imagePrediction = await predictionClient.DetectImageUrlAsync(new Guid(_projectId), _publicationName, imageUrl);
            }
            catch (Exception) { }
            
            return imagePrediction;
            
        }
    }
}
