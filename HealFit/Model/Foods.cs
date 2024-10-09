using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealFit.Model; 
public class Foods {
    public List<Food> Food { get; set; }
    public int MaxResults { get; set; }
    public int PageNumber { get; set; }
    public int TotalResults { get; set; }
}
