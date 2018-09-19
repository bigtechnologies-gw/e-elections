using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteManager.Entity
{
    class Region
    {
        // eg: CE - 01
        // CE: circulo eleitoral?
        // Should contains 
        public string CE { get; set; }

        /// <summary>
        /// Names of regions
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of GB sectors
        /// </summary>
        public IReadOnlyList<Sector> Sectors { get; }

        /// <summary>
        /// Returns the sum of vote from all sectors
        /// </summary>
        public decimal Vote // TODO: should CE prop be removed since we already have this one.
        {
            get
            {
                decimal totalVote = 0M;

                foreach (var sector in Sectors)
                {
                    totalVote += sector.Vote;
                }

                return totalVote;
            }
        }


        public Region(string name, List<Sector> sectors)
        {
            Name = name;
            Sectors = sectors;
        }
    }
}
