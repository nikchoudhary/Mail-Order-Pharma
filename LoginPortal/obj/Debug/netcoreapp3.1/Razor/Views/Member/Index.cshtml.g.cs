#pragma checksum "C:\Users\Nikhil\Desktop\LOGIN with EF\LoginPortal\Views\Member\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "368a0f4af3aa91f5a6300e1e347ce195f264f3e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Member_Index), @"mvc.1.0.view", @"/Views/Member/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"368a0f4af3aa91f5a6300e1e347ce195f264f3e1", @"/Views/Member/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f653ff198bfaa2d77d8ce748d80eaae20ef1556", @"/Views/_ViewImports.cshtml")]
    public class Views_Member_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Nikhil\Desktop\LOGIN with EF\LoginPortal\Views\Member\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    h1{ font-family:'Times New Roman', Times, serif}

</style>

<h1 align=""center"">Welcome To Mail Order Pharmacy!</h1>

<hr />


<div class=""container col-8"">
<div class=""row"">
    <a href=""/Drug/Index"" class=""col btn btn-danger m-1"">Visit Drug Availabilities</a>

    <a href=""/Refill/Index"" class=""col btn btn-primary m-1"">Drug Refill Details</a>

    <a href=""/Refill/IndexDue"" class=""col btn btn-success m-1"">Check Dues for Refill</a>
    </div>
<div class=""row"">
    <a href=""/Refill/IndexAdhoc"" class=""col btn btn-dark m-1"" >Adhoc Refill Details</a>

    <a href=""/Subscription/Index"" class=""col btn btn-success m-1"">Subscribe to Mail Order</a>

    <a href=""/Subscription/Index1"" class=""col btn btn-danger m-1"">Unsubscribe</a>
</div>
    </div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
