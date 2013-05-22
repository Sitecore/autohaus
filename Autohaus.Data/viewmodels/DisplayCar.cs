using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Autohaus.Data.Models;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.StringExtensions;

namespace Autohaus.Data.ViewModels
{
    public class DisplayCar
    {
        protected DisplayCar()
        {
        }

        public DisplayCar(Car car)
        {
            Data = car;
            Images = new string[0];
        }

        public DisplayCar(Car car, Item item)
        {
            Assert.IsNotNull(car, "car");
            Assert.IsNotNull(item, "item");

            Data = car;
            Images = item.GetImageUrls(1170, 0);
        }

        public Car Data { get; protected set; }

        public Item InnerItem { get; protected set; }

        public string NA
        {
            get { return Translate.Text("N/A"); }
        }

        public int Year
        {
            get { return Data.ManufactureDate.Year; }
        }

        public string Dimensions
        {
            get
            {
                string length = string.Format("{0} {1}", Data.Length.ToString(CultureInfo.InvariantCulture), "cm");
                if (length == "0")
                {
                    length = NA;
                }

                string height = string.Format("{0} {1}", Data.Height.ToString(CultureInfo.InvariantCulture), "cm");
                if (height == "0")
                {
                    height = NA;
                }

                string weight = string.Format("{0} {1}", Data.Weight.ToString(CultureInfo.InvariantCulture), "kg");
                if (weight == "0")
                {
                    weight = NA;
                }

                string wheelbase = string.Format("{0} {1}", Data.Wheelbase.ToString(CultureInfo.InvariantCulture), "cm");
                if (wheelbase == "0")
                {
                    wheelbase = NA;
                }

                return string.Format("{0}, {1}, {2}, {3}", length, height, weight, wheelbase);
            }
        }

        public string EnginePower
        {
            get
            {
                string bhp = string.Format("{0} {1}", Data.EnginePower.ToString(CultureInfo.InvariantCulture), "bhp");
                if (Data.EnginePower == 0)
                {
                    bhp = NA;
                }

                string rpm = string.Format("{0} {1}", Data.EnginePowerRPM.ToString(CultureInfo.InvariantCulture), "rpm");
                if (Data.EnginePowerRPM == 0)
                {
                    rpm = NA;
                }

                string nm = string.Format("{0} {1}", Data.EngineTorqueNM.ToString(CultureInfo.InvariantCulture), "Nm");
                if (Data.EngineTorqueNM == 0)
                {
                    nm = NA;
                }

                return string.Format("{0}, {1}, {2}", bhp, rpm, nm);
            }
        }

        public string FuelCapacity
        {
            get
            {
                string fuelCapacity = Data.FuelCapacity.ToString(CultureInfo.InvariantCulture);
                return fuelCapacity == "0" ? NA : fuelCapacity + " liters";
            }
        }

        public string FuelType
        {
            get { return string.IsNullOrEmpty(Data.EngineFuel) ? NA : Data.EngineFuel; }
        }

        public string Transmission
        {
            get { return string.IsNullOrEmpty(Data.TransmissionType) ? NA : Data.TransmissionType; }
        }

        public string Body
        {
            get { return string.IsNullOrEmpty(Data.BodyType) ? NA : Data.BodyType; }
        }

        public string Seats
        {
            get { return Data.Seats <= 0 ? NA : Data.Seats.ToString(CultureInfo.InvariantCulture); }
        }

        public string Doors
        {
            get
            {
                if (Data.Doors == null || !Data.Doors.Any())
                {
                    return NA;
                }

                return String.Join(" - ", Data.Doors);
            }
        }

        public IEnumerable<string> Images { get; protected set; }

        public string EngineDescription
        {
            get
            {
                var stringBuilder = new StringBuilder();

                if (!string.IsNullOrEmpty(Data.EngineType))
                {
                    stringBuilder.Append(Data.EngineType);

                    if (Data.NumCylinders > 0)
                    {
                        stringBuilder.Append("-");
                        stringBuilder.Append(Data.NumCylinders);
                    }
                }

                if (Data.EngineCC > 0)
                {
                    if (stringBuilder.Length > 0)
                    {
                        stringBuilder.Append(", ");
                    }

                    stringBuilder.Append("{0} liters".FormatWith(Math.Round(Data.EngineCC*1.0/1000, 1)));
                }

                string engineSpecs = stringBuilder.ToString();

                return engineSpecs.IsNullOrEmpty() ? NA : engineSpecs;
            }
        }

        public string Acceleration
        {
            get
            {
                string actual = Data.ZeroToHundred.ToString(CultureInfo.InvariantCulture);
                return actual.Equals("0") ? NA : actual;
            }
        }

        public string EngineFuel
        {
            get { return Data.EngineFuel.IsNullOrEmpty() ? NA : Data.EngineFuel; }
        }

        public string EngineType
        {
            get { return Data.EngineType.IsNullOrEmpty() ? NA : Data.EngineType; }
        }

        public string TopSpeed
        {
            get
            {
                string actual = Data.TopSpeed.ToString(CultureInfo.InvariantCulture);
                return actual.Equals("0") ? NA : actual;
            }
        }

        public string MileageMixed
        {
            get
            {
                string actual = Data.MileageMixed.ToString(CultureInfo.InvariantCulture);
                return actual.Equals("0") ? NA : actual;
            }
        }

        public string MileageCity
        {
            get
            {
                string actual = Data.MileageCity.ToString(CultureInfo.InvariantCulture);
                return actual.Equals("0") ? NA : actual;
            }
        }

        public string MileageHwy
        {
            get
            {
                string actual = Data.MileageHwy.ToString(CultureInfo.InvariantCulture);
                return actual.Equals("0") ? NA : actual;
            }
        }

        public string FullModelName
        {
            get { return Data.FullModelName; }
        }

        public string FriendlyUrl
        {
            get { return Data.FriendlyUrl; }
        }

        public static DisplayCar CreateFromItem(Item item)
        {
            Assert.IsNotNull(item, "item");
            Car car = SearchService.GetCarByIdOrAny(item.ID);
            return car == null ? new DisplayCar() : new DisplayCar(car, item);
        }
    }
}