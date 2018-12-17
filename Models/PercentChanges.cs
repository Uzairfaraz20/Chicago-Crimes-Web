namespace crimes.Models
{
  public class PercentChanges
  {
	  
		  public string IUCR { get; set; }
		  public string description { get; set; }
	      public string areaName { get; set;}
	      public int maxYear { get; set; }
	      public double maxYearTotal { get; set; }
	      public int minYear { get; set; }
	      public double minYearTotal { get; set; }
		  public double percentChange { get; set; }
		
	  
	  public PercentChanges(){}
	  
	  public PercentChanges(string iucr, string desc, string name, int maxY, double maxYTotal, int minY,
						   double minYTotal, double pc)
		{
			IUCR = iucr;
			description = desc;
		    areaName = name;
		    maxYear = maxY;
		    maxYearTotal = maxYTotal;
		    minYear = minY;
		    minYearTotal = minYTotal;
			percentChange = pc;

		}
  
  }
  
}