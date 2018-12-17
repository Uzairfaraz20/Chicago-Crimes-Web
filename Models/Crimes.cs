namespace crimes.Models
{
  public class Crimes
  {
	  
		  public string IUCR { get; set; }
		  public string description { get; set; }
		  public int totalCrimes { get; set; }
		  public double percentTotal { get; set; }
		  public double percentArrested { get;set; }
		
	  
	  public Crimes(){}
	  
	  public Crimes(string iucr, string desc, int total, double pt, double pa)
		{
			IUCR = iucr;
			description = desc;
			totalCrimes = total;
			percentTotal = pt;
			percentArrested = pa;
		}
  
  }
  
}