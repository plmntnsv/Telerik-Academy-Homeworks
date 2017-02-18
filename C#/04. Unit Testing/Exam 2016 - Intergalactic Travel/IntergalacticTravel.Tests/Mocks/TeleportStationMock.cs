using System.Collections.Generic;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel
{
    internal class TeleportStationMock : TeleportStation
    {
        public TeleportStationMock(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location)
            : base(owner, galacticMap, location)
        {
        }

        public IResources Resources
        {
            get
            {
                return this.resources;
            }
        }

        public IBusinessOwner Owner
        {
            get
            {
                return this.owner;
            }
        }

        public ILocation Location
        {
            get
            {
                return this.location;
            }
        }

        public IEnumerable<IPath> Path
        {
            get
            {
                return this.galacticMap;
            }
        }
    }
}
