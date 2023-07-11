﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SimpleIdServer.IdServer.Host.Acceptance.Tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class UserInfoFeature : object, Xunit.IClassFixture<UserInfoFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "UserInfo.feature"
#line hidden
        
        public UserInfoFeature(UserInfoFeature.FixtureData fixtureData, SimpleIdServer_IdServer_Host_Acceptance_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "UserInfo", "\tCheck the userinfo endpoint", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Claims are returned in JSON format (HTTP GET)")]
        [Xunit.TraitAttribute("FeatureTitle", "UserInfo")]
        [Xunit.TraitAttribute("Description", "Claims are returned in JSON format (HTTP GET)")]
        public void ClaimsAreReturnedInJSONFormatHTTPGET()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Claims are returned in JSON format (HTTP GET)", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
 testRunner.Given("authenticate a user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table565 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table565.AddRow(new string[] {
                            "response_type",
                            "code"});
                table565.AddRow(new string[] {
                            "client_id",
                            "thirtySevenClient"});
                table565.AddRow(new string[] {
                            "state",
                            "state"});
                table565.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table565.AddRow(new string[] {
                            "scope",
                            "openid email role"});
                table565.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
                table565.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table565.AddRow(new string[] {
                            "display",
                            "popup"});
#line 6
 testRunner.When("execute HTTP GET request \'http://localhost/authorization\'", ((string)(null)), table565, "When ");
#line hidden
#line 17
 testRunner.And("extract parameter \'code\' from redirect url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table566 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table566.AddRow(new string[] {
                            "client_id",
                            "thirtySevenClient"});
                table566.AddRow(new string[] {
                            "client_secret",
                            "password"});
                table566.AddRow(new string[] {
                            "grant_type",
                            "authorization_code"});
                table566.AddRow(new string[] {
                            "code",
                            "$code$"});
                table566.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
#line 19
 testRunner.And("execute HTTP POST request \'https://localhost:8080/token\'", ((string)(null)), table566, "And ");
#line hidden
#line 27
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 28
 testRunner.And("extract parameter \'access_token\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table567 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table567.AddRow(new string[] {
                            "Authorization",
                            "Bearer $access_token$"});
#line 30
 testRunner.And("execute HTTP GET request \'http://localhost/userinfo\'", ((string)(null)), table567, "And ");
#line hidden
#line 34
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 36
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 37
 testRunner.Then("HTTP header has \'Content-Type\'=\'application/json\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 38
 testRunner.Then("JSON \'sub\'=\'user\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 39
 testRunner.Then("JSON \'$.role[0]\'=\'role1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 40
 testRunner.Then("JSON \'$.role[1]\'=\'role2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 41
 testRunner.Then("JSON \'email\'=\'email@outlook.fr\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Claims are returned in JSON format (HTTP POST)")]
        [Xunit.TraitAttribute("FeatureTitle", "UserInfo")]
        [Xunit.TraitAttribute("Description", "Claims are returned in JSON format (HTTP POST)")]
        public void ClaimsAreReturnedInJSONFormatHTTPPOST()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Claims are returned in JSON format (HTTP POST)", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 43
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 44
 testRunner.Given("authenticate a user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table568 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table568.AddRow(new string[] {
                            "response_type",
                            "code"});
                table568.AddRow(new string[] {
                            "client_id",
                            "thirtySevenClient"});
                table568.AddRow(new string[] {
                            "state",
                            "state"});
                table568.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table568.AddRow(new string[] {
                            "scope",
                            "openid email role"});
                table568.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
                table568.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table568.AddRow(new string[] {
                            "display",
                            "popup"});
#line 45
 testRunner.When("execute HTTP GET request \'http://localhost/authorization\'", ((string)(null)), table568, "When ");
#line hidden
#line 56
 testRunner.And("extract parameter \'code\' from redirect url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table569 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table569.AddRow(new string[] {
                            "client_id",
                            "thirtySevenClient"});
                table569.AddRow(new string[] {
                            "client_secret",
                            "password"});
                table569.AddRow(new string[] {
                            "grant_type",
                            "authorization_code"});
                table569.AddRow(new string[] {
                            "code",
                            "$code$"});
                table569.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
#line 58
 testRunner.And("execute HTTP POST request \'https://localhost:8080/token\'", ((string)(null)), table569, "And ");
#line hidden
#line 66
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 67
 testRunner.And("extract parameter \'access_token\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table570 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table570.AddRow(new string[] {
                            "access_token",
                            "$access_token$"});
