#pragma checksum "C:\Users\Nayn\OneDrive\Documents\GitHub\Metrodata-Coding-Camp-Program-.NET\Client\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d57db63020ac5b69e6becdafee2ab2e834fc80b5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Index), @"mvc.1.0.view", @"/Views/Dashboard/Index.cshtml")]
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
#line 1 "C:\Users\Nayn\OneDrive\Documents\GitHub\Metrodata-Coding-Camp-Program-.NET\Client\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nayn\OneDrive\Documents\GitHub\Metrodata-Coding-Camp-Program-.NET\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d57db63020ac5b69e6becdafee2ab2e834fc80b5", @"/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("number"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Nayn\OneDrive\Documents\GitHub\Metrodata-Coding-Camp-Program-.NET\Client\Views\Dashboard\Index.cshtml"
  
    ViewData["Title"] = "Dashboard";
    Layout = "_DashboardLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table class=""table table-hover table-border TabelMasterData"" >
    <thead class=""thead-dark"">
        <tr>
            <th>NIK</th>
            <th>Nama Lengkap</th>
            <th>Gender</th>
            <th>Birthdate</th>
            <th>Telepon</th>
            <th>Email</th>
            <th>Jabatan</th>
            <th>Salary</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody class=""MasterData"">
    </tbody>
</table>

<button id = ""addEmp"" class=""btn btn-primary"" onclick=""GetUniData()"" data-toggle=""modal"" data-target=""#submitForm"">Register</button>

                                                <!-- Register employee modal-->
