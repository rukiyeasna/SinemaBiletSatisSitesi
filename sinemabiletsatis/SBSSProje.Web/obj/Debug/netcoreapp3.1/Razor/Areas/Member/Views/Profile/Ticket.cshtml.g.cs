#pragma checksum "C:\Users\casper\Desktop\SİNEMA\SINEMABILETSATIS\sinemabiletsatis\SBSSProje.Web\Areas\Member\Views\Profile\Ticket.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "455610841eb5b31f360bed9d5a6e8f670ef3d789"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Member_Views_Profile_Ticket), @"mvc.1.0.view", @"/Areas/Member/Views/Profile/Ticket.cshtml")]
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
#line 2 "C:\Users\casper\Desktop\SİNEMA\SINEMABILETSATIS\sinemabiletsatis\SBSSProje.Web\Areas\Member\Views\_ViewImports.cshtml"
using SBSSProje.Web.Areas.Member.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\casper\Desktop\SİNEMA\SINEMABILETSATIS\sinemabiletsatis\SBSSProje.Web\Areas\Member\Views\_ViewImports.cshtml"
using SBSSProje.Entities.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"455610841eb5b31f360bed9d5a6e8f670ef3d789", @"/Areas/Member/Views/Profile/Ticket.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7839635f23bf9178dd12cad5345bbdff4154fe0", @"/Areas/Member/Views/_ViewImports.cshtml")]
    public class Areas_Member_Views_Profile_Ticket : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SalesViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\casper\Desktop\SİNEMA\SINEMABILETSATIS\sinemabiletsatis\SBSSProje.Web\Areas\Member\Views\Profile\Ticket.cshtml"
  
    ViewData["Title"] = "Ticket";
    Layout = "~/Areas/Member/Views/Shared/_MemberLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\casper\Desktop\SİNEMA\SINEMABILETSATIS\sinemabiletsatis\SBSSProje.Web\Areas\Member\Views\Profile\Ticket.cshtml"
 foreach (var item in Model)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\casper\Desktop\SİNEMA\SINEMABILETSATIS\sinemabiletsatis\SBSSProje.Web\Areas\Member\Views\Profile\Ticket.cshtml"
Write(item.Date);

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\casper\Desktop\SİNEMA\SINEMABILETSATIS\sinemabiletsatis\SBSSProje.Web\Areas\Member\Views\Profile\Ticket.cshtml"
              
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SalesViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591