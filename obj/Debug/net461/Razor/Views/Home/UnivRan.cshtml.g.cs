#pragma checksum "C:\Users\User\Dropbox\מלק מסארווה\מחשבים\Universities2\Universities2\Views\Home\UnivRan.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b49c2962a6a0492524287683e74afc8715d5e93"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_UnivRan), @"mvc.1.0.view", @"/Views/Home/UnivRan.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/UnivRan.cshtml", typeof(AspNetCore.Views_Home_UnivRan))]
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
#line 1 "C:\Users\User\Dropbox\מלק מסארווה\מחשבים\Universities2\Universities2\Views\_ViewImports.cshtml"
using Universities2;

#line default
#line hidden
#line 2 "C:\Users\User\Dropbox\מלק מסארווה\מחשבים\Universities2\Universities2\Views\_ViewImports.cshtml"
using Universities2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b49c2962a6a0492524287683e74afc8715d5e93", @"/Views/Home/UnivRan.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c743185b2cc8dbecb21a15c1687f681bf5e878d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_UnivRan : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\User\Dropbox\מלק מסארווה\מחשבים\Universities2\Universities2\Views\Home\UnivRan.cshtml"
  
    ViewData["Title"] = "UnivRan";

#line default
#line hidden
            BeginContext(43, 34, true);
            WriteLiteral("<h1>بطاقة حمراء-جامعة مغلقة</h1>\r\n");
            EndContext();
#line 5 "C:\Users\User\Dropbox\מלק מסארווה\מחשבים\Universities2\Universities2\Views\Home\UnivRan.cshtml"
 foreach (var u2 in ViewData["ClassUniv2"] as List<ClassUniv2>)
{
    

#line default
#line hidden
            BeginContext(151, 8, true);
            WriteLiteral("    <div");
            EndContext();
            BeginWriteAttribute("class", " class=\'", 159, "\'", 249, 3);
            WriteAttributeValue("", 167, "card", 167, 4, true);
            WriteAttributeValue(" ", 171, "mb-3", 172, 5, true);
#line 8 "C:\Users\User\Dropbox\מלק מסארווה\מחשבים\Universities2\Universities2\Views\Home\UnivRan.cshtml"
WriteAttributeValue("", 176, u2.UnivOpen ? "text-white bg-light mb-3" : "text-white bg-danger mb-3", 176, 73, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(250, 36, true);
            WriteLiteral(" style=\" width:400px\">\r\n        <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 286, "\"", 315, 3);
            WriteAttributeValue("", 292, "/images/", 292, 8, true);
#line 9 "C:\Users\User\Dropbox\מלק מסארווה\מחשבים\Universities2\Universities2\Views\Home\UnivRan.cshtml"
WriteAttributeValue("", 300, u2.UnivPhoto, 300, 13, false);

#line default
#line hidden
            WriteAttributeValue("  ", 313, "", 315, 2, true);
            EndWriteAttribute();
            BeginContext(316, 102, true);
            WriteLiteral(" class=\"card-img-top\" alt=\"...\">\r\n        <div class=\"card-body\">\r\n            <h5 class=\"card-title\">");
            EndContext();
            BeginContext(419, 11, false);
#line 11 "C:\Users\User\Dropbox\מלק מסארווה\מחשבים\Universities2\Universities2\Views\Home\UnivRan.cshtml"
                              Write(u2.UnivName);

#line default
#line hidden
            EndContext();
            BeginContext(430, 47, true);
            WriteLiteral("</h5>\r\n            <p class=\"card-text\"> place ");
            EndContext();
            BeginContext(478, 12, false);
#line 12 "C:\Users\User\Dropbox\מלק מסארווה\מחשבים\Universities2\Universities2\Views\Home\UnivRan.cshtml"
                                   Write(u2.UnivPlace);

#line default
#line hidden
            EndContext();
            BeginContext(490, 131, true);
            WriteLiteral(".</p>\r\n            <p class=\"card-text\"><small class=\"text-muted\">Last updated 3 mins ago</small></p>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 16 "C:\Users\User\Dropbox\מלק מסארווה\מחשבים\Universities2\Universities2\Views\Home\UnivRan.cshtml"


    



}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
