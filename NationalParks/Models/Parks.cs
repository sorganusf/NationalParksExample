using System;
using System.Collections.Generic;

namespace NationalParks.Models
{
  // Model for parks data. These classes can be obtained by either using 
  // the Visual Studio editor (right-click -> Paste Special -> Paste Json as Classes)
  // or sites such as JsonToCSHarp
  public class Park
  {
    public string official_title { get; set; }
    public string page_count { get; set; }
    public string byte_size { get; set; }

  }

  public class Parks
  {
    public string location { get; set; }
    public List<Park> results { get; set; }
  }
}
