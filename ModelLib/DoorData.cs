using System;

namespace ModelLib
{
    public class DoorData
    {

        public string Id { get; set; }
        public DateTime Datetime { get; set; }

        public DoorData()
        {

        }

        public DoorData(string id, DateTime datetime)
        {
            Id = id;
            Datetime = datetime;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Datetime)}: {Datetime}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            try
            {
                var otherDoorData = (DoorData)obj;
                if (this.Id.Equals(otherDoorData.Id) &&
                    this.Datetime.Equals(otherDoorData.Datetime)) return true;
                return false;
            }
            catch (InvalidCastException)
            {
                return false;
            }
        }
    }
}
