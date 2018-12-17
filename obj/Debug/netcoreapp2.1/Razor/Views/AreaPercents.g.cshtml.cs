#pragma checksum "/home/codio/workspace/crimes/Views/AreaPercents.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24d03e8701d763aaa00e1f1faec9bd5776d8302e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(crimes.Pages.Views_AreaPercents), @"mvc.1.0.razor-page", @"/Views/AreaPercents.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Views/AreaPercents.cshtml", typeof(crimes.Pages.Views_AreaPercents), null)]
namespace crimes.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/home/codio/workspace/crimes/Views/_ViewImports.cshtml"
using crimes;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24d03e8701d763aaa00e1f1faec9bd5776d8302e", @"/Views/AreaPercents.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f842f8255da31aa43ed40deaf7f18adbc89934f4", @"/Views/_ViewImports.cshtml")]
    public class Views_AreaPercents : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "/home/codio/workspace/crimes/Views/AreaPercents.cshtml"
  
  ViewData["Title"] = "Percent Change of Crimes in an Area";

#line default
#line hidden
            BeginContext(97, 69, true);
            WriteLiteral("\n<h2>Percent Change Information for Area</h2>  \n\n\n<br />\n<h3>Area : \"");
            EndContext();
            BeginContext(167, 14, false);
#line 11 "/home/codio/workspace/crimes/Views/AreaPercents.cshtml"
       Write(Model.AreaName);

#line default
#line hidden
            EndContext();
            BeginContext(181, 14, true);
            WriteLiteral("\"</h3>\n<br />\n");
            EndContext();
#line 13 "/home/codio/workspace/crimes/Views/AreaPercents.cshtml"
  
   if (@Model.EX != null)
	 {

#line default
#line hidden
            BeginContext(228, 16, true);
            WriteLiteral("\t\t <h3>**ERROR: ");
            EndContext();
            BeginContext(245, 16, false);
#line 16 "/home/codio/workspace/crimes/Views/AreaPercents.cshtml"
                 Write(Model.EX.Message);

#line default
#line hidden
            EndContext();
            BeginContext(261, 46, true);
            WriteLiteral("</h3>\n\t\t <br />\n\t\t <hr />\n\t\t <br />\n\t\t <br />\n");
            EndContext();
#line 21 "/home/codio/workspace/crimes/Views/AreaPercents.cshtml"
	 }

#line default
#line hidden
            BeginContext(313, 604, true);
            WriteLiteral(@"
<table class=""table"">  
    <thead>  
        <tr>  
             
			<th>  
                IUCR Code
            </th>  
            <th>  
                Crime Description 
            </th> 
            <th>  
                Area Name
            </th>  
            <th>  
                Max Year 
            </th>  
			<th>  
                Max Year Crimes
            </th>
			<th>  
                Min Year
            </th>
			<th>  
                Min Year Crimes
            </th>
			<th>  
                Percent Change
            </th>
        </tr>  
    </thead>  
    <tbody>  
");
            EndContext();
            BeginContext(938, 5, true);
            WriteLiteral("\t\t\t\t\n");
            EndContext();
#line 59 "/home/codio/workspace/crimes/Views/AreaPercents.cshtml"
         foreach (var item in Model.CrimesList)  
        {  

#line default
#line hidden
            BeginContext(1005, 69, true);
            WriteLiteral("            <tr>  \n                  \n\t\t\t\t<td>  \n                    ");
            EndContext();
            BeginContext(1075, 9, false);
#line 64 "/home/codio/workspace/crimes/Views/AreaPercents.cshtml"
               Write(item.IUCR);

#line default
#line hidden
            EndContext();
            BeginContext(1084, 68, true);
            WriteLiteral("\n                </td>  \n                <td>  \n                    ");
            EndContext();
            BeginContext(1153, 16, false);
#line 67 "/home/codio/workspace/crimes/Views/AreaPercents.cshtml"
               Write(item.description);

#line default
#line hidden
            EndContext();
            BeginContext(1169, 67, true);
            WriteLiteral("\n                </td> \n                <td>  \n                    ");
            EndContext();
            BeginContext(1237, 13, false);
#line 70 "/home/codio/workspace/crimes/Views/AreaPercents.cshtml"
               Write(item.areaName);

#line default
#line hidden
            EndContext();
            BeginContext(1250, 68, true);
            WriteLiteral("\n                </td>  \n                <td>  \n                    ");
            EndContext();
            BeginContext(1319, 12, false);
#line 73 "/home/codio/workspace/crimes/Views/AreaPercents.cshtml"
               Write(item.maxYear);

#line default
#line hidden
            EndContext();
            BeginContext(1331, 55, true);
            WriteLiteral("\n                </td> \n\t\t\t\t<td>  \n                    ");
            EndContext();
            BeginContext(1387, 17, false);
#line 76 "/home/codio/workspace/crimes/Views/AreaPercents.cshtml"
               Write(item.maxYearTotal);

#line default
#line hidden
            EndContext();
            BeginContext(1404, 55, true);
            WriteLiteral("\n                </td> \n\t\t\t\t<td>  \n                    ");
            EndContext();
            BeginContext(1460, 12, false);
#line 79 "/home/codio/workspace/crimes/Views/AreaPercents.cshtml"
               Write(item.minYear);

#line default
#line hidden
            EndContext();
            BeginContext(1472, 54, true);
            WriteLiteral("\n                </td>\n\t\t\t\t<td>  \n                    ");
            EndContext();
            BeginContext(1527, 17, false);
#line 82 "/home/codio/workspace/crimes/Views/AreaPercents.cshtml"
               Write(item.minYearTotal);

#line default
#line hidden
            EndContext();
            BeginContext(1544, 54, true);
            WriteLiteral("\n                </td>\n\t\t\t\t<td>  \n                    ");
            EndContext();
            BeginContext(1599, 35, false);
#line 85 "/home/codio/workspace/crimes/Views/AreaPercents.cshtml"
               Write(item.percentChange.ToString("0.00"));

#line default
#line hidden
            EndContext();
            BeginContext(1634, 44, true);
            WriteLiteral("\n                </td> \n            </tr>  \n");
            EndContext();
#line 88 "/home/codio/workspace/crimes/Views/AreaPercents.cshtml"
						
						
        }  

#line default
#line hidden
            BeginContext(1704, 25, true);
            WriteLiteral("    </tbody>  \n</table> \n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AreaPercentsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AreaPercentsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AreaPercentsModel>)PageContext?.ViewData;
        public AreaPercentsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591