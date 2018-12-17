using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class CrimesCodes : PageModel  
    {  
        public List<Models.CrimeGroup> CrimesList { get; set; }
		public Exception EX { get; set; }
		public int TotalCrimes { get; set; }
				
  
        public void OnGet()  
        {  
				  List<Models.CrimeGroup> crimes = new List<Models.CrimeGroup>();
				  
					
					// clear exception:
					EX = null;
					
					try
					{
						string sql = string.Format(@"
SELECT CO.IUCR, CO.PrimaryDesc, CO.SecondaryDesc, COUNT(CR.IUCR) Total_Crimes
FROM dbo.Codes CO
LEFT JOIN dbo.Crimes CR
ON CO.IUCR = CR.IUCR 
GROUP BY CO.IUCR, CO.PrimaryDesc, CO.SecondaryDesc
ORDER BY PrimaryDesc, SecondaryDesc
	");

						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

						TotalCrimes = ds.Tables["TABLE"].Rows.Count;
						
						foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.CrimeGroup c = new Models.CrimeGroup();

							c.IUCR = Convert.ToString(row["IUCR"]);
							c.primDescription = Convert.ToString(row["PrimaryDesc"]);
							c.secDescription = Convert.ToString(row["SecondaryDesc"]);
							c.numCrimes = Convert.ToInt32(row["Total_Crimes"]);

							crimes.Add(c);
						}
					}
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
            CrimesList = crimes;  
				  }
        }  
				
    }//class
}//namespace