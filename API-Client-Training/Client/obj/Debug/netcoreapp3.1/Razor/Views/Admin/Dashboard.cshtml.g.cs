#pragma checksum "C:\Users\Nayn\OneDrive\Documents\GitHub\Metrodata-Coding-Camp-Program-.NET\Client\Views\Admin\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20465ca25765f1971fc48991833c6677ec233e6c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Dashboard), @"mvc.1.0.view", @"/Views/Admin/Dashboard.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20465ca25765f1971fc48991833c6677ec233e6c", @"/Views/Admin/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("number"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("Insert()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("needs-validation"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("Update()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\Users\Nayn\OneDrive\Documents\GitHub\Metrodata-Coding-Camp-Program-.NET\Client\Views\Admin\Dashboard.cshtml"
  
    ViewData["Title"] = "Dashboard";
    Layout = "_NewDashboardLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main>
    <div class=""container-fluid px-4"">
        <h1 class=""mt-4"">Dashboard</h1>
        <ol class=""breadcrumb mb-4"">
            <li class=""breadcrumb-item active"">Dashboard</li>
        </ol>
        <div class=""row"">
            <div class=""col-xl-6"">
                <div class=""card mb-4"">
                    <div class=""card-header"">
                        <i class=""fas fa-chart-area me-1""></i>
                        Genders Pie Chart
                    </div>
                    <div class=""card-body""><div id=""gendersChart"" style=""width:100%; height:20rem""></div></div>
                </div>
            </div>
            <div class=""col-xl-6"">
                <div class=""card mb-4"">
                    <div class=""card-header"">
                        <i class=""fas fa-chart-bar me-1""></i>
                        Bar Chart Example
                    </div>
                    <div class=""card-body""><div id=""universitiesChart"" style=""width:100%; height:20rem""></div></div>");
            WriteLiteral(@"
                </div>
            </div>
        </div>
        <div class=""card mb-4"">
            <div class=""card-header"">
                <i class=""fas fa-table me-1""></i>
                DataTable Example
            </div>
            <div class=""card-body"" style=""overflow-x: scroll"">
                <table id=""TabelMasterData"" class=""display table table-bordered table-hover"" style=""width: 100%"">
                    <thead class=""thead-dark"">
                        <tr>
                            <!--<th>#</th>-->
                            <th>NIK</th>
                            <th>Nama Lengkap</th>
                            <th>Gender</th>
                            <th>Birthdate</th>
                            <th>Telepon</th>
                            <th>Email</th>
                            <th>Jabatan</th>
                            <th>Salary</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
      ");
            WriteLiteral("              <tbody class=\"MasterData\">\r\n                    </tbody>\r\n                </table>\r\n");
            WriteLiteral(@"            </div> 
        </div>
    </div>
</main>

<!-- Register employee modal-->
<div class=""modal fade"" id=""registrationForm"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Registration</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20465ca25765f1971fc48991833c6677ec233e6c9051", async() => {
                WriteLiteral(@"
                    <div class=""form-row"">
                        <div class=""col-md-3 mb-3"">
                            <label for=""firstname"">First name</label>
                            <input id=""firstname"" type=""text"" class=""form-control"" placeholder=""First name"" required>
                            <div class=""valid-feedback"">
                                Looks good!
                            </div>
                        </div>
                        <div class=""col-md-3 mb-3"">
                            <label for=""lastname"">Last name</label>
                            <input id=""lastname"" type=""text"" class=""form-control"" placeholder=""Last name"" required>
                            <div class=""valid-feedback"">
                                Looks good!
                            </div>
                        </div>
                        <div class=""col-md-3 mb-3 form-group"">
                            <label for=""gender"">Gender</label>
                          ");
                WriteLiteral("  <select id=\"gender\" class=\"custom-select mr-sm-2\" required>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20465ca25765f1971fc48991833c6677ec233e6c10500", async() => {
                    WriteLiteral("Choose...");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20465ca25765f1971fc48991833c6677ec233e6c12082", async() => {
                    WriteLiteral("Male");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20465ca25765f1971fc48991833c6677ec233e6c13423", async() => {
                    WriteLiteral("Female");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            </select>
                            <div class=""invalid-feedback"">
                                Please choose your gender
                            </div>
                        </div>
                        <div class=""col-md-3 mb-3"">
                            <label for=""birthdate"">Birth date</label>
                            <input id=""birthdate"" type=""date"" class=""form-control"" placeholder=""birthdate"" required>
                            <div class=""invalid-feedback"">
                                Please choose your birthdate
                            </div>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""col-md-4 mb-3"">
                            <label for=""phone"">Phone</label>
                            <input id=""phone"" type=""text"" class=""form-control"" placeholder=""Phone"" required>
                            <div class=""invalid-feedback"">
       ");
                WriteLiteral(@"                         Please provide a phone number.
                            </div>
                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label for=""email"">Email</label>
                            <div class=""input-group"">
                                <input id=""email"" type=""text"" class=""form-control"" placeholder=""Email"" aria-describedby=""inputGroupPrepend"" required>
                                <div class=""invalid-feedback"">
                                    Please enter your email.
                                </div>
                            </div>
                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label for=""password"">Password</label>
                            <input id=""password"" type=""text"" class=""form-control"" placeholder=""Password"" required>
                            <div class=""invalid-feedback"">
                                Please provide ");
                WriteLiteral(@"a password.
                            </div>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""col-md-3 mb-3 form-group"">
                            <label for=""uni"">University</label>
                            <select id=""uni"" class=""custom-select mr-sm-2"">
                            </select>
                        </div>
                        <div class=""col-md-3 mb-3"">
                            <label for=""degree"">Degree</label>
                            <input id=""degree"" type=""text"" class=""form-control"" placeholder=""Latest Degree"">
                        </div>
                        <div class=""col-md-3 mb-3"">
                            <label for=""gpa"">GPA</label>
                            <input id=""gpa"" type=""text"" class=""form-control"" placeholder=""Latest GPA"">
                        </div>
                        <div class=""col-md-3 mb-3"">
                            <label ");
                WriteLiteral(@"for=""salary"">Salary</label>
                            <input id=""salary"" type=""number"" class=""form-control"" placeholder=""Nominal"" required>
                            <div class=""invalid-feedback"">
                                Please provide a salary number.
                            </div>
                        </div>
                    </div>
                    <button class=""btn btn-primary d-block ml-auto"" type=""submit"">Submit</button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20465ca25765f1971fc48991833c6677ec233e6c20496", async() => {
                WriteLiteral(@"
                    <div class=""form-row"">
                        <div class=""col-md-3 mb-3"">
                            <label for=""ufirstname"">First name</label>
                            <input id=""ufirstname"" type=""text"" class=""form-control"" required>
                            <div class=""valid-feedback"">
                                Good
                            </div>
                        </div>
                        <div class=""col-md-3 mb-3"">
                            <label for=""ulastname"">Last name</label>
                            <input id=""ulastname"" type=""text"" class=""form-control"" required>
                            <div class=""valid-feedback"">
                                Good
                            </div>
                        </div>
                        <div class=""col-md-3 mb-3"">
                            <label for=""ugender"">Gender</label>
                            <select id=""ugender"" class=""custom-select mr-sm-2"">
              ");
                WriteLiteral("                  ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20465ca25765f1971fc48991833c6677ec233e6c21863", async() => {
                    WriteLiteral("Male");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20465ca25765f1971fc48991833c6677ec233e6c23204", async() => {
                    WriteLiteral("Female");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
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
                                Good
                            </div>
                        </div>
                        <div class=""col-md-3 mb-3"">
                            <label for=""ubirthdate"">Birth date</label>
                            <input id=""ubirthdate"" type=""date"" class=""form-control"" required>
                            <div class=""valid-feedback"">
                                Good
                            </div>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""col-md-4 mb-3"">
                            <label for=""uemail"">Email</label>
                            <input id=""uemail"" type=""text"" class=""form-control"" aria-describedby=""inputGroupPrepend"" required>
                            <div class=""invalid-feedback"">
                                Invalid Email
            ");
                WriteLiteral(@"                </div>
                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label for=""uphone"">Phone</label>
                            <input id=""uphone"" type=""text"" class=""form-control"" required>
                            <div class=""invalid-feedback"">
                                Bad
                            </div>
                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label for=""usalary"">Salary</label>
                            <input id=""usalary"" type=""number"" class=""form-control"" required>
                            <div class=""invalid-feedback"">
                                Bad
                            </div>
                        </div>
                    </div>
                    <div class=""form-row"" style=""display:none"">
                        <div class=""col-md-4 mb-3"">
                            <label for=""unik"">NIK</label>
              ");
                WriteLiteral("              <input id=\"unik\" type=\"text\" class=\"form-control\" required>\r\n                        </div>\r\n                    </div>\r\n                    <button class=\"btn btn-primary d-block ml-auto\" type=\"submit\">Submit</button>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"modal-footer\">\r\n            <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">Close</button>\r\n        </div>\r\n    </div>\r\n</div>");
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
