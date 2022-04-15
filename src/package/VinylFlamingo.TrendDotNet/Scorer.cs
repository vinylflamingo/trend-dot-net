using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VinylFlamingo.TrendDotNet
{
    public class Scorer
    {
        public List<Factor> Factors = new List<Factor>();
        public double Gravity = 0.2;

        /// <summary>
        /// Calculate a score using the added Factors, and the time in days since the content was published.
        /// </summary>
        /// <param name="daysSincePost">Days since the content has been published.</param>
        /// <returns>A new score of type double</returns>
        /// <exception cref="Exception">No factors found.</exception>
        public double Calculate(double daysSincePost)
        {
            if (Factors != null )
            {
                double aggregatedWeightedHits = 0;
                foreach (Factor factor in Factors)
                {
                    double weightedHit = factor.Hits * factor.Weight;
                    aggregatedWeightedHits = aggregatedWeightedHits + weightedHit;
                }

                double timeValue = daysSincePost * Gravity;

                double score = aggregatedWeightedHits / timeValue;
                return score;
            }
            else
            {
                throw new Exception("No Factors were found to consider in scoring. Please add factors using Scorer.AddFactor(name, hits, weight)");
            }

        }
        
        /// <summary>
        /// Calculate a score using the added Factors, and the time in days since the content was published.
        /// </summary>
        /// <param name="daysSincePost">Days since the content has been published.</param>
        /// <returns>A new score of type int</returns>
        /// <exception cref="Exception">No factors found.</exception>
        public int Calculate(int daysSincePost)
        {
            var _daysSincePost = Convert.ToDouble(daysSincePost);
            var score = Calculate(_daysSincePost);
            var convertedScore = Convert.ToInt32(score);
            return convertedScore;
        }

        /// <summary>
        /// Add a new factor to be considered in scoring. 
        /// </summary>
        /// <param name="name">The name of the factor ex: "page views"</param>
        /// <param name="hits">The quantity this factor has</param>
        /// <param name="weight">How strongly should the scorer consider this factor.</param>
        public void AddFactor([Optional]string name, [Optional] double? hits, [Optional]double? weight)
        {
            Factor factor = new Factor()
            {
                Name = name ?? "generic",
                Hits = hits ?? 0,
                Weight = weight ?? 1
            };

            Factors.Add(factor);
        }






    }
    public class Factor
    {
        public string Name { get; set; }
        public double Hits { get; set; }
        public double Weight { get; set; }


    }
}
