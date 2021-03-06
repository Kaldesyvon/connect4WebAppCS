#pragma checksum "E:\Skola\dotnet-2021\connect4\connect4Web\Views\Rating\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89f50ee00c432b2f31059f127bae18af99cfb6ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Rating_Index), @"mvc.1.0.view", @"/Views/Rating/Index.cshtml")]
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
#line 1 "E:\Skola\dotnet-2021\connect4\connect4Web\Views\_ViewImports.cshtml"
using connect4Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Skola\dotnet-2021\connect4\connect4Web\Views\_ViewImports.cshtml"
using connect4Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89f50ee00c432b2f31059f127bae18af99cfb6ed", @"/Views/Rating/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"100357f7b95fff82d4256d55135e64989595224e", @"/Views/_ViewImports.cshtml")]
    public class Views_Rating_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<connect4Core.Service.IRatingService>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Rating/Add"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "E:\Skola\dotnet-2021\connect4\connect4Web\Views\Rating\Index.cshtml"
  
    ViewData["Title"] = "Rating";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<link rel=""stylesheet"" href=""lib/bootstrap/dist/css/bootstrap.css"" />


<nav class=""navbar navbar-expand-lg navbar-light bg-light"">
    <div class=""collapse navbar-collapse"" id=""navbarNavAltMarkup"">
        <div class=""navbar-nav"">
            <a class=""nav-item nav-link"" href=""/Connect4"">Connect4</a>
            <a class=""nav-item nav-link"" href=""/Score"">Score</a>
            <a class=""nav-item nav-link"" href=""/Comment"">Comment</a>
            <a class=""nav-item nav-link"" href=""/Rating"">Rating</a>
        </div>
    </div>
</nav>

<p>
    Average is: ");
#nullable restore
#line 23 "E:\Skola\dotnet-2021\connect4\connect4Web\Views\Rating\Index.cshtml"
           Write(Model.GetAverageRating());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "89f50ee00c432b2f31059f127bae18af99cfb6ed4634", async() => {
                WriteLiteral("\r\n    Add Rating<br />\r\n    Name:<input type=\"text\" name=\"Player\" />\r\n    Rating:<input type=\"text\" name=\"Stars\" />\r\n    <input type=\"submit\" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n    <th>\r\n        Player\r\n    </th>\r\n    <th>\r\n        Stars\r\n    </th>\r\n    <th>\r\n        Rated at\r\n    </th>\r\n    </thead>\r\n");
#nullable restore
#line 47 "E:\Skola\dotnet-2021\connect4\connect4Web\Views\Rating\Index.cshtml"
     foreach (var rating in Model.GetRatings())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr><td>");
#nullable restore
#line 49 "E:\Skola\dotnet-2021\connect4\connect4Web\Views\Rating\Index.cshtml"
           Write(rating.Player);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td><td>");
#nullable restore
#line 49 "E:\Skola\dotnet-2021\connect4\connect4Web\Views\Rating\Index.cshtml"
                                  Write(rating.Stars);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td><td>");
#nullable restore
#line 49 "E:\Skola\dotnet-2021\connect4\connect4Web\Views\Rating\Index.cshtml"
                                                        Write(rating.RatedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td></tr>\r\n");
#nullable restore
#line 50 "E:\Skola\dotnet-2021\connect4\connect4Web\Views\Rating\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<connect4Core.Service.IRatingService> Html { get; private set; }
    }
}
#pragma warning restore 1591
