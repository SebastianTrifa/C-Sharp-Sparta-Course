#pragma checksum "C:\c-\Labs_re-api\Pages\Table.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26f2bc9378b02ec89e4ebf074ee0d05e6768147b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Labs_re_api.Pages.Pages_Table), @"mvc.1.0.razor-page", @"/Pages/Table.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Table.cshtml", typeof(Labs_re_api.Pages.Pages_Table), null)]
namespace Labs_re_api.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\c-\Labs_re-api\Pages\_ViewImports.cshtml"
using Labs_re_api;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26f2bc9378b02ec89e4ebf074ee0d05e6768147b", @"/Pages/Table.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c38814d02cff48f3854cbf1ce407e48d4294e1e8", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Table : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(165, 115, true);
            WriteLiteral("\r\n<table class=\"tablestyle table-bordered table-hover table-striped\">\r\n    <tr>\r\n        <th>List</th>\r\n    </tr>\r\n");
            EndContext();
#line 10 "C:\c-\Labs_re-api\Pages\Table.cshtml"
     foreach (string s in Model.cities)
    {

#line default
#line hidden
            BeginContext(328, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(359, 1, false);
#line 13 "C:\c-\Labs_re-api\Pages\Table.cshtml"
           Write(s);

#line default
#line hidden
            EndContext();
            BeginContext(360, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 15 "C:\c-\Labs_re-api\Pages\Table.cshtml"
    }

#line default
#line hidden
            BeginContext(389, 119, true);
            WriteLiteral("</table>\r\n\r\n<style>\r\n    table.tablestyle {\r\n        align-self: center;\r\n        margin-top: 200px;\r\n    }\r\n</style>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Labs_ReDoASP.Pages.TableModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Labs_ReDoASP.Pages.TableModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Labs_ReDoASP.Pages.TableModel>)PageContext?.ViewData;
        public Labs_ReDoASP.Pages.TableModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
