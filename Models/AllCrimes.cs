using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class AllCrimes 
    {  
        
		public Exception EX { get; set; }
		
  
        public int GetAllCrimes()  
        {  
				  int allCrimes = 0;
				  
					
					// clear exception:
					EX = null;
					
					try
					{
						string sql = string.Format(@"
SELECT COUNT(*) allCrimes
FROM dbo.Crimes 
	");

						allCrimes = Convert.ToInt32(DataAccessTier.DB.ExecuteScalarQuery(sql));

					}
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
					 
						
				    }
			return allCrimes;
        }  
				
    }//class
}//namespace