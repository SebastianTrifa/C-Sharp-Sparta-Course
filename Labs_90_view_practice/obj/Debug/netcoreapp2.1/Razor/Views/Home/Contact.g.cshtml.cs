#pragma checksum "C:\c-\Labs_90_view_practice\Views\Home\Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "88598ec43f28dd7ad53bbf12e83d31b8272d2471"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Contact), @"mvc.1.0.view", @"/Views/Home/Contact.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Contact.cshtml", typeof(AspNetCore.Views_Home_Contact))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\c-\Labs_90_view_practice\Views\_ViewImports.cshtml"
using Labs_90_view_practice;

#line default
#line hidden
#line 2 "C:\c-\Labs_90_view_practice\Views\_ViewImports.cshtml"
using Labs_90_view_practice.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88598ec43f28dd7ad53bbf12e83d31b8272d2471", @"/Views/Home/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa896ad516e27bae8a8ac0f915a78d7f7368bd91", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Contact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Labs_90_view_practice.Models.Nonstatic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\c-\Labs_90_view_practice\Views\Home\Contact.cshtml"
  
    ViewData["Title"] = "Contact";

#line default
#line hidden
            BeginContext(91, 4, true);
            WriteLiteral("<h2>");
            EndContext();
            BeginContext(96, 17, false);
#line 5 "C:\c-\Labs_90_view_practice\Views\Home\Contact.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(113, 11, true);
            WriteLiteral("</h2>\r\n<h3>");
            EndContext();
            BeginContext(125, 19, false);
#line 6 "C:\c-\Labs_90_view_practice\Views\Home\Contact.cshtml"
Write(ViewData["Message"]);

#line default
#line hidden
            EndContext();
            BeginContext(144, 377, true);
            WriteLiteral(@"</h3>

<address>
    One Microsoft Way<br />
    Redmond, WA 98052-6399<br />
    <abbr title=""Phone"">P:</abbr>
    425.555.0100
</address>

<address>
    <strong>Support:</strong> <a href=""mailto:Support@example.com"">Support@example.com</a><br />
    <strong>Marketing:</strong> <a href=""mailto:Marketing@example.com"">Marketing@example.com</a>
</address>

<ul>
");
            EndContext();
#line 21 "C:\c-\Labs_90_view_practice\Views\Home\Contact.cshtml"
     foreach(var c in Practice.list)
    {

#line default
#line hidden
            BeginContext(566, 12, true);
            WriteLiteral("        <li>");
            EndContext();
            BeginContext(579, 1, false);
#line 23 "C:\c-\Labs_90_view_practice\Views\Home\Contact.cshtml"
       Write(c);

#line default
#line hidden
            EndContext();
            BeginContext(580, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 24 "C:\c-\Labs_90_view_practice\Views\Home\Contact.cshtml"
    }

#line default
#line hidden
            BeginContext(594, 15, true);
            WriteLiteral("</ul>\r\n\r\n<ul>\r\n");
            EndContext();
#line 28 "C:\c-\Labs_90_view_practice\Views\Home\Contact.cshtml"
     foreach (var c in ViewBag.LIstView)
    {

#line default
#line hidden
            BeginContext(658, 12, true);
            WriteLiteral("        <li>");
            EndContext();
            BeginContext(671, 1, false);
#line 30 "C:\c-\Labs_90_view_practice\Views\Home\Contact.cshtml"
       Write(c);

#line default
#line hidden
            EndContext();
            BeginContext(672, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 31 "C:\c-\Labs_90_view_practice\Views\Home\Contact.cshtml"
    }

#line default
#line hidden
            BeginContext(686, 7, true);
            WriteLiteral("</ul>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Labs_90_view_practice.Models.Nonstatic> Html { get; private set; }
    }
}
#pragma warning restore 1591