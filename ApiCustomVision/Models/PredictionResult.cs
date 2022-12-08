namespace ApiCustomVision.Models
{
    public class PredictionResult
    {
        /// <summary>
        /// Array Index
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// X axis position within the image
        /// </summary>
        public double PositionX { get; set; }
        /// <summary>
        /// X axis position within the image
        /// </summary>
        public double PositionY { get; set; }
        /// <summary>
        /// Prediction probability percentage
        /// </summary>
        public double Probability { get; set; }
    }
}
