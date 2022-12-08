using ApiCustomVision.Instances;
using ApiCustomVision.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCustomVision.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionController : ControllerBase
    {
        private readonly ILogger<PredictionController> _logger;
        private readonly ICustomVisionPredictions _customVision;

        public PredictionController(ILogger<PredictionController> logger, ICustomVisionPredictions customVision)
        {
            _logger= logger;
            _customVision= customVision;
        }

        /// <summary>
        /// Prediction with Image URL
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        [HttpPost(Name = "url")]
        public async Task<IActionResult> TestPredictionUrl([FromBody] TestImage Url) 
        {
            List<PredictionResult> predictionResults = new List<PredictionResult>();

            var results = await _customVision.TestImageUrl(Url);


            foreach (var result in results.Predictions)
            {
                if (result.Probability >= 0.8) 
                {
                    predictionResults.Add(new PredictionResult
                    {
                        Index = predictionResults.Count,
                        PositionX = result.BoundingBox.Left,
                        PositionY = result.BoundingBox.Top,
                        Probability = result.Probability
                    });            
                }
            }

            return Ok(predictionResults);
        }

    }
}