#line 69
 testRunner.And("execute HTTP POST request \'http://localhost/userinfo\'", ((string)(null)), table570, "And ");
#line hidden
#line 73
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 75
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 76
 testRunner.Then("HTTP header has \'Content-Type\'=\'application/json\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 77
 testRunner.Then("JSON \'sub\'=\'user\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 78
 testRunner.Then("JSON \'$.role[0]\'=\'role1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 79
 testRunner.Then("JSON \'$.role[1]\'=\'role2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 80
 testRunner.Then("JSON \'email\'=\'email@outlook.fr\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Claims are returned in JWS token")]
        [Xunit.TraitAttribute("FeatureTitle", "UserInfo")]
        [Xunit.TraitAttribute("Description", "Claims are returned in JWS token")]
        public void ClaimsAreReturnedInJWSToken()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Claims are returned in JWS token", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 82
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 83
 testRunner.Given("authenticate a user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table571 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table571.AddRow(new string[] {
                            "response_type",
                            "code"});
                table571.AddRow(new string[] {
                            "client_id",
                            "thirtyEightClient"});
                table571.AddRow(new string[] {
                            "state",
                            "state"});
                table571.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table571.AddRow(new string[] {
                            "scope",
                            "openid email role"});
                table571.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
                table571.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table571.AddRow(new string[] {
                            "display",
                            "popup"});
#line 84
 testRunner.When("execute HTTP GET request \'http://localhost/authorization\'", ((string)(null)), table571, "When ");
#line hidden
#line 95
 testRunner.And("extract parameter \'code\' from redirect url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table572 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table572.AddRow(new string[] {
                            "client_id",
                            "thirtyEightClient"});
                table572.AddRow(new string[] {
                            "client_secret",
                            "password"});
                table572.AddRow(new string[] {
                            "grant_type",
                            "authorization_code"});
                table572.AddRow(new string[] {
                            "code",
                            "$code$"});
                table572.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
#line 97
 testRunner.And("execute HTTP POST request \'https://localhost:8080/token\'", ((string)(null)), table572, "And ");
#line hidden
#line 105
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 106
 testRunner.And("extract parameter \'access_token\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table573 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table573.AddRow(new string[] {
                            "Authorization",
                            "Bearer $access_token$"});
#line 108
 testRunner.And("execute HTTP GET request \'http://localhost/userinfo\'", ((string)(null)), table573, "And ");
