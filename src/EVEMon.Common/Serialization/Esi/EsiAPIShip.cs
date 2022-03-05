using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace EVEMon.Common.Serialization.Esi
{
    /// <summary>
    /// Represents a serializable version of a character's current ship.
    /// </summary>
    [DataContract]
    public sealed class EsiAPIShip
    {
        [DataMember(Name = "ship_type_id")]
        public int ShipTypeID { get; set; }

        // Unique to a particular ship until repackaged
        [DataMember(Name = "ship_item_id")]
        public long ShipItemID { get; set; }

        private string _ShipName;
        [DataMember(Name = "ship_name")]
        public string ShipName
        {
            get { return _ShipName; }
            set
            {
                Regex pattern = new Regex(@"^u'(.*)'$");
                Match match = pattern.Match(value);
                if (match.Success)
                {
                    _ShipName = Regex.Unescape(match.Groups[1].Value);
                }
                else
                {
                    _ShipName = value;
                }
            }
        }

        
    }
}
