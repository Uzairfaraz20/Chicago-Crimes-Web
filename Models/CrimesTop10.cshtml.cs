using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class CrimesTop10Model : PageModel  
    {  
        public List<Models.Crimes> CrimesList { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet()  
        {  
				  List<Models.Crimes> crimes = new List<Models.Crimes>();
				  
					AllCrimes allCrimes = new AllCrimes();
						
						
					double totalCrimes = allCrimes.GetAllCrimes();
					// clear exception:
					EX = null;
					
					try
					{
						string sql = string.Format(@"
SELECT TOP 10 A.IUCR, A.PrimaryDesc + ' ' +   A.SecondaryDesc description, A.Total_Crimes,B.Total_Arrested
FROM
(SELECT CO.IUCR, CO.PrimaryDesc, CO.SecondaryDesc, COUNT(*) Total_Crimes
FROM dbo.Codes CO
RIGHT JOIN dbo.Crimes CR
ON CO.IUCR = CR.IUCR 
GROUP BY CO.IUCR, CO.PrimaryDesc, CO.SecondaryDesc) A
JOIN 
(SELECT CO.IUCR, CO.PrimaryDesc, CO.SecondaryDesc, COUNT(*) Total_Arrested
FROM dbo.Codes CO
RIGHT JOIN dbo.Crimes CR
ON CO.IUCR = CR.IUCR 
WHERE Arrested = 1
GROUP BY CO.IUCR, CO.PrimaryDesc, CO.SecondaryDesc) B
ON B.IUCR = A.IUCR
ORDER BY A.Total_Crimes DESC
	");

						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

						foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.Crimes c = new Models.Crimes();

							c.IUCR = Convert.ToString(row["IUCR"]);
							c.description = Convert.ToString(row["description"]);
							c.totalCrimes = Convert.ToInt32(row["Total_Crimes"]);
							c.percentTotal = Math.Round(((c.totalCrimes / totalCrimes) * 100.00),2);
							double arrested = Convert.ToDouble(row["Total_Arrested"]);
							c.percentArrested = Math.Round(((arrested / c.totalCrimes) * 100.00),2);

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