namespace crimes.Models
{
  public class AreaCrimePercent
  {
	  
		  public int AreaNumber { get; set; }
		  public string AreaName { get; set; }
		  public double NumCrimes { get; set; }
		  public double CrimePercent { get; set; }
		
	  
	  public AreaCrimePercent(){}
	  
	  public AreaCrimePercent(int num, string name, double nc, double cp )
		{
			AreaNumber = num;
			AreaName = name;
		    NumCrimes = nc;
		    CrimePercent = cp;
		}
  
  }
  
}