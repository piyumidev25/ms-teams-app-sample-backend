#pragma checksum "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d45bb48f9a9773be69aed3f678ef51ef07bbd33"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\_ViewImports.cshtml"
using TestWebAppToShowTeams;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\_ViewImports.cshtml"
using TestWebAppToShowTeams.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d45bb48f9a9773be69aed3f678ef51ef07bbd33", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0f0d456d2d9de1871dc2a3a69e4c379621ba259", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TestWebAppToShowTeams.Models.LoggedUserTeamsViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <div class=\"text-center\">\r\n        <h1 class=\"display-4\">Welcome</h1>\r\n    </div>\r\n");
#nullable restore
#line 10 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
 if (Model.UserInfo != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""form-group"">
        <div class=""row"">
            <div class=""col-xs-12 col-sm-6 col-md-6 col-lg-4"">
                <h2 class=""control-label"" style=""font-weight:bold"">User Info</h2>
                <hr>
                <dl>
                    <dt>Display Name</dt>
                    <dd>- ");
#nullable restore
#line 19 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
                     Write(Model.UserInfo.DisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n                    <dt>Email</dt>\r\n                    <dd>- ");
#nullable restore
#line 21 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
                     Write(Model.UserInfo.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n                    <dt>Company Name</dt>\r\n");
#nullable restore
#line 23 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
                     if (string.IsNullOrEmpty(@Model.UserInfo.Company))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <dd>- Not Available</dd>\r\n");
#nullable restore
#line 26 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <dd>- ");
#nullable restore
#line 29 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
                         Write(Model.UserInfo.Company);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 30 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <dt>Department</dt>\r\n");
#nullable restore
#line 32 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
                     if (string.IsNullOrEmpty(@Model.UserInfo.Department)){

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <dd>- Not Available</dd>\r\n");
#nullable restore
#line 34 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
                    }
                    else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <dd>- ");
#nullable restore
#line 36 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
                         Write(Model.UserInfo.Department);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 37 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    \r\n                </dl>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 43 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
 if(Model.JoinedTeamsInfo != null && Model.JoinedTeamsInfo.Count>0){

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr />\r\n    <table>\r\n        <tr>\r\n            <th>Display Name</th>\r\n            <th>Owners</th>\r\n            <th>Members</th>\r\n        </tr>\r\n");
#nullable restore
#line 52 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
         foreach (var item in Model.JoinedTeamsInfo)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("           <tr>\n               <td>");
#nullable restore
#line 55 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
              Write(item.DisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    ");
#nullable restore
#line 57 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
               Write(item.Owners);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 60 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
               Write(item.Members);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n           </tr>\n");
#nullable restore
#line 63 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
       }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
#nullable restore
#line 65 "C:\Users\Piyumi\Documents\TestWebAppToShowTeams\TestWebAppToShowTeams\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TestWebAppToShowTeams.Models.LoggedUserTeamsViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591