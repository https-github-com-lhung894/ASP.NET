#pragma checksum "C:\Users\Admin\Desktop\Genaral File\CNPM\CleanArch\Webapplication1\Areas\Admin\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51a49b8c7df005b78e74ca43343743ae956b168a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_User_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/User/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51a49b8c7df005b78e74ca43343743ae956b168a", @"/Areas/Admin/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/_ViewImports.cshtml")]
    public class Areas_Admin_Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/faces/marc.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Genaral File\CNPM\CleanArch\Webapplication1\Areas\Admin\Views\User\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""navbar-wrapper"">
    <a class=""navbar-brand"" href=""javascript:;"">User Profile</a>
</div>
<div class=""row"">
    <div class=""col-md-8"">
        <div class=""card"">
            <div class=""card-header card-header-primary"">
                <h4 class=""card-title"">Edit Profile</h4>
                <p class=""card-category"">Complete your profile</p>
            </div>
            <div class=""card-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "51a49b8c7df005b78e74ca43343743ae956b168a4555", async() => {
                WriteLiteral(@"
                    <div class=""row"">
                        <div class=""col-md-5"">
                            <div class=""form-group bmd-form-group"">
                                <label class=""bmd-label-floating"">Company (disabled)</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("disabled", " disabled=\"", 875, "\"", 886, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                            </div>
                        </div>
                        <div class=""col-md-3"">
                            <div class=""form-group bmd-form-group"">
                                <label class=""bmd-label-floating"">Username</label>
                                <input type=""text"" class=""form-control"">
                            </div>
                        </div>
                        <div class=""col-md-4"">
                            <div class=""form-group bmd-form-group"">
                                <label class=""bmd-label-floating"">Email address</label>
                                <input type=""email"" class=""form-control"">
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-md-6"">
                            <div class=""form-group bmd-form-group"">
                                <label class=""bmd-label-floating"">Fist Name</");
                WriteLiteral(@"label>
                                <input type=""text"" class=""form-control"">
                            </div>
                        </div>
                        <div class=""col-md-6"">
                            <div class=""form-group bmd-form-group"">
                                <label class=""bmd-label-floating"">Last Name</label>
                                <input type=""text"" class=""form-control"">
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-md-12"">
                            <div class=""form-group bmd-form-group"">
                                <label class=""bmd-label-floating"">Adress</label>
                                <input type=""text"" class=""form-control"">
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-md-4"">
      ");
                WriteLiteral(@"                      <div class=""form-group bmd-form-group"">
                                <label class=""bmd-label-floating"">City</label>
                                <input type=""text"" class=""form-control"">
                            </div>
                        </div>
                        <div class=""col-md-4"">
                            <div class=""form-group bmd-form-group"">
                                <label class=""bmd-label-floating"">Country</label>
                                <input type=""text"" class=""form-control"">
                            </div>
                        </div>
                        <div class=""col-md-4"">
                            <div class=""form-group bmd-form-group"">
                                <label class=""bmd-label-floating"">Postal Code</label>
                                <input type=""text"" class=""form-control"">
                            </div>
                        </div>
                    </div>
                    <di");
                WriteLiteral(@"v class=""row"">
                        <div class=""col-md-12"">
                            <div class=""form-group"">
                                <label>About Me</label>
                                <div class=""form-group bmd-form-group"">
                                    <label class=""bmd-label-floating""> Lamborghini Mercy, Your chick she so thirsty, I'm in that two seat Lambo.</label>
                                    <textarea class=""form-control"" rows=""5""></textarea>
                                </div>
                            </div>
                        </div>
                    </div>
                    <button type=""submit"" class=""btn btn-primary pull-right"">Update Profile</button>
                    <div class=""clearfix""></div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-md-4\">\r\n        <div class=\"card card-profile\">\r\n            <div class=\"card-avatar\">\r\n                <a href=\"javascript:;\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "51a49b8c7df005b78e74ca43343743ae956b168a10598", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </a>
            </div>
            <div class=""card-body"">
                <h6 class=""card-category text-gray"">CEO / Co-Founder</h6>
                <h4 class=""card-title"">Alec Thompson</h4>
                <p class=""card-description"">
                    Don't be scared of the truth because we need to restart the human foundation in truth And I love you like Kanye loves Kanye I love Rick Owens’ bed design but the back is...
                </p>
                <a href=""javascript:;"" class=""btn btn-primary btn-round"">Follow</a>
            </div>
        </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
