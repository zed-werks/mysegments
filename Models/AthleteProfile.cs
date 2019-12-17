using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mysegments.Models
{
    public class AthleteProfile
    {
        public string athleteId;
        public string username;
        public string firstName;
        public string lastName;
        public string city;
        public string state;
        public string country;
        public string profileUri;
        public string units;

        public AthleteProfile(string athleteId, string username, string profileUri, string units)
        {
            this.athleteId = athleteId;
            this.username = username;
            this.profileUri = profileUri;
            this.units = units;
        }
    }
}