#line hidden
#line 112
 testRunner.And("extract payload from HTTP body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 114
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 115
 testRunner.Then("HTTP header has \'Content-Type\'=\'application/jwt\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 116
 testRunner.Then("JWT alg = \'RS256\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 117
 testRunner.Then("JWT has \'sub\'=\'user\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 118
 testRunner.Then("JWT has \'email\'=\'email@outlook.fr\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 119
 testRunner.Then("JWT has \'role\'=\'role1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 120
 testRunner.Then("JWT has \'role\'=\'role2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Claims are returned in JWE token")]
        [Xunit.TraitAttribute("FeatureTitle", "UserInfo")]
        [Xunit.TraitAttribute("Description", "Claims are returned in JWE token")]
        public void ClaimsAreReturnedInJWEToken()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Claims are returned in JWE token", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 122
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 123
 testRunner.Given("authenticate a user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table574 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table574.AddRow(new string[] {
                            "response_type",
                            "code"});
                table574.AddRow(new string[] {
                            "client_id",
                            "thirtyNineClient"});
                table574.AddRow(new string[] {
                            "state",
                            "state"});
                table574.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table574.AddRow(new string[] {
                            "scope",
                            "openid email role"});
                table574.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
                table574.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table574.AddRow(new string[] {
                            "display",
                            "popup"});
#line 124
 testRunner.When("execute HTTP GET request \'http://localhost/authorization\'", ((string)(null)), table574, "When ");
#line hidden
#line 135
 testRunner.And("extract parameter \'code\' from redirect url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table575 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table575.AddRow(new string[] {
                            "client_id",
                            "thirtyNineClient"});
                table575.AddRow(new string[] {
                            "client_secret",
                            "password"});
                table575.AddRow(new string[] {
                            "grant_type",
                            "authorization_code"});
                table575.AddRow(new string[] {
                            "code",
                            "$code$"});
                table575.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
#line 137
 testRunner.And("execute HTTP POST request \'https://localhost:8080/token\'", ((string)(null)), table575, "And ");
#line hidden
#line 145
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 146
 testRunner.And("extract parameter \'access_token\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table576 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table576.AddRow(new string[] {
                            "Authorization",
                            "Bearer $access_token$"});
#line 148
 testRunner.And("execute HTTP GET request \'http://localhost/userinfo\'", ((string)(null)), table576, "And ");
#line hidden
#line 152
 testRunner.And("extract payload from HTTP body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 154
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 155
 testRunner.Then("HTTP header has \'Content-Type\'=\'application/jwt\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 156
 testRunner.Then("JWT is encrypted", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 157
 testRunner.Then("JWT alg = \'RSA1_5\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 158
 testRunner.Then("JWT enc = \'A128CBC-HS256\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Essential claims \'name\' and \'email\' are returned by the userinfo endpoint")]
        [Xunit.TraitAttribute("FeatureTitle", "UserInfo")]
        [Xunit.TraitAttribute("Description", "Essential claims \'name\' and \'email\' are returned by the userinfo endpoint")]
        public void EssentialClaimsNameAndEmailAreReturnedByTheUserinfoEndpoint()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Essential claims \'name\' and \'email\' are returned by the userinfo endpoint", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 160
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 161
 testRunner.Given("authenticate a user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table577 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table577.AddRow(new string[] {
                            "response_type",
                            "code"});
                table577.AddRow(new string[] {
                            "client_id",
                            "fortyClient"});
                table577.AddRow(new string[] {
                            "state",
                            "state"});
                table577.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table577.AddRow(new string[] {
                            "scope",
                            "openid"});
                table577.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
                table577.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table577.AddRow(new string[] {
                            "display",
                            "popup"});
                table577.AddRow(new string[] {
                            "claims",
                            "{ \"userinfo\" : { \"name\":  { \"essential\": true } , \"email\" : { \"essential\" : true " +
                                "} } }"});
#line 162
 testRunner.When("execute HTTP GET request \'http://localhost/authorization\'", ((string)(null)), table577, "When ");
#line hidden
#line 174
 testRunner.And("extract parameter \'code\' from redirect url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table578 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table578.AddRow(new string[] {
                            "client_id",
                            "fortyClient"});
                table578.AddRow(new string[] {
                            "client_secret",
                            "password"});
                table578.AddRow(new string[] {
                            "grant_type",
                            "authorization_code"});
                table578.AddRow(new string[] {
                            "code",
                            "$code$"});
                table578.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
#line 176
 testRunner.And("execute HTTP POST request \'https://localhost:8080/token\'", ((string)(null)), table578, "And ");
#line hidden
#line 184
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 185
 testRunner.And("extract parameter \'access_token\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table579 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table579.AddRow(new string[] {
                            "Authorization",
                            "Bearer $access_token$"});
#line 187
 testRunner.And("execute HTTP GET request \'http://localhost/userinfo\'", ((string)(null)), table579, "And ");
#line hidden
#line 191
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 193
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 194
 testRunner.Then("HTTP header has \'Content-Type\'=\'application/json\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 195
 testRunner.Then("JSON \'sub\'=\'user\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 196
 testRunner.Then("JSON \'email\'=\'email@outlook.fr\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                UserInfoFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                UserInfoFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
