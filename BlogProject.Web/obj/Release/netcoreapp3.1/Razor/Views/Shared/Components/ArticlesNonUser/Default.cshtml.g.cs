#pragma checksum "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd0b05f3fd2128f761eba1265e5db682c1f2b771"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ArticlesNonUser_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ArticlesNonUser/Default.cshtml")]
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
#line 1 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
using BlogProject.Web.Areas.Member.Models.VMs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd0b05f3fd2128f761eba1265e5db682c1f2b771", @"/Views/Shared/Components/ArticlesNonUser/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4bc8ef8a9bf468cfaeae1d7adf874e86aa9bac3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_ArticlesNonUser_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<GetArticleForNonUserComponentDTO>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ProfilePage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Article", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"col-md-12\">\r\n    <div class=\"card card-widget\">\r\n        <div class=\"card-header\">\r\n            <div class=\"user-block\">\r\n                <span class=\"username\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd0b05f3fd2128f761eba1265e5db682c1f2b7715679", async() => {
#nullable restore
#line 11 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
                                                                                                                Write(item.UserFullName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 11 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
                                                                                           WriteLiteral(item.UserId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</span>\r\n                <span class=\"description\">Shared publicly - ");
#nullable restore
#line 12 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
                                                       Write(item.CreatedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n            <!-- /.user-block -->\r\n");
            WriteLiteral("            <!-- /.card-tools -->\r\n        </div>\r\n        <!-- /.card-header -->\r\n        <div class=\"card-body\">\r\n            <img class=\"img-fluid pad\"");
            BeginWriteAttribute("src", " src=\"", 1261, "\"", 1278, 1);
#nullable restore
#line 30 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
WriteAttributeValue("", 1267, item.Image, 1267, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Photo\">\r\n            <p><b>");
#nullable restore
#line 31 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
             Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n            <p>");
#nullable restore
#line 32 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
          Write(item.Content.Substring(0,30));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd0b05f3fd2128f761eba1265e5db682c1f2b77110113", async() => {
                WriteLiteral("devamını okumak için tıklayınız...");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
                                                              WriteLiteral(item.ArticleID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 35 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
         foreach (var ite in Model)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
             if (ite.Comments != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
                 foreach (var itemz in @ite.Comments)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
                     if (@ite.ArticleID == @itemz.ArticleId)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <!-- /.card-body -->
                        <div class=""card-footer card-comments"">
                            <div class=""card-comment"">
                                <div class=""product-image-thumb"">
                                    <img");
            BeginWriteAttribute("src", " src=\"", 2066, "\"", 2082, 1);
#nullable restore
#line 47 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
WriteAttributeValue("", 2072, ite.Image, 2072, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                </div>\r\n                                <div class=\"comment-text\">\r\n                                    <span class=\"username\">\r\n                                        ");
#nullable restore
#line 51 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
                                   Write(ite.UserFullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </span>\r\n                                </div>\r\n                            </div>\r\n                            ");
#nullable restore
#line 55 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
                       Write(itemz.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <!-- /.card-footer -->\r\n");
#nullable restore
#line 58 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
                 
            }
            else
            {

            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <!-- /.card-footer -->\r\n</div>\r\n    </div>\r\n");
#nullable restore
#line 70 "C:\Users\tugbe\Downloads\BlogProject5432_25062022\BlogProject.Web\Views\Shared\Components\ArticlesNonUser\Default.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<GetArticleForNonUserComponentDTO>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
