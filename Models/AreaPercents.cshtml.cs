using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class AreaPercentsModel : PageModel  
    {  
				public List<Models.PercentChanges> CrimesList { get; set; }
				public string Input { get; set; }
				public string AreaName { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet(string input)  
        {  
				  List<Models.PercentChanges> crimes = new List<Models.PercentChanges>();
				  
					Input = input;
					// clear exception:
					EX = null;
					
					try
					{
						
						if (input == null)
						{
							//
							// there's no page argument, perhaps user surfed to the page directly?  
							// In this case, nothing to do.
							//
						}
						else  
						{
							// 
							// Lookup movie(s) based on input, which could be id or a partial name:
							// 
							int id;
							string sql;

							if (System.Int32.TryParse(input, out id))
							{
						
						
						
						sql = string.Format(@"
SELECT A.IUCR, A.PrimaryDesc + ' ' +   A.SecondaryDesc description, 
A.AreaName, A.Year AS MaxYear, A.Total_Crimes AS Total_Max, B.Year AS MinYear, B.Total_Crimes AS Total_Min, a.Total_Crimes/B.Total_Crimes AS change_pct
FROM
(SELECT CO.IUCR, CO.PrimaryDesc, CO.SecondaryDesc, COUNT(*) Total_Crimes, AR.AreaName, Year
FROM dbo.Codes CO
RIGHT JOIN dbo.Crimes CR
ON CO.IUCR = CR.IUCR 
RIGHT JOIN dbo.Areas AR
ON AR.Area = CR.Area
WHERE AR.Area = {0}
AND Year = (SELECT MAX(Year) FROM dbo.Crimes WHERE Area = AR.Area)
GROUP BY CO.IUCR, CO.PrimaryDesc, CO.SecondaryDesc, AR.AreaName, YEAR) A
JOIN 
(SELECT CO.IUCR, CO.PrimaryDesc, CO.SecondaryDesc, COUNT(*) Total_Crimes, AR.AreaName, Year
FROM dbo.Codes CO
RIGHT JOIN dbo.Crimes CR
ON CO.IUCR = CR.IUCR
RIGHT JOIN dbo.Areas AR
ON AR.Area = CR.Area 
WHERE AR.Area = {1}
AND Year = (SELECT MIN(Year) FROM dbo.Crimes WHERE Area = AR.Area)
GROUP BY CO.IUCR, CO.PrimaryDesc, CO.SecondaryDesc, AR.AreaName, YEAR) B
ON B.IUCR = A.IUCR
ORDER BY A.Total_Crimes DESC
	",input,input);
					} else{
					
					throw new Exception("Invalid Input, input requires number");
					
					}
						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);
						
						if(ds == null || ds.Tables.Count == 0 || ds.Tables["Table"].Rows.Count == 0){
								throw new Exception("No data found for " + input);
							}

						foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.PercentChanges c = new Models.PercentChanges();

							c.IUCR = Convert.ToString(row["IUCR"]);
							c.description = Convert.ToString(row["description"]);
							c.areaName = Convert.ToString(row["AreaName"]);
							c.maxYear = Convert.ToInt32(row["MaxYear"]);
							c.maxYearTotal = Convert.ToDouble(row["Total_Max"]);
							c.minYear = Convert.ToInt32(row["MinYear"]);
							c.minYearTotal = Convert.ToDouble(row["Total_Min"]);
							c.percentChange = Convert.ToDouble(row["change_pct"]) * 100 ;
							AreaName = c.areaName;
							
							if(c.maxYearTotal < c.minYearTotal){
								c.percentChange = ((c.minYearTotal/c.maxYearTotal) * -1) * 100;
							}
							
							crimes.Add(c);
						}
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