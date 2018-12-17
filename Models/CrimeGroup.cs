namespace crimes.Models
{
  public class CrimeGroup
  {
	  
		  public string IUCR { get; set; }
		  public string primDescription { get; set; }
		  public string secDescription { get; set; }
		  public int numCrimes { get; set; }
		  
		
	  
	  public CrimeGroup(){}
	  
	  public CrimeGroup(string iucr, string pDesc, string sDesc, int total)
		{
			IUCR = iucr;
			primDescription = pDesc;
			secDescription = sDesc;
			numCrimes = total;
		}
  
  }
  
}