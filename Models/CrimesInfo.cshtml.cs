using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class CrimesInfoModel : PageModel  
    {  
				public List<Models.Crimes> CrimesList { get; set; }
				public string Input { get; set; }
				public int Area { get; set; }
				public string AreaName { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet(string input)  
        {  
				  List<Models.Crimes> crimes = new List<Models.Crimes>();
				  
				  AllCrimes allCrimes = new AllCrimes();
						
						
					double totalCrimes = allCrimes.GetAllCrimes();
				  
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
SELECT TOP 10 A.IUCR, A.PrimaryDesc + ' ' +   A.SecondaryDesc description, A.Area, A.AreaName, A.Total_Crimes,B.Total_Arrested 
FROM
(SELECT CO.IUCR, CO.PrimaryDesc, CO.SecondaryDesc, COUNT(*) Total_Crimes, AR.AreaName, AR.Area
FROM dbo.Codes CO
RIGHT JOIN dbo.Crimes CR
ON CO.IUCR = CR.IUCR 
RIGHT JOIN dbo.Areas AR
ON AR.Area = CR.Area
WHERE AR.Area = {0}
GROUP BY CO.IUCR, CO.PrimaryDesc, CO.SecondaryDesc, AR.AreaName, AR.Area) A
JOIN 
(SELECT CO.IUCR, CO.PrimaryDesc, CO.SecondaryDesc, COUNT(*) Total_Arrested, AR.AreaName, AR.Area
FROM dbo.Codes CO
RIGHT JOIN dbo.Crimes CR
ON CO.IUCR = CR.IUCR
RIGHT JOIN dbo.Areas AR
ON AR.Area = CR.Area 
WHERE AR.Area = {1} 
AND Arrested = 1
GROUP BY CO.IUCR, CO.PrimaryDesc, CO.SecondaryDesc, AR.AreaName, AR.Area) B
ON B.IUCR = A.IUCR
ORDER BY A.Total_Crimes DESC
	",input,input);
					} else
							{
								// lookup movie(s) by partial name match:
								input = input.Replace("'", "''");

								sql = string.Format(@"
	SELECT TOP 10 A.IUCR, A.PrimaryDesc + ' ' +   A.SecondaryDesc description, A.Area, A.AreaName, A.Total_Crimes,B.Total_Arrested 
FROM
(SELECT CO.IUCR, CO.PrimaryDesc, CO.SecondaryDesc, COUNT(*) Total_Crimes, AR.AreaName, AR.Area
FROM dbo.Codes CO
RIGHT JOIN dbo.Crimes CR
ON CO.IUCR = CR.IUCR 
RIGHT JOIN dbo.Areas AR
ON AR.Area = CR.Area
WHERE AR.AreaName = '{0}' 
GROUP BY CO.IUCR, CO.PrimaryDesc, CO.SecondaryDesc, AR.AreaName, AR.Area) A
JOIN 
(SELECT CO.IUCR, CO.PrimaryDesc, CO.SecondaryDesc, COUNT(*) Total_Arrested, AR.AreaName, AR.Area
FROM dbo.Codes CO
RIGHT JOIN dbo.Crimes CR
ON CO.IUCR = CR.IUCR
RIGHT JOIN dbo.Areas AR
ON AR.Area = CR.Area 
WHERE AR.AreaName = '{1}' 
AND Arrested = 1
GROUP BY CO.IUCR, CO.PrimaryDesc, CO.SecondaryDesc, AR.AreaName, AR.Area) B
ON B.IUCR = A.IUCR
ORDER BY A.Total_Crimes DESC
	", input,input);
							}
						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);
						
						if(ds == null || ds.Tables.Count == 0 || ds.Tables["Table"].Rows.Count == 0){
								throw new Exception("No data found for " + input);
							}

						foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.Crimes c = new Models.Crimes();

							AreaName = Convert.ToString(row["AreaName"]);
							c.IUCR = Convert.ToString(row["IUCR"]);
							c.description = Convert.ToString(row["description"]);
							c.totalCrimes = Convert.ToInt32(row["Total_Crimes"]);
							c.percentTotal = Math.Round(((c.totalCrimes / totalCrimes) * 100.00),2);
							double arrested = Convert.ToDouble(row["Total_Arrested"]);
							c.percentArrested = Math.Round(((arrested / c.totalCrimes) * 100.00),2);
							Area = Convert.ToInt32(row["Area"]);
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