using System.Collections.Generic;
using Linq.Classes;

namespace Linq.Classes{

class Properties
  {
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Borough { get; set; }
    public string Neighborhood { get; set; }

    public string County { get; set; }
    public string Zip { get; set; }
  }
  class Features
  {
    public string Type { get; set; }

    public  Properties Properties { get; set; }
  }

  class FeaturesCollection
  {
    public string Type { get; set; }

    public List<Features> Features { get; set; }
  }












// class Show{
//     public string showTitle {   get; set; }
// }

// class Actors{
// public List<string> names { get; set; }

// }

// class Director{

// public string directorName {get; set; }

// }

// class Crew{
//     public List<string> position { get; set; }
//     public string crewName {   get; set; }

// }

// class Venue{

// string theatreName { get; set; }

// }
}//namespace Linq