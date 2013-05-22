using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Links;
using Sitecore.StringExtensions;

namespace Autohaus.Data.Models
{
    public class Car : SearchResultItem
    {
        #region Fields

        private string friendlyUrl;
        private string fullModelName;

        #endregion

        #region Basic string fields

        [IndexField("modelkey")]
        public string ModelId { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Trim { get; set; }

        #endregion

        #region Non-string Properties

        public DateTime ManufactureDate { get; set; }

        public int EngineCC { get; set; }

        public int NumCylinders { get; set; }

        public int ValvesPerCyl { get; set; }

        public int EnginePower { get; set; }

        public bool SoldInUS { get; set; }

        public int Seats { get; set; }

        public IEnumerable<int> Doors { get; set; }

        public float Weight { get; set; }

        public float Length { get; set; }

        public float Width { get; set; }

        public float Height { get; set; }

        public float Wheelbase { get; set; }

        public float MileageHwy { get; set; }

        public float MileageCity { get; set; }

        public float MileageMixed { get; set; }

        public int TopSpeed { get; set; }

        public float ZeroToHundred { get; set; }

        public float FuelCapacity { get; set; }

        public int EnginePowerRPM { get; set; }

        public int EngineTorqueNM { get; set; }

        public float EngineBoreMM { get; set; }

        public float EngineStrokeMM { get; set; }

        public string EngineCompression { get; set; }

        #endregion

        #region Reference Fields

        public string TransmissionType { get; set; }

        public string DriveType { get; set; }

        public string BodyType { get; set; }

        public string EnginePosition { get; set; }

        public string EngineType { get; set; }

        public string EngineFuel { get; set; }

        #endregion

        #region Computed Properties

        [DataMember]
        public string FullModelName
        {
            get
            {
                if (string.IsNullOrEmpty(fullModelName))
                {
                    fullModelName = "{0} {1} {2} {3}".FormatWith(ManufactureDate.Year, Make, Model, Trim);
                }

                return fullModelName;
            }

            set { fullModelName = value; }
        }

        [DataMember]
        public string FriendlyUrl
        {
            get
            {
                if (friendlyUrl.IsNullOrEmpty())
                {
                    friendlyUrl = Uri == null ? string.Empty : LinkManager.GetItemUrl(Database.GetItem(Uri));
                }

                return friendlyUrl;
            }

            set { friendlyUrl = value; }
        }

        #endregion
    }
}