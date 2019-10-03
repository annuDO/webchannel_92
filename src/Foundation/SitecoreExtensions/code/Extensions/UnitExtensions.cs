using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLBi.Sitecore.Units;

namespace DLBi.Sitecore.Extensions
{
    public static class UnitExtensions
    {
        #region milimeters
        /// <summary>
        /// Convert a milimeter distance to MetricDistance (meters)
        /// </summary>
        /// <param name="that">Milimeters</param>
        /// <returns></returns>
        public static MetricDistance Milimeters(this Int32 that)
        {
            return new MetricDistance(MetricDistance.Milimeter.ToBaseunit * that);
        }

        /// <summary>
        /// Convert a milimeter distance to MetricDistance (meters)
        /// </summary>
        /// <param name="that">Milimeters</param>
        /// <returns></returns>
        public static MetricDistance Milimeters(this float that)
        {
            return new MetricDistance(MetricDistance.Milimeter.ToBaseunit * that);
        }

        /// <summary>
        /// Convert a milimeter distance to MetricDistance (meters)
        /// </summary>
        /// <param name="that">Milimeters</param>
        /// <returns></returns>
        public static MetricDistance Milimeters(this double that)
        {
            return new MetricDistance(MetricDistance.Milimeter.ToBaseunit * that);
        }
        #endregion
        #region centimeters
        /// <summary>
        /// Convert a centimeter measurement to MetricDistance (meters)
        /// </summary>
        /// <param name="that">Centimeters</param>
        /// <returns></returns>
        public static MetricDistance Centimeters(this int that)
        {
            return new MetricDistance(MetricDistance.Centimeter.ToBaseunit * that);
        }

        /// <summary>
        /// Convert a centimeter measurement to MetricDistance (meters)
        /// </summary>
        /// <param name="that">Centimeters</param>
        /// <returns></returns>
        public static MetricDistance Centimeters(this float that)
        {
            return new MetricDistance(MetricDistance.Centimeter.ToBaseunit * that);
        }
        /// <summary>
        /// Convert a centimeter measurement to MetricDistance (meters)
        /// </summary>
        /// <param name="that">Centimeters</param>
        /// <returns></returns>
        public static MetricDistance Centimeters(this double that)
        {
            return new MetricDistance(MetricDistance.Centimeter.ToBaseunit * that);
        }
        #endregion
        #region meters
        /// <summary>
        /// Convert a centimeter measurement to MetricDistance (meters)
        /// </summary>
        /// <param name="that">Centimeters</param>
        /// <returns></returns>
        public static MetricDistance Meters(this int that)
        {
            return new MetricDistance(MetricDistance.Meter.ToBaseunit * that);
        }

        /// <summary>
        /// Convert a centimeter measurement to MetricDistance (meters)
        /// </summary>
        /// <param name="that">Centimeters</param>
        /// <returns></returns>
        public static MetricDistance Meters(this float that)
        {
            return new MetricDistance(MetricDistance.Meter.ToBaseunit * that);
        }
        /// <summary>
        /// Convert a centimeter measurement to MetricDistance (meters)
        /// </summary>
        /// <param name="that">Centimeters</param>
        /// <returns></returns>
        public static MetricDistance Meters(this double that)
        {
            return new MetricDistance(MetricDistance.Meter.ToBaseunit * that);
        }
        #endregion
        #region inches
        /// <summary>
        /// Convert a Inch measurement to ImperialDistance (meters)
        /// </summary>
        /// <param name="that">Inchs</param>
        /// <returns></returns>
        public static MetricDistance Inches(this int that) 
        {
            return new ImperialDistance(ImperialDistance.Inch.ToBaseunit * that).ToMetricDistance();
        }

        /// <summary>
        /// Convert a Inch measurement to UbDistance (meters)
        /// </summary>
        /// <param name="that">Inchs</param>
        /// <returns></returns>
        public static MetricDistance Inches(this float that)
        {
            return new ImperialDistance(ImperialDistance.Inch.ToBaseunit * that).ToMetricDistance();
        }
        /// <summary>
        /// Convert a Inch measurement to ImperialDistance (meters)
        /// </summary>
        /// <param name="that">Inchs</param>
        /// <returns></returns>
        public static MetricDistance Inches(this double that)
        {
            return new ImperialDistance(ImperialDistance.Inch.ToBaseunit * that).ToMetricDistance();
        }
        #endregion
        
        #region Pressure

        /// <summary>
        /// Convert a Bar pressure to MetricPressure (Pascal)
        /// </summary>
        /// <param name="that">Bar</param>
        /// <returns></returns>
        public static MetricPressure Bar(this float that)
        {
            return new MetricPressure(MetricPressure.Bar.ToBaseunit * that);
        }

        #endregion

        #region Weight
        /// <summary>
        /// Convert a Bar pressure to MetricPressure (Pascal)
        /// </summary>
        /// <param name="that">Bar</param>
        /// <returns></returns>
        public static MetricWeight Kilogram(this float that)
        {
            return new MetricWeight(MetricWeight.Kilogram.ToBaseunit * that);
        }
        /// <summary>
        /// Convert a Bar pressure to MetricPressure (Pascal)
        /// </summary>
        /// <param name="that">Bar</param>
        /// <returns></returns>
        public static MetricWeight Kilogram(this int that)
        {
            return new MetricWeight(MetricWeight.Kilogram.ToBaseunit * that);
        }
        #endregion
    }
}
