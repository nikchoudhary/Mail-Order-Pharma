#pragma checksum "C:\Users\Nikhil\Desktop\LOGIN with EF\LoginPortal\Views\Drug\DrugDetailsall.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04d6d024255ed7580f564a199b51808745c50f39"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Drug_DrugDetailsall), @"mvc.1.0.view", @"/Views/Drug/DrugDetailsall.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Nikhil\Desktop\LOGIN with EF\LoginPortal\Views\_ViewImports.cshtml"
using LoginPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nikhil\Desktop\LOGIN with EF\LoginPortal\Views\_ViewImports.cshtml"
using LoginPortal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04d6d024255ed7580f564a199b51808745c50f39", @"/Views/Drug/DrugDetailsall.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f653ff198bfaa2d77d8ce748d80eaae20ef1556", @"/Views/_ViewImports.cshtml")]
    public class Views_Drug_DrugDetailsall : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LoginPortal.Models.Drugloc>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Nikhil\Desktop\LOGIN with EF\LoginPortal\Views\Drug\DrugDetailsall.cshtml"
  
    ViewData["Title"] = "DrugDetailsall";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4>Drug Details By Location </h4>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 15 "C:\Users\Nikhil\Desktop\LOGIN with EF\LoginPortal\Views\Drug\DrugDetailsall.cshtml"
           Write(Html.DisplayNameFor(model => model.Drug_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "C:\Users\Nikhil\Desktop\LOGIN with EF\LoginPortal\Views\Drug\DrugDetailsall.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "C:\Users\Nikhil\Desktop\LOGIN with EF\LoginPortal\Views\Drug\DrugDetailsall.cshtml"
           Write(Html.DisplayNameFor(model => model.ExpiryDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Users\Nikhil\Desktop\LOGIN with EF\LoginPortal\Views\Drug\DrugDetailsall.cshtml"
           Write(Html.DisplayNameFor(model => model.Available_Stock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "C:\Users\Nikhil\Desktop\LOGIN with EF\LoginPortal\Views\Drug\DrugDetailsall.cshtml"
           Write(Html.DisplayNameFor(model => model.Location));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 33 "C:\Users\Nikhil\Desktop\LOGIN with EF\LoginPortal\Views\Drug\DrugDetailsall.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 36 "C:\Users\Nikhil\Desktop\LOGIN with EF\LoginPortal\Views\Drug\DrugDetailsall.cshtml"
           Write(item.Drug_Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 39 "C:\Users\Nikhil\Desktop\LOGIN with EF\LoginPortal\Views\Drug\DrugDetailsall.cshtml"
           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 42 "C:\Users\Nikhil\Desktop\LOGIN with EF\LoginPortal\Views\Drug\DrugDetailsall.cshtml"
           Write(item.ExpiryDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 45 "C:\Users\Nikhil\Desktop\LOGIN with EF\LoginPortal\Views\Drug\DrugDetailsall.cshtml"
           Write(item.Available_Stock);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 48 "C:\Users\Nikhil\Desktop\LOGIN with EF\LoginPortal\Views\Drug\DrugDetailsall.cshtml"
           Write(item.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n           \r\n        </tr>\r\n");
#nullable restore
#line 52 "C:\Users\Nikhil\Desktop\LOGIN with EF\LoginPortal\Views\Drug\DrugDetailsall.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LoginPortal.Models.Drugloc>> Html { get; private set; }
    }
}
#pragma warning restore 1591
