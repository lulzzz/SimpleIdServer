﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SimpleIdServer.CredentialIssuer.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(o =>
{
    o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
{
    o.Authority = "https://localhost:5001/master";
    o.RequireHttpsMetadata = false;
    o.TokenValidationParameters.ValidateAudience = false;
})
.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
{
    options.ClientId = builder.Configuration["Authorization:ClientId"];
    options.ClientSecret = builder.Configuration["Authorization:ClientSecret"];
    options.Authority = builder.Configuration["Authorization:Issuer"];
    options.ResponseType = "code";
    options.ResponseMode = "query";
    options.SaveTokens = true;
    options.Scope.Clear();
    options.Scope.Add("openid");
    options.Scope.Add("profile");
});
builder.Services.AddAuthorization(b =>
{
    b.AddPolicy("WebsiteAuthenticated", p =>
    {
        p.RequireAuthenticatedUser();
    });
    b.AddPolicy("ApiAuthenticated", p =>
    {
        p.AuthenticationSchemes.Clear();
        p.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
        p.RequireAuthenticatedUser();
    });
    b.AddPolicy("credconfs", p =>
    {
        p.AuthenticationSchemes.Clear();
        p.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
        p.RequireClaim("scope", "credconfs");
    });
    b.AddPolicy("credinstances", p =>
    {
        p.AuthenticationSchemes.Clear();
        p.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
        p.RequireClaim("scope", "credinstances");
    });
});
builder.Services.AddLocalization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddCredentialIssuer(o =>
{
    o.ClientId = builder.Configuration["Authorization:ClientId"];
    o.ClientSecret = builder.Configuration["Authorization:ClientSecret"];
    o.AuthorizationServer = builder.Configuration["Authorization:Issuer"];
})
.UseInMemoryStore(c =>
{
    c.AddCredentialConfigurations(CredentialIssuerConfiguration.CredentialConfigurations);
});

var app = builder.Build();
app.UseStaticFiles();
app.UseRequestLocalization(e =>
{
    e.SetDefaultCulture("en-US");
    e.AddSupportedCultures("en-US");
    e.AddSupportedUICultures("en-US");
});
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();