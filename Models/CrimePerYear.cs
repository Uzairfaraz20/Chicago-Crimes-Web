using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class CrimesPerYearModel : PageModel  
    {  
				public List<int> CrimesList { get; set; }
				public List<int> YearList { get; set; }
				public Exception EX { get; set; }
			
  
        public void OnGet()  
        {  
				  
				  CrimesList = new List<int>();
				  YearList = new List<int>();
				 
			
					
					// clear exception:
					EX = null;
					
					try
					{
						
						
							string sql;

							
								
								

								sql = string.Format(@"
SELECT Year, COUNT(*) Total_Crimes
FROM dbo.Codes CO
RIGHT JOIN dbo.Crimes CR
ON CO.IUCR = CR.IUCR 
RIGHT JOIN dbo.Areas AR
ON AR.Area = CR.Area
GROUP BY Year
ORDER BY Year
	");
							
						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

						foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							

							
							int totalCrimes = Convert.ToInt32(row["Total_Crimes"]);
							CrimesList.Add(totalCrimes);
							
							int year = Convert.ToInt32(row["Year"]);
							YearList.Add(year);
							
						}
					
					}
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
            
				  }
        }
			
    
	}//class 
}//namespace