<div class=""modal fade"" id=""submitForm"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Registration</h5>
              ");
            WriteLiteral("  <button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\">\r\n                    <span aria-hidden=\"true\">&times;</span>\r\n                </button>\r\n            </div>\r\n            <div class=\"modal-body\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d57db63020ac5b69e6becdafee2ab2e834fc80b56038", async() => {
                WriteLiteral(@"
                  <div class=""form-row"">
                        <div class=""col-md-3 mb-3"">
                            <label for=""validationCustom01"">First name</label>
                            <input id=""firstname"" type=""text"" class=""form-control"" placeholder=""First name"" required>
                            <div class=""valid-feedback"">
                                Looks good!
                            </div>
                        </div>
                        <div class=""col-md-3 mb-3"">
                            <label for=""validationCustom02"">Last name</label>
                            <input id=""lastname"" type=""text"" class=""form-control"" placeholder=""Last name"" required>
                            <div class=""valid-feedback"">
                                Looks good!
                            </div>
                        </div>
                         <div class=""col-md-3 mb-3"">
                            <label for=""validationCustom02"">Gender</label>
       ");
                WriteLiteral("                     <select id=\"gender\" class=\"custom-select mr-sm-2\">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d57db63020ac5b69e6becdafee2ab2e834fc80b57497", async() => {
                    WriteLiteral("Choose...");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d57db63020ac5b69e6becdafee2ab2e834fc80b58869", async() => {
                    WriteLiteral("Male");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d57db63020ac5b69e6becdafee2ab2e834fc80b510209", async() => {
                    WriteLiteral("Female");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            </select>
                            <div class=""valid-feedback"">
                                Looks good!
                            </div>
                        </div>
                         <div class=""col-md-3 mb-3"">
                            <label for=""validationCustom02"">Birth date</label>
                            <input id=""birthdate"" type=""date"" class=""form-control"" placeholder=""birthdate"" required>
                            <div class=""valid-feedback"">
                                Looks good!
                            </div>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""col-md-4 mb-3"">
                            <label for=""validationCustom03"">Phone</label>
                            <input id=""phone"" type=""text"" class=""form-control"" placeholder=""Phone"" required>
                            <div class=""invalid-feedback"">
                   ");
                WriteLiteral(@"             Please provide a valid city.
                            </div>
                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label for=""validationCustomUsername"">Email</label>
                            <div class=""input-group"">
                                <input id=""email"" type=""text"" class=""form-control"" placeholder=""Email"" aria-describedby=""inputGroupPrepend"" required>
                                <div class=""invalid-feedback"">
                                    Please enter your email.
                                </div>
                            </div>
                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label for=""validationCustom04"">Password</label>
                            <input id=""password"" type=""text"" class=""form-control"" placeholder=""Password"" required>
                            <div class=""invalid-feedback"">
                                ");
                WriteLiteral(@"Please provide a password.
                            </div>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""col-md-3 mb-3"">
                            <label for=""validationCustom03"">University</label>
                            <select id=""uni"" class=""custom-select mr-sm-2"">
                            </select>
                            <div class=""invalid-feedback"">
                                Please enter a university.
                            </div>
                        </div>
                        <div class=""col-md-3 mb-3"">
                            <label for=""validationCustom04"">Degree</label>
                            <input id=""degree"" type=""text"" class=""form-control"" placeholder=""Latest Degree"" required>
                            <div class=""invalid-feedback"">
                                Please provide the degree.
                            </div>
               ");
                WriteLiteral(@"         </div>
                        <div class=""col-md-3 mb-3"">
                            <label for=""validationCustom05"">GPA</label>
                            <input id=""gpa"" type=""text"" class=""form-control"" placeholder=""Latest GPA"" required>
                            <div class=""invalid-feedback"">
                                Please provide a GPA.
                            </div>
                        </div>
                        <div  class=""col-md-3 mb-3"">
                            <label for=""validationCustom04"">Salary</label>
                            <input id=""salary"" type=""number"" class=""form-control"" placeholder=""Nominal"" required>
                            <div class=""invalid-feedback"">
                                Please provide a salary number.
                            </div>
                        </div>
                    </div>
                  <button class=""btn btn-primary d-block ml-auto"" onclick=""Insert()"">Submit</button>
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
            WriteLiteral(@"
            </div>
        </div>
        <div class=""modal-footer"">
            <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
        </div>
    </div>
</div>
                                                <!-- edit employee modal-->
<div class=""modal fade"" id=""updateForm"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Edit</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d57db63020ac5b69e6becdafee2ab2e834fc80b517711", async() => {
                WriteLiteral(@"
                  <div class=""form-row"">
                        <div class=""col-md-3 mb-3"">
                            <label for=""validationCustom01"">First name</label>
                            <input id=""ufirstname"" type=""text"" class=""form-control"" required>
                            <div class=""valid-feedback"">
                                Looks good!
                            </div>
                        </div>
                        <div class=""col-md-3 mb-3"">
                            <label for=""validationCustom02"">Last name</label>
                            <input id=""ulastname"" type=""text"" class=""form-control"" required>
                            <div class=""valid-feedback"">
                                Looks good!
                            </div>
                        </div>
                         <div class=""col-md-3 mb-3"">
                            <label for=""validationCustom02"">Gender</label>
                            <select id=""ugender"" class");
                WriteLiteral("=\"custom-select mr-sm-2\">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d57db63020ac5b69e6becdafee2ab2e834fc80b519121", async() => {
                    WriteLiteral("Choose...");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d57db63020ac5b69e6becdafee2ab2e834fc80b520494", async() => {
                    WriteLiteral("Male");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d57db63020ac5b69e6becdafee2ab2e834fc80b521835", async() => {
                    WriteLiteral("Female");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            </select>
                            <div class=""valid-feedback"">
                                Looks good!
                            </div>
                        </div>
                         <div class=""col-md-3 mb-3"">
                            <label for=""validationCustom02"">Birth date</label>
                            <input id=""ubirthdate"" type=""date"" class=""form-control"" required>
                            <div class=""valid-feedback"">
                                Looks good!
                            </div>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""col-md-4 mb-3"">
                            <label for=""validationCustom03"">Salary</label>
                            <input id=""usalary"" type=""number"" class=""form-control"" required>
                            <div class=""invalid-feedback"">
                                Please provide a salary.
                WriteLiteral(@"
                            </div>
                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label for=""validationCustom03"">Phone</label>
                            <input id=""uphone"" type=""text"" class=""form-control"" required>
                            <div class=""invalid-feedback"">
                                Please provide a valid city.
                            </div>
                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label for=""validationCustomUsername"">Email</label>
                            <div class=""input-group"">
                                <div class=""input-group-prepend"">
                                    <span class=""input-group-text"" id=""inputGroupPrepend""></span>
                                </div>
                                <input id=""uemail"" type=""text"" class=""form-control""  aria-describedby=""inputGroupPrepend"" required>
                  ");
                WriteLiteral(@"              <div class=""invalid-feedback"">
                                    Please enter your email.
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""form-row"" style=""display:none"">
                        <div class=""col-md-4 mb-3"">
                            <label for=""validationCustom03"">NIK</label>
                            <input id=""unik"" type=""text"" class=""form-control"" required>
                        </div>
                    </div>
                  <button class=""btn btn-primary d-block ml-auto"" onclick=""Update()"">Submit</button>
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
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"modal-footer\">\r\n            <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">Close</button>\r\n        </div>\r\n    </div>\r\n</div>\r\n ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591