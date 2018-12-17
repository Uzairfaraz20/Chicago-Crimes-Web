using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class AreaCrime : PageModel  
    {  
        public List<Models.AreaCrimePercent> CrimesList { get; set; }
		public Exception EX { get; set; }
		public int TotalCrimes { get; set; }
				
  
        public void OnGet()  
        {  
				  List<Models.AreaCrimePercent> crimes = new List<Models.AreaCrimePercent>();
				  
					
					// clear exception:
					EX = null;
					
					try
					{
						string sql = string.Format(@"
SELECT AR.Area, AR.AreaName, COUNT(*) Total_Crimes
FROM dbo.Areas AR
LEFT JOIN dbo.Crimes CR
ON AR.Area = CR.Area 
WHERE AR.Area != 0
GROUP BY AR.Area, AR.AreaName
ORDER BY AR.AreaName
	");

						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

						AllCrimes allCrimes = new AllCrimes();
						
						
						TotalCrimes = allCrimes.GetAllCrimes();
						
						foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.AreaCrimePercent c = new Models.AreaCrimePercent();

							c.AreaNumber = Convert.ToInt32(row["Area"]);
							c.AreaName = Convert.ToString(row["AreaName"]);
							c.NumCrimes = Convert.ToDouble(row["Total_Crimes"]);
							c.CrimePercent = ((c.NumCrimes / TotalCrimes)*100);

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