#pragma checksum "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Article\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6d5b670d33e161c9551e0b19f537d6db84028a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Article_Detail), @"mvc.1.0.view", @"/Views/Article/Detail.cshtml")]
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
#line 1 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\_ViewImports.cshtml"
using BlogProject.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\_ViewImports.cshtml"
using BlogProject.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\_ViewImports.cshtml"
using BlogProject.Web.Models.DTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\_ViewImports.cshtml"
using BlogProject.Model.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Article\Detail.cshtml"
using BlogProject.Web.Models.VMs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6d5b670d33e161c9551e0b19f537d6db84028a3", @"/Views/Article/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4bc8ef8a9bf468cfaeae1d7adf874e86aa9bac3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Article_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GetArticleVM>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Article\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    int harfsayisi = @Model.Content.Trim().Length;
    var begeniler = @Model.LikeCount;
    int okumaSuresi = harfsayisi / 50;


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>\r\n    ");
#nullable restore
#line 13 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Article\Detail.cshtml"
Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</h1>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n\r\n\r\n        <dt class=\"col-sm-auto\">\r\n        </dt>\r\n        <dd class=\"col-sm-auto\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 439, "\"", 461, 1);
#nullable restore
#line 24 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Article\Detail.cshtml"
WriteAttributeValue("", 445, Model.ImagePath, 445, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n        </dd>\r\n\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 28 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Article\Detail.cshtml"
       Write(Html.DisplayFor(model => model.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dd class=\"col-sm-10\">\r\n            Yazar : ");
#nullable restore
#line 32 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Article\Detail.cshtml"
               Write(Html.DisplayFor(model => model.UserFullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dd class=\"col-sm-10\">\r\n            Kategori :  ");
#nullable restore
#line 36 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Article\Detail.cshtml"
                   Write(Html.DisplayFor(model => model.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dd class=\"col-sm-10\">\r\n            Oluşturma Tarihi :  ");
#nullable restore
#line 40 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Article\Detail.cshtml"
                           Write(Html.DisplayFor(model => model.CreatedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dd class=\"col-sm-10\">\r\n            <p>Beğeniler : ");
#nullable restore
#line 44 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Article\Detail.cshtml"
                      Write(begeniler);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </dd>\r\n        <dd class=\"col-sm-10\">\r\n            <p>Okuma süresi : ");
#nullable restore
#line 47 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Article\Detail.cshtml"
                         Write(okumaSuresi);

#line default
#line hidden
#nullable disable
            WriteLiteral(" dakika</p>\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6d5b670d33e161c9551e0b19f537d6db84028a37792", async() => {
                WriteLiteral("Back to home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GetArticleVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
