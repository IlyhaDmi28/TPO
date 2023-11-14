using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        private List<Plane> planes;

        public Airport(IEnumerable<Plane> planes)
        {
            this.planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            return planes.Where(plane => plane is PassengerPlane).Select(plane => plane as PassengerPlane).ToList();
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            return planes.Where(plane => plane is MilitaryPlane).Select(plane => plane as MilitaryPlane).ToList();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return planes.Where(plane => plane is PassengerPlane)
                          .Select(plane => plane as PassengerPlane)
                          .OrderBy(plane => plane.GetPassengersCapacity()).First();
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return planes.Where(plane => plane is MilitaryPlane)
                        .Select(plane => plane as MilitaryPlane)
                        .Where(plane => plane.GetPlaneType() == MilitaryType.Transport).ToList();
        }

        public void SortByMaxDistance()
        {
            planes = planes.OrderBy(i => i.GetMaxFlightDistance()).ToList();
        }

        public void SortByMaxSpeed()
        {
            planes = planes.OrderBy(i => i.GetMaxSpeed()).ToList();
        }

        public void SortByMaxLoadCapacity()
        {
            planes = planes.OrderBy(i => i.GetMaxLoadCapacity()).ToList();
        }


        public IEnumerable<Plane> GetPlanes()
        {
            return planes;
        }

        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", planes.Select(x => x.GetModel())) +
                    '}';
        }
    }
}
